using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        public WeddingContext context;
        public HomeController(WeddingContext Context) {
            context = Context;
        }
        public IActionResult Index() {
            if(HttpContext.Session.GetInt32("LoggedUser") == null || HttpContext.Session.GetInt32("LoggedUser") == -1) {
                return View("Login");
            }
            ViewBag.ActiveUser = context.Users
            .Include(u => u.RSVPs)
            .ThenInclude(rsvp => rsvp.W)
            .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("LoggedUser"));
            ViewBag.Weddings = context.Weddings.Include(w => w.RSVPs);
            return View();
        }
        [HttpGet("/newwedding")]
        public ViewResult NewWedding() {
            return View();
        }
        public IActionResult Login(LogUser loggingUser) {
            PasswordHasher<LogUser> LHasher = new PasswordHasher<LogUser>();
            if (ModelState.IsValid) {
                User match = context.Users.FirstOrDefault(u => u.Email == loggingUser.LEmail);
                if(match == null) {
                    ModelState.AddModelError("LEmail", "We don't have a user with that email address");
                } else if(LHasher.VerifyHashedPassword(loggingUser, match.Password, loggingUser.LPassword) == 0) {
                    ModelState.AddModelError("LPassword", "Email Address and Password do not match");
                } else {
                    HttpContext.Session.SetInt32("LoggedUser", match.UserId);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public IActionResult Register(User newUser) {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            if(ModelState.IsValid) {
                foreach(User u in context.Users) {
                    if(u.Email == newUser.Email) {
                        ModelState.AddModelError("Email", "That email address is already in use");
                        return View("Login");
                    }
                }
                newUser.RSVPs = new List<RSVP>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                context.Add(newUser);
                context.SaveChanges();
                HttpContext.Session.SetInt32("LoggedUser", newUser.UserId);
                return RedirectToAction("Index");
            }
            return View("Login");
        }
        [HttpGet("/logout")]
        public RedirectToActionResult LogOut() {
            HttpContext.Session.SetInt32("LoggedUser", -1);
            return RedirectToAction("Index");
        }
        public IActionResult CreateWedding(Wedding newWedding) {
            int? LoggedUserId = HttpContext.Session.GetInt32("LoggedUser");
            if (LoggedUserId == null || LoggedUserId == -1) {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid) {
                if (newWedding.Date - DateTime.Now < new TimeSpan(0))
                newWedding.RSVPs = new List<RSVP>();
                newWedding.CreatorId = (int)LoggedUserId;
                context.Add(newWedding);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("NewWedding");
        }
        [HttpGet("/weddings/{id}")]
        public IActionResult OneWedding(int id) {
            int? LoggedUserId = HttpContext.Session.GetInt32("LoggedUser");
            if (LoggedUserId == null || LoggedUserId == -1) {
                return RedirectToAction("Index");
            }
            ViewBag.Wedding = context.Weddings.Include(w => w.RSVPs)
            .ThenInclude(rsvp => rsvp.U)
            .FirstOrDefault(w => w.WeddingId == id);
            return View();
        }
        [HttpGet("/{id}/delete")]
        public RedirectToActionResult Delete(int id) {
            context.Remove(context.Weddings.FirstOrDefault(w => w.WeddingId == id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("/{id}/rsvp")]
        public RedirectToActionResult Rsvp(int id) {
            RSVP newR = new RSVP();
            int? LUID =  HttpContext.Session.GetInt32("LoggedUser");
            newR.UserId = (int)LUID;
            newR.WeddingId = id;
            newR.U = context.Users.FirstOrDefault(u => u.UserId == newR.UserId);
            newR.W = context.Weddings.FirstOrDefault(w => w.WeddingId == newR.WeddingId);
            context.Add(newR);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("/{id}/unrsvp")]
        public RedirectToActionResult UnRsvp(int id) {
            int? LUID =  HttpContext.Session.GetInt32("LoggedUser");
            RSVP oldR = context.RSVPs.Where(r => r.WeddingId == id).FirstOrDefault(r => r.UserId == LUID);
            context.Remove(oldR);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("/cleardata/{key}")]
        public RedirectToActionResult ClearData(string key) {
            if(key != "bullshithacks") return RedirectToAction("Index");
            foreach(User u in context.Users) context.Remove(u);
            foreach(Wedding w in context.Weddings) context.Remove(w);
            context.SaveChanges();
            System.Console.WriteLine("###############################################################\nDatabase Cleared\n\n");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

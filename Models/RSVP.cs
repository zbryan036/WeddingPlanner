

namespace WeddingPlanner.Models {
    public class RSVP {
        public int RSVPId { get; set; }
        public int UserId { get; set; }
        public int WeddingId { get; set; }
        public User U { get; set; }
        public Wedding W { get; set; }
    }
}
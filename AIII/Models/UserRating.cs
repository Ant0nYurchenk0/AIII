using System;

namespace AIII.Models
{
    public class UserRating
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string MovieId { get; set; }

        public int? LikesAmount { get; set; }

        public int? DislikesAmount { get; set; }
    }
}
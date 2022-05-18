using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Models
{
    public class UserRating
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string MovieId { get; set; }

        public int? LikesAmount { get; set; }

        public int? DislikesAmount { get; set; }
    }
}
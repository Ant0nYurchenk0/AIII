using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Dtos
{
    public class UserRatingDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string MovieId { get; set; }

        public int? LikesAmount { get; set; }

        public int? DislikesAmount { get; set; }
        public int? WatchedAmount { get; set; }
    }
}
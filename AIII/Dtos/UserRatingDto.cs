using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Dtos
{
    public class UserRatingDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int GoodEmodjiAmount { get; set; }

        public int BadEmodjiAmount { get; set; }
    }
}
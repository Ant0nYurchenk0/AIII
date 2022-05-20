using AIII.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Dtos
{
    public class UserRatingDto        
    {
        public UserRatingDto()
        {

        }
        public UserRatingDto(string id, UserRatingRepository userRatingRepository)
        {
            LikesAmount = userRatingRepository.GetAllUserAmountOfLikes(id);
            DislikesAmount = userRatingRepository.GetAllUserAmountOfDislikes(id);
            WatchedAmount = userRatingRepository.GetAllUserWatchedAmount(id);
            Watched = false;
            Liked = false;
            Disliked = false;
        }
        public int Id { get; set; }

        public string UserId { get; set; }

        public string MovieId { get; set; }

        public int? LikesAmount { get; set; }

        public int? DislikesAmount { get; set; }

        public int? WatchedAmount { get; set; }

        public bool? Watched { get; set; }
        public bool? Liked { get; set; }
        public bool? Disliked { get; set; }
    }
}
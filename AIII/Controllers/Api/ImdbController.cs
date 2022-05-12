using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AIII.Controllers.Api
{
    public class ImdbController : ApiController
    {
        private ImdbRepository _repository;
        public ImdbController()
        {
            _repository = new ImdbRepository();
        }
        public MovieFullInfoDto GetMovie(string id)
        {
            var movie = _repository.SearchById(id);
            return Mapper.Map<MovieFullInfoDto>(movie);
        }
    }
}
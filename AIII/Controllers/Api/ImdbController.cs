using AIII.Dtos;
using AIII.Models;
using AIII.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AIII.Controllers.Api
{
    public class ImdbController : ApiController
    {
        private ImdbRepository _repository;
        public ImdbController()
        {
            _repository = new ImdbRepository();
        }

        [HttpGet]
        [Route("Movie")]
        public IHttpActionResult GetMovie(string id)
        {
            var movie = _repository.SearchById(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("api/imdb/searchtitle")]
        public IHttpActionResult SearchTitle()
        {
            var param = Request.RequestUri.Query.ToString();
            var movie = _repository.SearchTitle(param);
            return Ok(movie);
        }

    }
}
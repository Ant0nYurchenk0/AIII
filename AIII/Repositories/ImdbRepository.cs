﻿using AIII.Dtos;
using AIII.Imdb_Api;
using AIII.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace AIII.Repositories
{
    public class ImdbRepository
    {
        private ApplicationDbContext _context;
        public ImdbRepository()
        {
            _context = new ApplicationDbContext();
        }
        public MovieFullInfoDto SearchById(string id)
        {
            string Baseurl = Imdb.Title+id;
            var result = new MovieFullInfoDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync("").Result;
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<MovieFullInfoDto>(EmpResponse);
                    result.Budget = JsonConvert.DeserializeObject<dynamic>(EmpResponse).boxOffice.budget;
                }
            }
            return result;
        }

        public List<MovieShortInfoDto> TopTVs()
        {
            return GetListOfItems(Imdb.TopTVs);
        }

        public List<MovieShortInfoDto> PopularMovies()
        {
            return GetListOfItems(Imdb.PopularMovies);
        }

        public List<MovieShortInfoDto> TopMovies()
        {
            return GetListOfItems(Imdb.TopMovies);
        }

        public List<MovieShortInfoDto> PopularTVs()
        {
            return GetListOfItems(Imdb.PopularTVs);
        }

        public List<MovieShortInfoDto> Search(string param)
        {
            string Baseurl = Imdb.SearchTitle+ param;
            var result = new List<MovieShortInfoDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync("").Result;
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    var jsonResult = JObject.Parse(EmpResponse);
                    var results = jsonResult["results"].ToString();
                    result = JsonConvert.DeserializeObject<List<MovieShortInfoDto>>(results);
                }
            }
            return result;
        }
        private List<MovieShortInfoDto> GetListOfItems(string link)
        {
            string Baseurl = link;
            var result = new List<MovieShortInfoDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync("").Result;
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    var jsonResult = JObject.Parse(EmpResponse);
                    var results = jsonResult["items"].ToString();
                    result = JsonConvert.DeserializeObject<List<MovieShortInfoDto>>(results);
                }
            }
            return result;
        }
    }
}
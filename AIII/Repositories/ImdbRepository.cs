using AIII.Dtos;
using AIII.Imdb_Api;
using AIII.Models;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;


namespace AIII.Repositories
{
    public class ImdbRepository
    {
        private ApplicationDbContext _context;
        public ImdbRepository()
        {
            _context = new ApplicationDbContext();
        }
        public MovieFullInfoDto SearchById(string id, string key)
        {
            string Baseurl = string.Format(Imdb.Title, key) + id;
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
                    result.Budget = JsonConvert.DeserializeObject<dynamic>(EmpResponse).boxOffice.budget ?? null;
                    result.CumulativeWorldWideGross = JsonConvert.DeserializeObject<dynamic>(EmpResponse).boxOffice.cumulativeWorldwideGross ?? null;
                    try
                    {
                        result.Seasons = JsonConvert.DeserializeObject<dynamic>(EmpResponse).tvSeriesInfo.seasons.Last ?? null;
                    }
                    catch { }
                }
            }
            result.Video = GetTrailerUrl(id, key);
            return result;
        }

        public List<MovieFullInfoDto> TopTVs(string key)
        {
            return GetListOfItems(Imdb.TopTVs, key);
        }

        public List<MovieFullInfoDto> PopularMovies(string key)
        {
            return GetListOfItems(Imdb.PopularMovies, key);
        }

        public List<MovieFullInfoDto> TopMovies(string key)
        {
            return GetListOfItems(Imdb.TopMovies, key);
        }

        public List<MovieFullInfoDto> PopularTVs(string key)
        {
            return GetListOfItems(Imdb.PopularTVs, key);
        }

        public List<MovieFullInfoDto> Search(string param, string key)
        {
            string Baseurl = string.Format(Imdb.SearchTitle, key) + param;
            var result = new List<MovieFullInfoDto>();
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
                    result = JsonConvert.DeserializeObject<List<MovieFullInfoDto>>(results);
                }
            }
            return result;
        }
        private List<MovieFullInfoDto> GetListOfItems(string link, string key)
        {
            string Baseurl = string.Format(link, key);
            var result = new List<MovieFullInfoDto>();
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
                    result = JsonConvert.DeserializeObject<List<MovieFullInfoDto>>(results);
                }
            }
            return result;
        }
        private string GetTrailerUrl(string id, string key)
        {
            var url = string.Empty;
            string Baseurl = string.Format(Imdb.Trailer, key) + id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync("").Result;
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    url = JsonConvert.DeserializeObject<dynamic>(EmpResponse).videoUrl;
                }
            }
            if (string.IsNullOrEmpty(url))
                return "https://www.youtube.com/embed/";
            return "https://www.youtube.com/embed/" + url.Substring(url.Length - 11, 11);
        }
        public void SaveMovie(MovieFullInfoDto fullInfoDto)
        {
            if (!_context.MovieShortInfo.Any(m => m.Id == fullInfoDto.Id))
            {
                var shortInfoDto = Mapper.Map<MovieFullInfoDto, MovieShortInfoDto>(fullInfoDto);
                var shortInfo = Mapper.Map<MovieShortInfoDto, MovieShortInfo>(shortInfoDto);
                _context.MovieShortInfo.Add(shortInfo);
                _context.SaveChanges();
            }
        }
    }
}
using AIII.Dtos;
using AIII.Imdb_Api;
using AIII.Models;
using Newtonsoft.Json;
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
    }
}
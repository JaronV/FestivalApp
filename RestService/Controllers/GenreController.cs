using FestivalLibPortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestService.Controllers
{
    public class GenreController : ApiController
    {
        public IEnumerable<Genre> Get()
        {
            //return new string[] { "value1", "value2" }

            return Models._DAL.GenreRepository.GetGenres();

        }

        // GET api/band/5
        public IEnumerable<Band> Get(int id)
        {
            return Models._DAL.BandRepository.GetBandByGenre(id);
        }

        // POST api/band
        public void Post([FromBody]string value)
        {
        }

        // PUT api/band/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FestivalLibPortable;
using System.Collections.ObjectModel;

namespace RestService.Controllers
{
    public class LineUpController : ApiController
    {
        // GET api/lineup
        public IEnumerable<IEnumerable<Stage>> Get()
        {
           ObservableCollection<DateTime> lstDagen =  Models._DAL.FestivalRepository.aantalDagen();
           ObservableCollection<ObservableCollection<Stage>> stages = new ObservableCollection<ObservableCollection<Stage>>();
           
           foreach (DateTime dag in lstDagen)
           {
         stages.Add(Models._DAL.StageRepository.GetStagesByDay(dag));
           }
        
           return stages;
        }
        // GET api/lineup/dag
        public LineUp Get(int id)
        {
            return null;
        }

        // POST api/band
        public void Post([FromBody]string value)
        {
        }

        // PUT api/band/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/band/5
        public void Delete(int id)
        {
        }
    }
}

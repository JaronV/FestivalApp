using FestivalLib.Model;
using SSA_Festival.Models;
using SSA_Festival.Models._DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSA_Festival.Controllers
{
    public class LineUpController : Controller
    {
        //
        // GET: /LineUp/

      
       // [AllowAnonymous]
        public ActionResult Index()
        {
            //ObservableCollection<LineUp> lstLineUps = LineUpRepository.GetLineUps();

            //return View("Index",lstLineUps);
            LineUpVM vm = new LineUpVM();
            //vm.LineUps = LineUp.GetLineUps();
            vm.LineUps = LineUpRepository.GetLineUps();
            vm.lstDagen = new SelectList(LineUpRepository.GetDagen().ToList());
            vm.lstPodia = new SelectList(LineUpRepository.GetStages().ToList(), "ID", "Name");
           
            return View("Index", vm);
        }

        public ActionResult Filter(LineUpVM vm)
        {
            vm.LineUps = LineUp.GetBandsByLineUpIDAndDate(vm.SelectedPod, vm.SelectedDag);
            vm.lstDagen = new SelectList(LineUpRepository.GetDagen().ToList());
            vm.lstPodia = new SelectList(LineUpRepository.GetStages().ToList(), "ID", "Name");
            return View("Index", vm);
        }

       // [AllowAnonymous]
        public ActionResult BandDetails(int bandID)
        {
            Band band = BandRepository.GetBandByID(bandID);
            return View("BandDetails", band);
        }
    }
}

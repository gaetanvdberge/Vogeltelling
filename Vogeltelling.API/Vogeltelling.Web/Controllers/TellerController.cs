using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vogeltelling.Web.Models;
using Vogeltelling.Web.Repositories;

namespace Vogeltelling.Web.Controllers
{
    public class TellerController : Controller
    {
        private readonly ITellerRepository _tellerRepository;
        private readonly IBirdRepository _birdRepository;


        public TellerController(ITellerRepository tellerRepository, IBirdRepository birdRepository)
        {
            _tellerRepository = tellerRepository;
            _birdRepository = birdRepository;
        }

        
        public IActionResult Index()
        {
            var moments = _tellerRepository.GetAllMoments() as List<Moments>;
            return View(moments);

        }

        private static Guid MomentId;
        private static Guid ProvincieID;
        private static string UserName;

        [Authorize]
        public IActionResult Provincies(Guid id) //Dit is de MomentID die meegegeven wordt van Index naar Provincies
        {
            var provincies = _tellerRepository.GetAllProvincies() as List<Provincie>;
            MomentId = id;
            return View(provincies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Provincies()
        {
            try
            {
                var SelectedRadioButton = Request.Form["item.RegionName"];
                ProvincieID = new Guid(SelectedRadioButton);
                return RedirectToAction("Teller");
            }
            catch (Exception)
            {
                
                return RedirectToAction("provincies");
            }
        }

        [Authorize]
        public IActionResult Teller()
        {
            var birds = _birdRepository.GetAllBirds() as List<Bird>;
            UserName = HttpContext.User.Identity.Name;
            return View(birds);
        }

        [Authorize]
        public IActionResult UpCount(Guid birdID)
        {
            User_has_birds newentry = new User_has_birds()
            {
                UserName = UserName,
                BirdId = birdID,
                DateTime = DateTime.Now,
                RegionId = ProvincieID,
                MomentId = MomentId
            };

            var succes = _tellerRepository.BirdCountAdded(newentry);
            return RedirectToAction("Teller");
        }


    }
}
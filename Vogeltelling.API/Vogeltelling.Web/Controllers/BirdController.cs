using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vogeltelling.Web.Models;
using Vogeltelling.Web.Repositories;

namespace Vogeltelling.Web.Controllers
{
    public class BirdController : Controller
    {
        private readonly IBirdRepository _birdRepository;

        public BirdController(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        
        public IActionResult Index()
        {

            var birds = _birdRepository.GetAllBirds() as List<Bird>;
            return View(birds);
        }

        public IActionResult Details(Guid id)
        {
            var bird = _birdRepository.GetBirdById(id);
            if (bird == null) return NotFound();
            return View(bird);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Guid id)
        {
            var bird = _birdRepository.GetBirdById(id);
            if (bird == null) return NotFound();
            return View(bird);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Bird bird) //[Bind("BirdId, Name, Description, PhotoUrl")]
        {
            try
            {
                var succes = _birdRepository.EditBird(bird);
                if (succes)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Bird bird)
        {
            try
            {
                var succes = _birdRepository.CreateBird(bird);
                if (succes)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(Guid id)
        {
            var bird = _birdRepository.GetBirdById(id);
            if (bird == null) return NotFound();
            return View(bird);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _birdRepository.DeleteBird(id);
            return RedirectToAction("Index");
        }


    }
}
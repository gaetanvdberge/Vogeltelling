using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vogeltelling.Web.Data;
using Vogeltelling.Web.Models;

namespace Vogeltelling.Web.Repositories
{
    public class BirdRepository : IBirdRepository
    {
        private BirdsContext _birdContext;

        public BirdRepository(BirdsContext birdsContext)
        {
            _birdContext = birdsContext;
        }

        public IEnumerable<Bird> GetAllBirds()
        {
            try
            {
                return _birdContext.Birds.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bird GetBirdById(Guid birdId)
        {
            try
            {
                var bird = _birdContext.Birds.Where(b => b.BirdId == birdId).AsNoTracking();
                return bird.SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Boolean EditBird(Bird bird)
        {
            try
            {
                _birdContext.Entry(bird).State = EntityState.Modified;
                _birdContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean CreateBird(Bird bird)
        {
            try
            {
                bird.BirdId = new Guid();
                _birdContext.Birds.Add(bird);
                _birdContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBird(Guid birdId)
        {
            try
            {
                var bird = _birdContext.Birds.Where(b => b.BirdId == birdId).AsNoTracking().SingleOrDefault();
                _birdContext.Birds.Remove(bird);
                _birdContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

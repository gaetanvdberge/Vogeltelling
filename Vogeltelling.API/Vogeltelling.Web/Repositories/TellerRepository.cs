using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vogeltelling.Web.Data;
using Vogeltelling.Web.Models;

namespace Vogeltelling.Web.Repositories
{
    public class TellerRepository : ITellerRepository
    {

        private BirdsContext _birdContext;

        public TellerRepository(BirdsContext birdsContext)
        {
            _birdContext = birdsContext;
        }

        public IEnumerable<Moments> GetAllMoments()
        {
            try
            {
                return _birdContext.Moments.OrderBy(m => m.Start).AsNoTracking().ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public IEnumerable<Provincie> GetAllProvincies()
        {
            try
            {
                return _birdContext.Region.OrderBy(m => m.RegionName).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean BirdCountAdded(User_has_birds newBird)
        {
            try
            {
                _birdContext.User_has_birds.Add(newBird);
                _birdContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

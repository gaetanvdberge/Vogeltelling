using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vogeltelling.Web.Models;

namespace Vogeltelling.Web.Repositories
{
    public interface ITellerRepository
    {
        IEnumerable<Moments> GetAllMoments();
        IEnumerable<Provincie> GetAllProvincies();
        Boolean BirdCountAdded(User_has_birds newBird);
    }
}

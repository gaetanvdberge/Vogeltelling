using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vogeltelling.Web.Models;

namespace Vogeltelling.Web.Repositories
{
    public interface IBirdRepository
    {
        IEnumerable<Bird> GetAllBirds();
        Bird GetBirdById(Guid birdId);
        Boolean EditBird(Bird bird);
        Boolean CreateBird(Bird bird);
        Boolean DeleteBird(Guid birdId);
    }
}

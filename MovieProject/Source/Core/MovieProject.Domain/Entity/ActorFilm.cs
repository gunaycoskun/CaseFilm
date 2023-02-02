using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.Entity
{
    public class ActorFilm
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
    }
}

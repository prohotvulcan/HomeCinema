using System.Collections.Generic;

namespace homeCinema.Data.Entities
{
    public class Genre : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public Genre()
        {
            Movies = new List<Movie>();
        }
    }
}

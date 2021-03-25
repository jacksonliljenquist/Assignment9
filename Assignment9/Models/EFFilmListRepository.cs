using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class EFFilmListRepository : IFilmRepository
    {
        private FilmListDbContext _context;
        public EFFilmListRepository (FilmListDbContext context)
        {
            _context = context;
        }

        public IQueryable<FilmInfo> FilmInfo => _context.FilmInfo;
    }
}

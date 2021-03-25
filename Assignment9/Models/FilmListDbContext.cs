using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class FilmListDbContext : DbContext
    {
        public FilmListDbContext(DbContextOptions<FilmListDbContext> options) : base(options)
        {

        }

        public DbSet<FilmInfo> FilmInfo { get; set; }
    
    }
}

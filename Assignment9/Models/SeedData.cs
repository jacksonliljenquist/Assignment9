using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            FilmListDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.
                GetRequiredService<FilmListDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.FilmInfo.Any())
            {
                context.FilmInfo.AddRange(
                    new FilmInfo
                    {

                    }
                    
                );

            }
        }
    }
}

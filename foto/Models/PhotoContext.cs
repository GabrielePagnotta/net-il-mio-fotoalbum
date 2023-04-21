using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace foto.Models
{
    public class PhotoContext:IdentityDbContext<IdentityUser>
    {
       
        public PhotoContext(DbContextOptions<PhotoContext> options) : base(options) { }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; } 

        public void Seed()
        {
            var seed = new Photo[]
            {
                new()
                {
                    Title="Foto 1",
                    Description="descrizione 1",
                    ImageUrl="https://picsum.photos/id/8/200/300",
                    Visibile=true
                },

                new()
                {
                    Title="Foto 2",
                    Description="descrizione 2",
                    ImageUrl="https://picsum.photos/id/6/200/300",
                    Visibile=true
                },
                new()
                {
                    Title="Foto 3",
                    Description="descrizione 3",
                    ImageUrl="https://picsum.photos/id/2/200/300",
                    Visibile=true
                }
            };

            if(!Photos.Any() ) 
            {
                Photos.AddRange(seed);
            }

            if(!Categories.Any() )
            {
                var seedc = new Category[]
                {
                    new()
                    {
                        Name="Natura"
                    },
                    new()
                    {
                        Name="Città"
                    },
                    new()
                    {
                        Name="Montagna"
                    }
                };

                Categories.AddRange(seedc);
                SaveChanges();
            }
        }
    }
}

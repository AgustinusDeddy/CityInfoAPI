using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPI.Entities
{
    public class CityInfoContextInitializer : ICityInfoContextInitializer
    {
        private readonly CityInfoContext _context;

        public CityInfoContextInitializer(CityInfoContext context)
        {
            _context = context;
        }

        public bool EnsureCreated()
        {
            return _context.Database.EnsureCreated();
        }

        public void Migrate()
        {
            _context.Database.Migrate();
        }

        public async Task Seed()
        {
            // clear for demo purposes
            _context.Cities.RemoveRange(_context.Cities);
            _context.SpotTypes.RemoveRange(_context.SpotTypes);

            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (Cities, reseed, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT (Spots, reseed, 0)");
            _context.SaveChanges();

            // seed data

            var spotTypes = new List<SpotType>()
            {
                new SpotType()
                {
                    Id = 1,
                    Name = "Cultural"
                },
                new SpotType()
                {
                    Id = 2,
                    Name = "Beach"
                },
                new SpotType()
                {
                    Id = 3,
                    Name = "Culinary"
                },
                new SpotType()
                {
                    Id = 4,
                    Name = "Hills"
                }
            };

            _context.SpotTypes.AddRange(spotTypes);
            _context.SaveChanges();

            var cities = new List<City>()
            {
                new City()
                {
                    //Id = 1,
                    Name = "Yogyakarta",
                    Spots = new List<Spot>()
          {
            new Spot()
            {
              //Id = 1,
              Name = "Candi Prambanan",
              SpotTypeId = 1,
              Description = "A UNESCO World Heritage Site and one of the largest Hindhu temple in South East Asia.",
              PreviewImage = "prambanan_1.jpg"
            },
            new Spot()
            {
              //Id = 2,
              Name = "Timang Beach",
              SpotTypeId = 2,
              Description = "A white sand beach with a gondola to take you across the sea.",
                PreviewImage = "timang_1.jpg"
            },
            new Spot()
            {
              //Id = 3,
              Name = "Klangon Hill",
              SpotTypeId = 4,
              Description = "Enjoy the beauth of Merapifrom the highest village in Sleman.",
              PreviewImage = "klangon_1.jpg"
            },
            new Spot()
            {
              //Id = 4,
              Name = "Ratu Boko",
              SpotTypeId = 4,
              Description = "A remains of a palace, with a breathtaking sunset.",
              PreviewImage = "ratuboko_1.jpg"
            },
            new Spot()
            {
              //Id = 5,
              Name = "Pengilon Hill",
              SpotTypeId = 4,
              Description = "Hills with green grass and view of Indian Ocean.",
              PreviewImage = "pengilon_1.jpg"
            },
            new Spot()
            {
              //Id = 6,
              Name = "Angkringan Lik Man",
              SpotTypeId = 3,
              Description = "A place to enjoy \"Kopi Joss\" and spend time with friends",
              PreviewImage = "likman_1.jpg"
            },
            new Spot()
            {
              //Id = 7,
              Name = "Abhayagiri Restaurant",
              SpotTypeId = 3,
              Description = "Restaurant with amazing view of Merapi and Prambanan Temple.",
              PreviewImage = "abhayagiri_1.jpg"
            },
            new Spot()
            {
              //Id = 8,
              Name = "Jejamuran",
              SpotTypeId = 3,
              Description = "A restaurant with menus that use mushroom as main ingredient.",
              PreviewImage = "jejamuran_1.jpg"
            }
          }
        },
        new City()
        {
          //Id = 2,
          Name = "Bali",
          Spots = new List<Spot>()
          {
            new Spot()
            {
              //Id = 9,
              Name = "Tanjung Benoa",
              SpotTypeId = 2,
              Description = "A beach that offer water sports and range of different activities."
            },
            new Spot()
            {
              //Id = 10,
              Name = "Tanah Lot Temple",
              SpotTypeId = 1,
              Description = "A Hindu temple that sits on top of large and scenic rock formation. "
            },
            new Spot()
            {
              //Id = 11,
              Name = "Uluwatu Temple",
              SpotTypeId = 1,
              Description = "A temple stand 70 meters above the sea with a view overlooking the raging waters below."
            }
          }
        }
      };
            _context.Cities.AddRange(cities);
            _context.SaveChanges();
        }
    }

    public interface ICityInfoContextInitializer
    {
        bool EnsureCreated();
        void Migrate();
        Task Seed();
    }
}

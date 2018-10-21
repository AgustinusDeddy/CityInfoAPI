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
              Explanation = "Prambanan Temple is a 9th-century Hindu temple compound in Central Java, Indonesia, dedicated to the Trimurti, the expression of God as the Creator (Brahma), the Preserver (Vishnu) and the Transformer (Shiva). The temple compound is located approximately 17 kilometres (11 mi) northeast of the city of Yogyakarta on the boundary between Central Java and Yogyakarta provinces.",
              PreviewImage = "prambanan_1.jpg"
            },
            new Spot()
            {
              //Id = 2,
              Name = "Timang Beach",
              SpotTypeId = 2,
              Description = "A white sand beach with a gondola to take you across the sea.",
              Explanation = "Timang beach is a beach attraction is a region at the boundary between the sea and the land that is located in Gunungkidul, Yogyakarta, Indonesia. The uniqueness of this beach is that there is an island called Panjang Island which is lobster habitat across coastal marine",
              PreviewImage = "timang_1.jpg"
            },
            new Spot()
            {
              //Id = 3,
              Name = "Klangon Hill",
              SpotTypeId = 4,
              Description = "Enjoy the beauth of Merapifrom the highest village in Sleman.",
              Explanation = "Klangon is a Hill that is located right under the foot of Mount Merapi. Administratively located in the village of Galagaharjo, district Cangkringan, Sleman Regency, Yogyakarta special region. Arguably a bit scary location visitors, as it is located at the point of disaster-prone areas 3.",
              PreviewImage = "klangon_1.jpg"
            },
            new Spot()
            {
              //Id = 4,
              Name = "Ratu Boko",
              SpotTypeId = 4,
              Description = "A remains of a palace, with a breathtaking sunset.",
              Explanation = "Ratu Boko is an archaeological site in Java. Ratu Boko is located on a plateau, in Yogyakarta, Indonesia. The original name of this site is still unclear, however the local inhabitants named this site after King Boko, the legendary king mentioned in Loro Jonggrang folklore. In Javanese, Ratu Boko means \"Stork King\"",
              PreviewImage = "ratuboko_1.jpg"
            },
            new Spot()
            {
              //Id = 5,
              Name = "Pengilon Hill",
              SpotTypeId = 4,
              Description = "Hills with green grass and view of Indian Ocean.",
              Explanation = "Hills with green grass and on the south side is the vast sea. of and I realize how great is our God. Instagram-able for those who likes selfie.",
              PreviewImage = "pengilon_1.jpg"
            },
            new Spot()
            {
              //Id = 6,
              Name = "Angkringan Lik Man",
              SpotTypeId = 3,
              Description = "A place to enjoy \"Kopi Joss\" and spend time with friends",
              Explanation = "Angkringan is food stall selling rice, side dishes and drinks at very cheap prices. Angkringan Lik Man is serving special drink, namely Kopi Joss or Coffee Joss, this place once was the place for spending the night by some popular leaders of Indonesia.",
              PreviewImage = "likman_1.jpg"
            },
            new Spot()
            {
              //Id = 7,
              Name = "Abhayagiri Restaurant",
              SpotTypeId = 3,
              Description = "Restaurant with amazing view of Merapi and Prambanan Temple.",
              Explanation = "Abhayagiri Restaurant is a restaurant located in Sumberwatu Village, Prambanan. With a startling view of Mount Merapi, Prambanan and Sojiwan Temple. Serving variety of international menu with the freshest ingredients, Abhayagiri Restaurant will be the right choice of your culinary destination in Yogyakarta.",
              PreviewImage = "abhayagiri_1.jpg"
            },
            new Spot()
            {
              //Id = 8,
              Name = "Jejamuran",
              SpotTypeId = 3,
              Description = "A restaurant with menus that use mushroom as main ingredient.",
              Explanation = "Jejamuran restaurant was founded in 2006 by Ratidjo Hardjo Soewarno in an effort to sell the mushrooms are abundant of his mushroom cultivation. At the beginning ‘Jejamuran’ just a simple shop that was built in front of the house with a storefront and a lincak.",
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

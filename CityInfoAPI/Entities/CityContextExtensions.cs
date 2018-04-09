using System.Collections.Generic;

namespace CityInfoAPI.Entities
{
    public static class CityContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            // clear for demo purposes
            //context.Cities.RemoveRange(context.Cities);
            //context.SpotTypes.RemoveRange(context.SpotTypes);
            //context.SaveChanges();

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

            context.SpotTypes.AddRange(spotTypes);
            context.SaveChanges();

            var cities = new List<City>()
        {
          new City()
          {
            Id = 1,
            Name = "Yogyakarta",
            Spots = new List<Spot>()
            {
              new Spot()
              {
                Id = 1,
                Name = "Candi Prambanan",
                SpotTypeId = 1,
                Description = "A UNESCO World Heritage Site and one of the largest Hindhu temple in South East Asia."
              },
              new Spot()
              {
                Id = 2,
                Name = "Timang Beach",
                SpotTypeId = 2,
                Description = "A white sand beach with a gondola to take you across the sea."
              },
              new Spot()
              {
                Id = 3,
                Name = "Klangon Hill",
                SpotTypeId = 4,
                Description = "Enjoy the beauth of Merapifrom the highest village in Sleman."
              },
              new Spot()
              {
                Id = 4,
                Name = "Ratu Boko",
                SpotTypeId = 4,
                Description = "A remains of a palace, with a breathtaking sunset."
              },
              new Spot()
              {
                  Id = 5,
                  Name = "Pengilon Hill",
                  SpotTypeId = 4,
                  Description = "Hills with green grass and view of Indian Ocean."
              },
              new Spot()
              {
                  Id = 6,
                  Name = "Angkringan Lik Man",
                  SpotTypeId = 3,
                  Description = "A place to enjoy \"Kopi Joss\" and spend time with friends"
              },
              new Spot()
              {
                  Id = 7,
                  Name = "Abhayagiri Restaurant",
                  SpotTypeId = 3,
                  Description = "Restaurant with amazing view of Merapi and Prambanan Temple."
              },
              new Spot()
              {
                  Id = 8,
                  Name = "Jejamuran",
                  SpotTypeId = 3,
                  Description = "A restaurant with menus that use mushroom as main ingredient."
              }
            }
          },
          new City()
          {
            Id = 2,
            Name = "Bali",
            Spots = new List<Spot>()
            {
                new Spot()
                {
                    Id = 9,
                    Name = "Tanjung Benoa",
                    SpotTypeId = 2,
                    Description = "A beach that offer water sports and range of different activities."
                },
                new Spot()
                {
                    Id = 10,
                    Name = "Tanah Lot Temple",
                    SpotTypeId = 1,
                    Description = "A Hindu temple that sits on top of large and scenic rock formation. "
                },
                new Spot()
                {
                    Id = 11,
                    Name = "Uluwatu Temple",
                    SpotTypeId = 1,
                    Description = "A temple stand 70 meters above the sea with a view overlooking the raging waters below."
                }
            }
          }
        };
            
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}

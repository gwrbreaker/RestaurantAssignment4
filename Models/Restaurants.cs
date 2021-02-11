using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace RestaurantAssignment4.Models
{
    public class Restaurants
    {
        //For some reason I could not get the default values for nulls to show up so me and a TA added a bunch of code 
        //trying different things, and at this point I'm too afraid to get rid of any of it so I'm sorry if it's disorganized
        public string FavoriteDish { get; set; }
        //We set the default values before anything else because nothing was registering when it went through the model normally
        public Restaurants() {
            
            Website = "Coming Soon!";
            //FavoriteDish = "They're all Tasty!";
        }
        
        public Restaurants(int? rank)
        {
            RestaurantsRanking = rank ?? 1;
            
        }
        public string getName { get; set; }
        [Required]
        public int RestaurantsRanking { get; }
        [Required]
        public string RestaurantName { get; set; }
        
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Please Enter a Valid Phone Number")]
        public string Phone { get; set; }
        public string? Website { get; set; } = "Coming Soon.";
        //public string? FavoriteDish { get; set; } = "They're all tasty!";

        


    public static Restaurants[] GetRestaurants()
        {
            {
                Restaurants r1 = new Restaurants(1)
                {
                    RestaurantName = "Bombay House",
                    FavoriteDish = "Chicken Curma",
                    Address = "463 N University Ave, Provo, UT",
                    Phone = "8013736677",
                    Website = "www.bombayhouse.com"
                };

                Restaurants r2 = new Restaurants(2)
                {

                    RestaurantName = "Gurus",
                    FavoriteDish = "Sweet Potato Fries",
                    Address = "45 E Center St, Provo, UT",
                    Phone = "8013754878",
                    Website = "www.guruscafe.com"
                };

                Restaurants r3 = new Restaurants(3)
                {

                    RestaurantName = "DP Cheesesteaks",
                    FavoriteDish = "Provolone Mushroom CHessesteak",
                    Address = "1774 N University Pkwy, Provo, UT",
                    Phone = "8017092996",
                    Website = "www.dpcheesesteaks.com"
                };

                Restaurants r4 = new Restaurants(4)
                {

                    RestaurantName = "Rancheritos",
                    FavoriteDish = "California Burrito",
                    Address = "960 S University Ave, Provo, UT",
                    Phone = "8016910786",
                    Website = "https://rancheritosmexicanfood.business.site"
                };

                Restaurants r5 = new Restaurants(5)
                {

                    RestaurantName = "Station 22 Cafe",
                    FavoriteDish = "Roasted Pork Sandwich",
                    Address = "22 W Center St, Provo, UT",
                    Phone = "8016071803",
                    Website = "www.station22cafe.com"
                };

                return new Restaurants[] { r1, r2, r3, r4, r5 };
            }
        }
    }
}

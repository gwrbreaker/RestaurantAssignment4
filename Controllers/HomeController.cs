using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantAssignment4.Models;

namespace RestaurantAssignment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> RestaurantsList = new List<string>();

            foreach(Restaurants r in Restaurants.GetRestaurants())
            {
                int? RestaurantRanking = r.RestaurantsRanking;
                
                
                RestaurantsList.Add(string.Format("#{0}: {1} {2} {3} {4} {5}", r.RestaurantsRanking, r.RestaurantName, r.FavoriteDish, r.Address, r.Phone, r.Website));

            }

            return View(RestaurantsList);
        }
        [HttpGet]
        public IActionResult SubmitRestaurant()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitRestaurant(Restaurants restaurants)
        {
            if (ModelState.IsValid)
            {
                //All of the stuff below is the result of hours of troubleshooting with a TA because for some reason when I tried to set the null default value as 
                //what it has in the requirements, it would not register, so we had to make a whole new object and then make the assignments using that, then
                //I added if statements so that it would add in the values by default if they were null. We tried basically everything else but this was 
                //the only thing that worked
                Restaurants thisRestaurant = new Restaurants();
                thisRestaurant.Address = restaurants.Address;
                thisRestaurant.Phone = restaurants.Phone;
                
                thisRestaurant.RestaurantName = restaurants.RestaurantName;
                thisRestaurant.getName = restaurants.getName;

                if (restaurants.FavoriteDish != null ){ thisRestaurant.FavoriteDish = restaurants.FavoriteDish; }
                else { thisRestaurant.FavoriteDish = "They're all tasty!"; }

                if (restaurants.Website != null) { thisRestaurant.Website = restaurants.Website; }
                else { thisRestaurant.Website = "Coming Soon!"; }

                TempStorage.AddRestaurants(thisRestaurant);
                return View("Confirmation", thisRestaurant);
            }
            else
            {
                return View();
            }
            
        }
        
        public IActionResult RestaurantSubmitList()
        {
            return View(TempStorage.restaurants);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

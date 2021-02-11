using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAssignment4.Models
{
    public static class TempStorage
    {
        private static List<Restaurants> ReturnRestaurants = new List<Restaurants>();

        public static IEnumerable<Restaurants> restaurants => ReturnRestaurants;

        public static void AddRestaurants(Restaurants restaurants)
        {
            ReturnRestaurants.Add(restaurants);
        }
    }
}
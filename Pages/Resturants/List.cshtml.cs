using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFoodNew.Core;
using OdeToFoodNew.Data;

namespace OdeToFoodNew
{
    public class ListModel : PageModel
    {
        
        private readonly IConfiguration Config;
        private readonly IRestaurantData _restaurantData;

        public string Message { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Resturant> Resturants { get; set; }
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            Config = config;
            _restaurantData = restaurantData;
        }
        public void OnGet()
        {
            
            Message = Config["Message"];
            Resturants = _restaurantData.GetRestaurantsByName(SearchTerm);

        }
    }
}
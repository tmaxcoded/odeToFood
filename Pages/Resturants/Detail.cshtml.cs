using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodNew.Core;
using OdeToFoodNew.Data;

namespace OdeToFoodNew
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _iresturant;
        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestaurantData iresturant)
        {
            _iresturant = iresturant;
        }
        public Resturant Resturant { get; set; }

       
        public IActionResult OnGet(int restaurantId)
        {
            Resturant = new Resturant();
            Resturant = _iresturant.GetById(restaurantId);

            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
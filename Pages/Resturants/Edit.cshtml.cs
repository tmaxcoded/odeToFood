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
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _data;
        public Resturant _Restaurant { get; set; }

        public EditModel(IRestaurantData data)
        {
            _data = data;
        }
        public IActionResult OnGet(int restaurantId)
        {
              _Restaurant = _data.GetById(restaurantId);

            if(_Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
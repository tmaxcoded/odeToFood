using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFoodNew.Core;
using OdeToFoodNew.Data;

namespace OdeToFoodNew
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _data;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Resturant _Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData data, IHtmlHelper htmlHelper)
        {
            _data = data;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
              _Restaurant = _data.GetById(restaurantId);

            if(_Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }


        public IActionResult OnPost()
        {
            _Restaurant =_data.Update(_Restaurant);
            _data.Commit();
            return Page();
        }
    }
}
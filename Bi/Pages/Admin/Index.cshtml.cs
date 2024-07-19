using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Admin
{
    public class AdminModel : PageModel
    {
       
        public IActionResult OnGetBrandPartial()
        {
            return Partial("Brand/Index");
        }

        public IActionResult OnGetBrandPartialCreate()
        {
            return Partial("Brand/Create");
        }

        public IActionResult OnGetBrandPartialEdit()
        {
            return Partial("Brand/Update");
        }

        public IActionResult OnGetCategoryPartial()
        {
            return Partial("Category/Index");
        }

        public IActionResult OnGetCategoryPartialCreate()
        {
            return Partial("Category/Create");
        }

        public IActionResult OnGetCategoryPartialEdit()
        {
            return Partial("Category/Update");
        }

        public IActionResult OnGetUserPartial()
        {
            return Partial("User/Index");
        }

        public IActionResult OnGetUserPartialCreate()
        {
            return Partial("User/Create");
        }

        public IActionResult OnGetUserPartialEdit()
        {
            return Partial("User/Update");
        }

        public IActionResult OnGetOrderPartial()
        {
            return Partial("Order/Index");
        }

        public IActionResult OnGetOrderPartialCreate()
        {
            return Partial("Order/Create");
        }

        public IActionResult OnGetOrderPartialEdit()
        {
            return Partial("Order/Update");
        }

        public IActionResult OnGetProductPartial()
        {
            return Partial("Product/Index");
        }

        public IActionResult OnGetProductPartialCreate()
        {
            return Partial("Product/Create");
        }

        public IActionResult OnGetProductPartialEdit()
        {
            return Partial("Product/Update");
        }
    }
}

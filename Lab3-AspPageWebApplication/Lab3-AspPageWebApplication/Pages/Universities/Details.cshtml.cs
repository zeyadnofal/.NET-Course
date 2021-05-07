using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_AspPageWebApplication.Pages.Universities
{
    public class DetailsModel : PageModel
    {
        private readonly IManageUniversity manageUniversity;
        public University University { get; set; }
        public DetailsModel(IManageUniversity manageUniversity)
        {
            this.manageUniversity = manageUniversity;
        }
        public IActionResult OnGet(int universityID)
        {
            University = manageUniversity.GetUniversityByID(universityID);

            if(University == null)
            {
                return RedirectToPage("NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}

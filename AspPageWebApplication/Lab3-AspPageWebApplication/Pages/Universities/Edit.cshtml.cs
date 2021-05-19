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
    public class EditModel : PageModel
    {
        private readonly IManageUniversity manageUniversity;

        [BindProperty]
        public University University { get; set; }
        public EditModel(IManageUniversity manageUniversity)
        {
            this.manageUniversity = manageUniversity;
        }
        public void OnGet(int universityID)
        {
            University = manageUniversity.GetUniversityByID(universityID);
        }

        public IActionResult OnPost()
        {
            manageUniversity.EditUniversity(this.University);
            return RedirectToPage("./List");
        }
    }
}

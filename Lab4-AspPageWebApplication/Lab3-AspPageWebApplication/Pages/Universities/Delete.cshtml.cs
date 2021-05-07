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
    public class DeleteModel : PageModel
    {
        private readonly IManageUniversity manageUniversity;

        public University University { get; set; }
        public DeleteModel(IManageUniversity manageUniversity)
        {
            this.manageUniversity = manageUniversity;
        }
        public void OnGet(int universityID)
        {
            University = manageUniversity.GetUniversityByID(universityID);
        }


        public IActionResult OnPost(int universityID)
        {
            manageUniversity.DeleteUniversity(universityID);
            return RedirectToPage("./List");
        }
    }
}

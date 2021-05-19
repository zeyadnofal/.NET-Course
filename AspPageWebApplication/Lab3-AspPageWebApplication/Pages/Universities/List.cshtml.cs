using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Lab3_AspPageWebApplication.Pages.Universities
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IManageUniversity manageUniversity;
        public string Message { get; set; }

        [BindProperty(SupportsGet =true)]

        public string universityName { get; set; }
        public List<University> Universities { get; set; }
        public ListModel(IConfiguration config, IManageUniversity manageUniversity)
        {
            this.config = config;
            this.manageUniversity = manageUniversity;
        }
        public void OnGet()
        {
            if(this.universityName == null)
            {
                Universities = manageUniversity.GetUniversities();
            }
            else
            {
                Universities = manageUniversity.GetUniversitiesByName(this.universityName);
            }
        }
    }
}

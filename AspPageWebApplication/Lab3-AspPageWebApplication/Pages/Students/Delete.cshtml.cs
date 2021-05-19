using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageStudent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_AspPageWebApplication.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IManageStudent managestudent;

        public StudentDTO Student { get; set; }
        public int UniversityID { get; set; }

        public DeleteModel(IManageStudent managestudent)
        {
            this.managestudent = managestudent;
        }
        public IActionResult OnGet(int StudentID)
        {
            Student = managestudent.GetStudentByID(StudentID);

            if (Student != null)
            {
                UniversityID = Student.UniversityID;
                return Page();
            }
            else
            {
                return RedirectToPage("../Universities/NotFound");
            }
        }

        public IActionResult OnPost(int StudentID)
        {
            managestudent.DeleteStudent(StudentID);
            return RedirectToPage("../Universities/List");
        }
    }
}

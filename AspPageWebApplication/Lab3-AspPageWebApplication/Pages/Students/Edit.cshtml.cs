using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageStudent;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_AspPageWebApplication.Pages.Students
{
    public class EditModel : PageModel
    {

        private readonly IManageStudent managestudent;
        private readonly IManageUniversity manageuniversity;

        [BindProperty]
        public StudentDTO Student { get; set; }
        public int UniversityID { get; set; }

        public EditModel(IManageStudent managestudent, IManageUniversity manageuniversity)
        {
            this.managestudent = managestudent;
            this.manageuniversity = manageuniversity;
        }
        public IActionResult OnGet(int? UniversityID, int StudentID)
        {

            if (UniversityID.HasValue)
            {
                var uni = manageuniversity.GetUniversityByID(UniversityID.Value);

                if (uni != null)
                {
                    this.UniversityID = UniversityID.Value;
                    Student = new StudentDTO();
                    return Page();
                }
                else
                {
                    return RedirectToPage("../Universities/NotFound");
                }

            }
            else
            {
                Student = managestudent.GetStudentByID(StudentID);

                if (Student != null)
                {
                    this.UniversityID = Student.UniversityID;
                    return Page();
                }
                else
                {
                    return RedirectToPage("../Universities/NotFound");
                }
            }

        }

        public IActionResult OnPost(int UniversityID)
        {
            if (ModelState.IsValid)
            {
                if (this.Student.ID > 0)
                {
                    managestudent.EditStudent(Student);
                }
                else
                {
                    managestudent.AddStudent(Student, UniversityID);
                }

                return RedirectToPage("../Universities/List");
            }
            else
            {
                return Page();
            }
        }
    }
}

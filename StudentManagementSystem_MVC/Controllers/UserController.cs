using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem_MVC.Controllers
{
    public class UserController : Controller
    {
        StudentManagementSystemContext db;
        public UserController(StudentManagementSystemContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.CollegeId = new SelectList(db.Colleges, "Id", "Name");
           
            return View();
        }


        [HttpPost]
        public IActionResult Register(StudentRegistration student)
        {
            var result = db.StudentRegistrations.FirstOrDefault(u => u.Id == student.Id);
            if (result == null)
            {
                db.StudentRegistrations.Add(student);
                db.SaveChanges();
                ViewBag.Message = "User Registered Succesfully";
            }
            else
            {
                ViewBag.Message = "UserID Already Registered";
            }
            return View();
        }

        [HttpGet]
        public IActionResult StudentLogin()
        {
            ViewBag.Message = "";
            return View();
        }


        [HttpPost]
        public IActionResult StudentLogin(StudentRegistration student)
        {
            var result = db.StudentRegistrations.FirstOrDefault(u => u.Username == student.Username && u.Password == student.Password);
            if (result != null)
            {
               
                ViewBag.Message = "User Login Succesfully";
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }
            return View();
        }
    }
}

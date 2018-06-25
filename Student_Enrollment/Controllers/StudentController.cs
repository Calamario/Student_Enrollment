using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Enrollment.Data;
using Student_Enrollment.Models;

namespace Student_Enrollment.Controllers
{
    public class StudentController : Controller
    {
        private EnrollmentDbContext _context;

        public StudentController(EnrollmentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Courses"] = await _context.Course.Select(c => c).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, ID, CourseId, Passing, HoursOfSleep")]Student student)
        {
            student.Course = await _context.Course.Where(c => c.ID == student.CourseId).SingleAsync();

            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ViewAll()
        {
            var data = await _context.Student.Include(s => s.Course).ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();

                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id.HasValue)
            {
                ViewData["Courses"] = await _context.Course.Select(c => c).ToListAsync();
                Student student = await _context.Student.FirstOrDefaultAsync(a => a.ID == id);
                return View(student);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            _context.Student.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
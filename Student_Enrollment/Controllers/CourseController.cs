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
    public class CourseController : Controller
    {
        private EnrollmentDbContext _context;

        public CourseController(EnrollmentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID, ClassName, StartingDate, EndDate, Instructor")]Course course)
        {
            await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();

            int id = course.ID;
            return View();
        }

        public async Task<IActionResult> ViewAll()
        {
            var data = await _context.Course.ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id.HasValue)
            {
                return View(await CourseDetailViewModel.FromIDAsync(id.Value, _context));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id.HasValue)
            {
                Course course = await _context.Course.FirstOrDefaultAsync(a => a.ID == id);
                return View(course);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
            _context.Course.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int? id)
        {

        }
    }
}
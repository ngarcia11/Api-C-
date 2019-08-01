﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorlanGarciaWA.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorlanGarciaWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly CourseContext _context;

        public CourseController(CourseContext context)
        {
            _context = context;
            if (_context.Courses.Count() == 0)
            {
                var CourseEx = new Course
                {
                    Name = "Curso de Prueba",
                    Duration = 120,
                    InstructorName = "Norlan Garcia",
                    IsActive = true

                };
                _context.Courses.Add(CourseEx);
                _context.SaveChanges();


            }
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task <ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await  _context.Courses.ToListAsync();
        }
        [HttpGet ("{id}")]

        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
                return course;
            
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
        }
    }

}


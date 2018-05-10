using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EReviewer.Data;
using EReviewer.Models;
using EReviewer.ViewModels.ExamTypeViewModels;

namespace EReviewer.Controllers
{
    public class ExamTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Map the Examtype Model to the ExamTypeViewVM
            List<ExamTypeViewVM> model = new List<ExamTypeViewVM>();
            model = await _context.ExamTypes.Select(u => new ExamTypeViewVM
            {
                Id = u.Id,
               
                Name = u.Name,
              
            }).ToListAsync();

            return View(model);
        }

        // GET: ExamType/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: ExamType/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ExamTypeAddVM model)
        {
            if (ModelState.IsValid)
            {
                // Map the ExamTypeAddVM to the ExamType Model
                var examtype = new ExamType
                {
                    
                    Name = model.Name,
                    
                };

                // Add examtpe in the Examtype Table
                _context.Add(examtype);

                // Save all changes in the databse
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: ExamType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get examtype by id
            var examType = await _context.ExamTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (examType == null)
            {
                return NotFound();
            }

            // Map the ExamType Model to the ExamTypeViewVM
            var model = new ExamTypeViewVM()
            {
                Id = examType.Id,
                
                Name = examType.Name,
                
            };

            return View(model);
        }

        // POST: ExamType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Get examtype by id
            var examType = await _context.ExamTypes.SingleOrDefaultAsync(m => m.Id == id);

            // Delete examtype in the ExamType Table
            _context.ExamTypes.Remove(examType);

            // Save all changes in the database
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            // Check if the ExamType exist
            return _context.ExamTypes.Any(e => e.Id == id);
        }


    }
}
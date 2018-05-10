using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EReviewer.Data;
using EReviewer.Models;
using EReviewer.ViewModels.SubjectViewModels;

/// <summary>
/// A controller is used to define and group a set of actions.
/// </summary>
namespace EReviewer.Controllers
{
    public class SubjectController : Controller
    {
        /// <summary>
        /// A DbContext instance represents a session with the database and
        /// can be used to query and save instances of your entities.
        /// </summary>
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// An action (or action method) is a method on a controller which handles requests. 
        /// </summary>
        /// <returns></returns>
        // GET: Subject
        public async Task<IActionResult> Index()
        {
            // Map the Subject Model to the SubjectViewVM
            List<SubjectViewVM> model = new List<SubjectViewVM>();
            model = await _context.Subjects.Select(u => new SubjectViewVM
            {
                Id = u.Id,
                Code = u.Code,
                Name = u.Name,
                Description = u.Description,
            }).ToListAsync();

            return View(model);
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .SingleOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            // Map the Subject Model to the SubjectViewVM
            var model = new SubjectViewVM()
            {
                Id = subject.Id,
                Code = subject.Code,
                Name = subject.Name,
                Description = subject.Description
            };

            return View(model);
        }

        // GET: Subject/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: Subject/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(SubjectAddVM model)
        {
            if (ModelState.IsValid)
            {
                // Map the SubjectAddVM to the Subject Model
                var subject = new Subject
                {
                    Code = model.Code,
                    Name = model.Name,
                    Description = model.Description
                };

                // Add a subject in the Subject Table
                _context.Add(subject);

                // Save all changes in the databse
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get a subject by id
            var subject = await _context.Subjects.SingleOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            // Map the SubjectEditVM to the Subject Model
            var model = new SubjectEditVM()
            {
                Id = subject.Id,
                Code = subject.Code,
                Name = subject.Name,
                Description = subject.Description
            };

            return View(model);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubjectEditVM model)
        {
            if (ModelState.IsValid)
            {
                // Get a subject by id
                var subject = await _context.Subjects.SingleOrDefaultAsync(m => m.Id == model.Id);

                try
                {
                    if (subject == null)
                    {
                        return NotFound();
                    }

                    // Map the SubjectEditVM to the Subject Model
                    subject.Id = model.Id;
                    subject.Code = model.Code;
                    subject.Name = model.Name;
                    subject.Description = model.Description;

                    // Update a subject in the Subject Table
                    _context.Update(subject);

                    // Save all changes in the database
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get a subject by id
            var subject = await _context.Subjects.SingleOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            // Map the Subject Model to the SubjectViewVM
            var model = new SubjectViewVM()
            {
                Id = subject.Id,
                Code = subject.Code,
                Name = subject.Name,
                Description = subject.Description
            };

            return View(model);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Get a subject by id
            var subject = await _context.Subjects.SingleOrDefaultAsync(m => m.Id == id);

            // Delete a subject in the Subject Table
            _context.Subjects.Remove(subject);

            // Save all changes in the database
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            // Check if the subject exist
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}

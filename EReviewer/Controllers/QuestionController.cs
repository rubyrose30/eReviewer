using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EReviewer.Data;
using EReviewer.Models;
using EReviewer.ViewModels.QuestionViewModels;

namespace EReviewer.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            var model = new List<QuestionViewVM>();
            model = await _context.Question.Include(q => q.ExamType).Include(q => q.Subject).Select(q => new QuestionViewVM()
            {
                Subject = q.Subject.Name,
                ExamType = q.ExamType.Name,
                Question = q.QuestionText,
                Points = q.Points,
                Answer = string.IsNullOrWhiteSpace(q.AnswerText) ? q.Answer.Description : q.AnswerText,
                Options = q.Options.Select(opt => new QuestionOptionViewVM()
                {
                    Description = opt.Description,
                    IsAnswer = opt.IsAnswer
                }).ToList()

            }).ToListAsync();

            return View(model);
        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.ExamType)
                .Include(q => q.Subject)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            var model = new QuestionViewVM()
            {
                Id = question.Id,
                Subject = question.Subject.Name,
                ExamType = question.ExamType.Name,
                Points = question.Points,
                Answer = string.IsNullOrWhiteSpace(question.AnswerText) ? question.Answer.Description : question.AnswerText,
                Options = question.Options.Select(opt => new QuestionOptionViewVM()
                {
                    Description = opt.Description,
                    IsAnswer = opt.IsAnswer
                }).ToList()
            };

            return View(model);
        }

        // GET: Question/Add
        public IActionResult Add()
        {
            var model = new QuestionAddVM()
            {
                ExamTypes = new SelectList(_context.ExamTypes, "Id", "Name"),
                Subjects = new SelectList(_context.Subjects, "Id", "Name")
            };

            return View(model);
        }

        // POST: Question/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(QuestionAddVM model)
        {
            if (ModelState.IsValid)
            {
                //var options = new List<QuestionOption>();
                //foreach (var item in model.Options)
                //{
                //    options.Add(new QuestionOption()
                //    {
                //        Description = item.Description,
                //        IsAnswer = item.IsAnswer
                //    });
                //}

                var question = new Question
                {
                    ExamTypeId = model.ExamTypeId,
                    SubjectId = model.ExamTypeId,
                    QuestionText = model.Question,
                    Points = model.Points,
                    AnswerText = model.Answer,
                    //QuestionOptions = options,
                    Options = model.Options.Select(opt => new QuestionOption()
                    {
                        Description = opt.Description,
                        IsAnswer = opt.IsAnswer
                    }).ToList()
                };

                _context.Add(question);

                //AnswerId = model.AnswerId, //TODO: add answerid after options has been added

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            model.ExamTypes = new SelectList(_context.ExamTypes, "Id", "Name", model.ExamTypeId);
            model.Subjects = new SelectList(_context.Subjects, "Id", "Name", model.SubjectId);

            return View(model);
        }

        // GET: Question/AddOptions
        public IActionResult AddOptions()
        {
            var model = new QuestionAddVM()
            {
                ExamTypes = new SelectList(_context.ExamTypes, "Id", "Name"),
                Subjects = new SelectList(_context.Subjects, "Id", "Name")
            };

            return View(model);
        }

        // POST: Question/AddOptions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOptions(QuestionAddVM model)
        {
            if (ModelState.IsValid)
            {
                //var options = new List<QuestionOption>();
                //foreach (var item in model.Options)
                //{
                //    options.Add(new QuestionOption()
                //    {
                //        Description = item.Description,
                //        IsAnswer = item.IsAnswer
                //    });
                //}

                var question = new Question
                {
                    ExamTypeId = model.ExamTypeId,
                    SubjectId = model.ExamTypeId,
                    QuestionText = model.Question,
                    Points = model.Points,
                    AnswerText = model.Answer,
                    //QuestionOptions = options,
                    Options = model.Options.Select(opt => new QuestionOption()
                    {
                        Description = opt.Description,
                        IsAnswer = opt.IsAnswer
                    }).ToList()
                };

                _context.Add(question);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            model.ExamTypes = new SelectList(_context.ExamTypes, "Id", "Name", model.ExamTypeId);
            model.Subjects = new SelectList(_context.Subjects, "Id", "Name", model.SubjectId);

            return View(model);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.SingleOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            //var options = new List<QuestionOptionEditVM>();
            //foreach (var item in question.QuestionOptions)
            //{
            //    options.Add(new QuestionOptionEditVM()
            //    {
            //        Id = item.Id,
            //        Description = item.Description,
            //        IsAnswer = item.IsAnswer
            //    });
            //}

            var model = new QuestionEditVM()
            {
                Id = question.Id,
                Question = question.QuestionText,
                Points = question.Points,
                Answer = question.AnswerText,
                //Options = options;
                Options = question.Options.Select(opt => new QuestionOptionEditVM()
                {
                    Id = opt.Id,
                    Description = opt.Description,
                    IsAnswer = opt.IsAnswer
                }).ToList(),
                ExamTypes = new SelectList(_context.ExamTypes, "Id", "Name", question.ExamTypeId),
                Subjects = new SelectList(_context.Subjects, "Id", "Name", question.SubjectId)
            };

            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuestionEditVM model)
        {
            if (ModelState.IsValid)
            {
                var question = await _context.Question.SingleOrDefaultAsync(m => m.Id == model.Id);

                try
                {
                    if (null == question)
                    {
                        return NotFound();
                    }

                    //var options = new List<QuestionOption>();
                    //foreach (var item in model.Options)
                    //{
                    //    options.Add(new QuestionOption() {
                    //        Description = item.Description,
                    //        IsAnswer = item.IsAnswer
                    //    });
                    //}

                    question.Id = model.Id;
                    question.QuestionText = model.Question;
                    question.AnswerText = model.Answer;
                    //question.QuestionOptions = options;
                    question.Options = model.Options.Select(opt => new QuestionOption()
                    {
                        Description = opt.Description,
                        IsAnswer = opt.IsAnswer
                    }).ToList();
                    question.AnswerId = model.Options.SingleOrDefault(id => id.IsAnswer).Id;

                    _context.Update(question);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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

            model.ExamTypes = new SelectList(_context.ExamTypes, "Id", "Name", model.ExamTypeId);
            model.Subjects = new SelectList(_context.Subjects, "Id", "Name", model.SubjectId);

            return View(model);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.ExamType)
                .Include(q => q.Subject)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            var model = new QuestionViewVM()
            {
                Id = question.Id,
                Subject = question.Subject.Name,
                ExamType = question.ExamType.Name,
                Points = question.Points,
                Answer = string.IsNullOrWhiteSpace(question.AnswerText) ? question.Answer.Description : question.AnswerText,
                Options = question.Options.Select(opt => new QuestionOptionViewVM()
                {
                    Description = opt.Description,
                    IsAnswer = opt.IsAnswer
                }).ToList()
            };

            return View(model);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.SingleOrDefaultAsync(m => m.Id == id);

            _context.Question.Remove(question);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }
}

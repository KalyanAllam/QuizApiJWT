using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApiJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace QuizApiJWT
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly JkoatuolContext _context;

        public QuestionsController(JkoatuolContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            return await _context.Questions.ToListAsync();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }


        

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.Sno == id)).GetValueOrDefault();
        }
    }
}

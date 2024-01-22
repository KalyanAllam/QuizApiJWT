using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApiJWT.Models;

namespace QuizApiJWT
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsOksController : ControllerBase
    {
        private readonly JkoatuolContext _context;

        public QuestionsOksController(JkoatuolContext context)
        {
            _context = context;
        }

        // GET: api/QuestionsOks
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<QuestionsOk>>> GetQuestionsOks()
        {
          if (_context.QuestionsOks == null)
          {
              return NotFound();
          }
            return await _context.QuestionsOks.ToListAsync();
        }

        // GET: api/QuestionsOks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionsOk>> GetQuestionsOk(int id)
        {
          if (_context.QuestionsOks == null)
          {
              return NotFound();
          }
            var questionsOk = await _context.QuestionsOks.FindAsync(id);

            if (questionsOk == null)
            {
                return NotFound();
            }

            return questionsOk;
        }

        // PUT: api/QuestionsOks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      
        private bool QuestionsOkExists(int id)
        {
            return (_context.QuestionsOks?.Any(e => e.Sno == id)).GetValueOrDefault();
        }
    }
}

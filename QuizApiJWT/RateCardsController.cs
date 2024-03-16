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
    public class RateCardsController : ControllerBase
    {
        private readonly JkoatuolContext _context;

        public RateCardsController(JkoatuolContext context)
        {
            _context = context;
        }

        // GET: api/RateCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateCard>>> GetRateCards()
        {
          if (_context.RateCards == null)
          {
              return NotFound();
          }
            return await _context.RateCards.ToListAsync();
        }

        // GET: api/RateCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RateCard>> GetRateCard(int id)
        {
          if (_context.RateCards == null)
          {
              return NotFound();
          }
            var rateCard = await _context.RateCards.FindAsync(id);

            if (rateCard == null)
            {
                return NotFound();
            }

            return rateCard;
        }

        
        private bool RateCardExists(int id)
        {
            return (_context.RateCards?.Any(e => e.No == id)).GetValueOrDefault();
        }
    }
}

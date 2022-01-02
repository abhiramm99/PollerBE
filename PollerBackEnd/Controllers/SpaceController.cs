using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollerBackEnd.Models;
using PollerBackEnd.Models.Content;
using PollerBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollerBackEnd.Controllers
{
    [ApiController]
    [Route("spaces")]
    public class SpaceController : ControllerBase
    {
        private readonly PollerDbContext _context;
        private readonly SpaceService _service;

        public SpaceController(PollerDbContext context, SpaceService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Space>> GetAllSpacesAsync()
        {
            return await _context.Space.Where(x => x.SpaceId > 0).ToListAsync();
        }

        [HttpGet("{spaceId}")]
        public async Task<Space> GetSpaceByIdAsync(int spaceId)
        {
            var result = await _context.Space.FindAsync(spaceId);

            return result;
        }

        [HttpGet("search/{keyWord}")]
        public async Task<IEnumerable<Space>> SearchSpacesAsync(string keyWord)
        {
            return await _service.SearchSpaceByKeyWordAsync(keyWord);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewSpaceAsync(Space space)
        {
            try
            {
                await _service.AddNewSpaceAsync(space);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
            return Ok(space);
        }
    }
}
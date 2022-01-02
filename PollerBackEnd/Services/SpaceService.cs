using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollerBackEnd.Models;
using PollerBackEnd.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollerBackEnd.Services
{
    public class SpaceService
    {
        private readonly PollerDbContext _context;

        public SpaceService(PollerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Space>> SearchSpaceByKeyWordAsync(string keyWord)
        {
            var results = await _context.Space.Where(x => x.SpaceName.ToLower().Contains(keyWord.ToLower())).ToListAsync();

            return results;
        }

        public async Task AddNewSpaceAsync(Space space)
        {
            if (CheckIfSpaceNameIsAvailable(space.SpaceName))
            {
                _context.Space.Add(space);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("This space already exists");
            }
        }

        #region Private Methods
        private bool CheckIfSpaceNameIsAvailable(string name)
        {
            var space = _context.Space.Where(x => x.SpaceName == name).FirstOrDefault();
            return space == null;
        }

        #endregion

    }
}
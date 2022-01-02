using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollerBackEnd.Models;
using PollerBackEnd.Models.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PollerBackEnd.Services.Core
{
    public class SignUpService
    {
        private readonly PollerDbContext _context;

        public SignUpService(PollerDbContext context)
        {
            _context = context;
        }

        public async Task RegisterNewUserAsync(User user)
        {
            if(await CheckIfUserAlreadyExistsAsync(user.Email))
            {
                throw new Exception("User already exists. Please sign in instead");
            }
            else
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
            }
        }

        #region Private Methods

        private async Task<bool> CheckIfUserAlreadyExistsAsync(string email)
        {
            var user = await _context.User.Where(x => x.Email == email).FirstOrDefaultAsync();
            return user != null;
        }

        #endregion
    }
}
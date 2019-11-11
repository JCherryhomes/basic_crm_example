using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CRM_Example.Data;
using CRM_Example.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace CRM_Example
{
    public class ApplicationProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _dbContext;

        public ApplicationProfileService(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);
            var userClaims = _dbContext.UserClaims
                .Where(uc => uc.UserId == user.Id)
                .Distinct()
                .Select(claim => new Claim(claim.ClaimType, claim.ClaimValue));

            context.IssuedClaims.AddRange(userClaims.ToList());
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null);
        }
    }
}
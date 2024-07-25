using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using NetCoreWebsitesBL.Models;
using Microsoft.Extensions.Logging;
using NetCoreWebsitesBL.Data;
using Microsoft.EntityFrameworkCore;

namespace NetCoreWebsitesBL.Common
{
    public class MyApplication
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<MyApplication> _logger;

        public MyApplication(IHttpContextAccessor accessor, IServiceScopeFactory scopeFactory, ILogger<MyApplication> logger)
        {
            _accessor = accessor;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public static async Task<Usuario?> FindUserByEmailAsync(IServiceScopeFactory scopeFactory, string email)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
                return await userManager.FindByEmailAsync(email);
            }
        }

        public static async Task<SignInResult> ValidateUserCredentialsAsync(IServiceScopeFactory scopeFactory, string email, string password, SignInManager<Usuario> signInManager)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
                var user = await userManager.FindByEmailAsync(email);
                if (user != null && user.PasswordHash != null)
                {
                    var passwordHasher = new PasswordHasher<Usuario>();
                    var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        return SignInResult.Success;
                    }
                }
            }

            return SignInResult.Failed;
        }
    }
}

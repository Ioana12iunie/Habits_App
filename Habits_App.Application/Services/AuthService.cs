using AutoMapper;
using Habits_App.Application.Interfaces.Repositories;
using Habits_App.Application.Interfaces.Services;
using Habits_App.Domain.Entities;
using Habits_App.Domain.Entities.Auth;
using Habits_App.Domain.Models;
using Habits_App.Habits_App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace Habits_App.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<User> userManager,
            SignInManager<User> signInManager, ITokenService tokenService, IUnitOfWork unitOfWork, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                return new LoginResult
                {
                    Success = false
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if (result.Succeeded)
            {
                var token = await _tokenService.CreateAccessToken(user);
                var refreshToken = _tokenService.CreateRefreshToken(user);

                _logger.LogInformation($"User with username {loginModel.Email} logged in!");

                return new LoginResult
                {
                    Success = true,
                    AccessToken = token,
                    RefreshToken = refreshToken
                };
            }

            return new LoginResult
            {
                Success = false
            };
        }

        public async Task<LoginResult> Refresh(string refreshToken)
        {
            var claimsPrincipal = _tokenService.GetPrincipalFromRefreshToken(refreshToken);


            var userId = claimsPrincipal.Identity.Name;

            var user = await _userManager.FindByNameAsync(userId);
            if (user == null)
            {
                return new LoginResult
                {
                    Success = false,
                };
            }

            var token = await _tokenService.CreateAccessToken(user);
            refreshToken = _tokenService.CreateRefreshToken(user);

            return new LoginResult
            {
                Success = true,
                AccessToken = token,
                RefreshToken = refreshToken
            };
        }

        public async Task RegisterAdmin(RegisterAdminModel registerModel)
        {
            var user = new User
            {
                Id = new Guid(),
                Email = registerModel.Email,
                UserName = registerModel.Username,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await this._userManager.AddToRoleAsync(user, registerModel.Role);
                _logger.LogInformation($"User {registerModel.Username} with {registerModel.Role} role was created!");
            }
            else
            {
                throw new Exception(String.Join(",", result.Errors.Select(x => x.Code)));
            }

        }

        public async Task Register(RegisterBasicUserModel registerModel) //UserProfileModelBasicUser RegisterBasicUserModel
        {
            var user = new User
            {
                Id = new Guid(),
                Email = registerModel.Email,
                UserName = registerModel.UserName,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await this._userManager.AddToRoleAsync(user, "BasicUser");
                _unitOfWork.SaveChangesAsync();

                _logger.LogInformation($"User {registerModel.UserName} with BasicUser role was created!");

            }
            else
            {
                throw new Exception(String.Join(",", result.Errors.Select(x => x.Code)));
            }


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential("habitssoftbinatorlabs2023@gmail.com", "ifftaaojerblgruh");
            // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.Subject = "Thank you for registering @Habits!";
            mail.Body = "<p>Hello,</p><br><p>Welcome to Habits!!!</p>";
            mail.IsBodyHtml = true;
            //Setting From , To and CC
            mail.From = new MailAddress("habitssoftbinatorlabs2023@gmail.com", "MyWeb Site");
            mail.To.Add(new MailAddress("habitssoftbinatorlabs2023@gmail.com"));
            //mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

            smtpClient.Send(mail);
        }
    }
}

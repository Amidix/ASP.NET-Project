﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using EnsatProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using static EnsatProject.Areas.Identity.Data.EnsatProjectUser;
using EnsatProject.Models;
using EnsatProject.Data;

namespace EnsatProject.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<EnsatProjectUser> _signInManager;
        private readonly UserManager<EnsatProjectUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly DataContext _context;

        public RegisterModel(
            UserManager<EnsatProjectUser> userManager,
            SignInManager<EnsatProjectUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
             DataContext context)
          
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mot de passe")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmation du mot de passe")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Nom")]
            public string Nom { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Prenom")]
            public string Prenom { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "CIN")]
            public string CIN { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "CNE")]
            public string CNE { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated )
            {
                Response.Redirect("/");
            }
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
       

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            

            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
               var user = new EnsatProjectUser { UserName = Input.Email, Email = Input.Email, Nom = Input.Nom,
                    Age = Input.Age,
                    Prenom = Input.Prenom,
                };
                var user2 = new Eleve
                {
                    MyRole = MyRole.eleve,
                    CIN = Input.CIN,
                    CNE = Input.CNE
                };

                _context.Add(user);
                _context.Add(user2);
                _context.SaveChanges();


                var result = await _userManager.CreateAsync(user, Input.Password);
                

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
              
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
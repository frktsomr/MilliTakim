using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilliTakim.Areas.Identity.Data;

namespace MilliTakim.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;

        public IndexModel(
            UserManager<AuthUser> userManager,
            SignInManager<AuthUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Display(Name = "E-mail")]
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Telefon Numarası")]
            [StringLength(10, ErrorMessage = "Lutfen telefon numaranizi dogru giriniz", MinimumLength = 10)]
            public string PhoneNumber { get; set; }

            [Display(Name = "Ad")]
            [RegularExpression("^([a-zA-Z]+\\s)*[a-zA-Z]+$", ErrorMessage = "Lutfen Gecerli Bir isim giriniz")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Lutfen Gecerli bir isim giriniz"), StringLength(20, ErrorMessage = "Lutfen Gecerli bir isim giriniz")]
            public string FirstName { get; set; }
            [Display(Name = "Soyad")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Lutfen Gecerli bir Soyadi giriniz"), StringLength(20, ErrorMessage = "Lutfen Gecerli bir Soyadi giriniz")]
            [RegularExpression("^([a-zA-Z]+\\s)*[a-zA-Z]+$", ErrorMessage = "Lutfen Gecerli Bir soyad giriniz")]
            public string LastName { get; set; }

            [Display(Name = "Profil Fotoğrafı")]
            public byte[] ProfilePicture { get; set; }

        }

        private async Task LoadAsync(AuthUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            var firstName = user.Ad;
            var lastName = user.Soyad;
            var profilePicture = user.ProfilePicture;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var firstName = user.Ad;
            var lastName = user.Soyad;
            if (Input.FirstName != firstName)
            {
                user.Ad = Input.FirstName;
                var adResult = await _userManager.UpdateAsync(user);
                if (!adResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set Ad.";
                    return RedirectToPage();
                }
            }
            if (Input.LastName != lastName)
            {
                user.Soyad = Input.LastName;
                var soyadResult = await _userManager.UpdateAsync(user);
                if (!soyadResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

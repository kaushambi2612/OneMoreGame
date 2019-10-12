using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneMoreGame.Models;

namespace OneMoreGame.Pages.omg
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public RegisterModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Player Player { get; set; }
        [TempData]
        public string Message { get; set; }

        public string[] PaymentMethods= {"GooglePay", "PhonePe", "Paytm", "Cash"};

        public void OnGet()
        {
            
        }
        //when the user clicks on register we will populate the db
        //making it asynchronous for more efficiency
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Players.Add(Player);
            await _db.SaveChangesAsync();
            Message = "Player registered successfully.";
            return RedirectToPage("Players");
        }
    }
}
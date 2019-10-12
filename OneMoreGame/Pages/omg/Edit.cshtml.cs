using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneMoreGame.Models;

namespace OneMoreGame.Pages.omg
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Player Player { get; set; }
        public string[] PaymentMethods = { "GooglePay", "PhonePe", "Paytm", "Cash" };
        [TempData]
        public string Message { get; set; }

        public async Task OnGet(int id)
        {
            //since we are returning the id from players razor page
            Player = await _db.Players.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var PlayerFromDb = await _db.Players.FindAsync(Player.Id);
                PlayerFromDb.Name = Player.Name;
                PlayerFromDb.Email = Player.Email;
                PlayerFromDb.Phone = Player.Phone;
                PlayerFromDb.Fifa20 = Player.Fifa20;
                PlayerFromDb.Tekken = Player.Tekken;
                PlayerFromDb.PubG = Player.PubG;
                PlayerFromDb.SelectedPaymentMethod = Player.SelectedPaymentMethod;

                await _db.SaveChangesAsync();
                Message = "Player updated successfully.";
                return RedirectToPage("Players");
            }

            return RedirectToPage(); //same page
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OneMoreGame.Models;

namespace OneMoreGame.Pages.omg
{
    public class PlayersModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public PlayersModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Player> Players { get; set; }
        [TempData]
        public string Message{ get; set; }

        public async Task OnGet()
        {
            Players = await _db.Players.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var player = await _db.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _db.Players.Remove(player);
            await _db.SaveChangesAsync();
            Message = "Player deleted successfully.";
            return RedirectToPage("Players");
        }
    }
}
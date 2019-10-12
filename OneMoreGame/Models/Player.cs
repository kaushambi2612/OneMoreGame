using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneMoreGame.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = " Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = " Fifa 20")]
        public bool Fifa20 { get; set; }
        public bool Tekken { get; set; }
        public bool PubG { get; set; }
        [Required]
        [Display(Name = "Payment Method")]
        public string SelectedPaymentMethod { get; set; }
        public int Total { get; set; }

    }

}

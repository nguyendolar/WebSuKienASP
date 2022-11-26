using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Models
{
    public class Information
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idInformation { get; set; }

        [StringLength(255)]
        [Required]
        public string name { get; set; }


        [StringLength(255)]
        [Required]
        public string email { get; set; }

        [StringLength(255)]
        public string phoneNumber { get; set; }

        public int idPosition { get; set; }

        public virtual Position Position { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }
    }
}
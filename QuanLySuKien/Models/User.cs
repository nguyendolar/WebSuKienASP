using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }

        [StringLength(255)]
        [Required]
        public string userName { get; set; }

        [StringLength(255)]
        [Required]
        public string password { get; set; }

        [StringLength(255)]
        [Required]
        public string role { get; set; }

        public virtual ICollection<Information> Informations { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
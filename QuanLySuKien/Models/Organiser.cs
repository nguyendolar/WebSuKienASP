using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Models
{
    public class Organiser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOrganiser { get; set; }

        [StringLength(255)]
        [Required]
        public string name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
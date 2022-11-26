using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEvent { get; set; }

        [StringLength(255)]
        [Required]
        public string name { get; set; }

        public string content { get; set; }

        public int status { get; set; }

        public DateTime date { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string participant { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }

        public int idGuest { get; set; }

        public virtual Guest Guest { get; set; }

        public int idCategory { get; set; }

        public virtual Category Category { get; set; }

        public int idOrganiser { get; set; }

        public virtual Organiser Organiser { get; set; }

        public int idCooperative { get; set; }

        public virtual Cooperative Cooperative { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
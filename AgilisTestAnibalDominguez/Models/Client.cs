using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgilisTestAnibalDominguez.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(24)]
        public string Address { get; set; }
        [ForeignKey("Company")]
        [Required]
        public int CompanyFK { get; set; }
        public Company Company { get; set; }
    }
}
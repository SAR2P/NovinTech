using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string Address { get; set; } = string.Empty;
    }
}

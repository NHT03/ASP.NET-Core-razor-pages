using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Core.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Column(TypeName ="nvarchar")]
        [Required]
        public String Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [StringLength(10)]
        [Column(TypeName ="nvarchar")]
        public string Phone { get; set; }

        [StringLength(255)]
        [Column(TypeName ="nvarchar")]
        public string Address { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

    }
}

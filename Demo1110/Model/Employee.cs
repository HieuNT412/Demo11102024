using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1110.Model
{
    public class Employee
    {
        [Key]
        [Column("EmployeeId")]
        public Guid Id {get; set;}

        [Required(ErrorMessage = "Employee name is a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Age is a required field")]
        public int Age {get; set;}

        [Required(ErrorMessage = "Position address is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters")]
        public string Position {get; set;}

        [ForeignKey(nameof(Company))]
        public Guid CompanyId {get; set;}

        public Company Company {get; set;}
    }
}
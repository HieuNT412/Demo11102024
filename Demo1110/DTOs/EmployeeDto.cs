using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1110.DTOs
{
    public class EmployeeDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public int Age {get; set;}
        public string Position {get; set;}
    }
}
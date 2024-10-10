using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1110.Model;

namespace Demo1110.DTOs
{
    public class CompanyForCreationDto : CompanyForManipulationDto
    {
        public IEnumerable<EmployeeForCreationDto> Employees {get; set;}
    }
}
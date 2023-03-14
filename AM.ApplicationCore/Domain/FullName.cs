using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "doit être >3"), MaxLength(25, ErrorMessage = " doit être <25")]
        public String FirstName { get; set; }
        public String LastName { get; set; }

    }
}

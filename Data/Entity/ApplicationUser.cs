using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public int? Age { get; set; }
        public ICollection<SurveyResult>? SurveyResults { get; set; }
    }
}

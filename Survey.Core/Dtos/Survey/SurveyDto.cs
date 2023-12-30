using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.Survey
{
    public class SurveyDto
    {

        [Required]
        public string Title { get; set; }
        public virtual ICollection<SurveyQuestionDto> SurveyQuestions { get; set; }
    }
}

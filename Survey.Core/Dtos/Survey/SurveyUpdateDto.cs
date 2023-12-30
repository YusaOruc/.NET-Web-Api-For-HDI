using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.Survey
{
    public class SurveyUpdateDto
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<SurveyQuestionUpdateDto> SurveyQuestions { get; set; }
    }
}

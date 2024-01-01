using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.Survey
{
    public class SurveyQuestionDto
    {
        public string Title { get; set; }
        public ICollection<SurveyQuestionOptionDto> SurveyQuestionOptions { get; set; }
        public int CorrectQuestionIndex { get; set; }
    }
}

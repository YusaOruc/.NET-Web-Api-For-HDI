using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.Survey
{
    public class SurveyQuestionUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<SurveyQuestionOptionUpdateDto> SurveyQuestionOptions { get; set; }
        public int? CorrectQuestionIndex { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.Survey
{
    public class SurveyQuestionOptionUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ExpandSurveyBaseId { get; set; }
    }
}

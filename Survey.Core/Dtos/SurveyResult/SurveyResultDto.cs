using Data.Core.Entity;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.SurveyResult
{
    public class SurveyResultDto
    {
        public int SurveyBaseId { get; set; }
        public int SurveyQuestionId { get; set; }
        public int SurveyQuestionOptionId { get; set; }
    }
}

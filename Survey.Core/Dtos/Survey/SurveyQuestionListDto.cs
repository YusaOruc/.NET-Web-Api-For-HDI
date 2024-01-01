using Data.Entity;
using Survey.Core.Dtos.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.Survey
{
    public class SurveyQuestionListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int SurveyBaseId { get; set; }
        public ICollection<SurveyQuestionOptionListDto> SurveyQuestionOptions { get; set; }
        public int? CorrectQuestionIndex { get; set; }

        public string Creator { get; set; }
        public string Updater { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}

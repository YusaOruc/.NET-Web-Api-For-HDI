using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.Survey
{
    public class SurveyQuestionOptionListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SurveyQuestionId { get; set; }
        public string Creator { get; set; }
        public string Updater { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int? ExpandSurveyBaseId { get; set; }
    }
}

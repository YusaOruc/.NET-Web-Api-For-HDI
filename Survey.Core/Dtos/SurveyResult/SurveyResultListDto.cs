using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Dtos.SurveyResult
{
    public class SurveyResultListDto
    {
        public int Id { get; set; }
        public int SurveyBaseId { get; set; }
        public int SurveyQuestionId { get; set; }
        public int SurveyQuestionOptionId { get; set; }
        public string ApplicationUserId { get; set; }

        public string SurveyBaseTitle { get; set; }
        public string SurveyQuestionTitle { get; set; }
        public string SurveyQuestionOptionTitle { get; set; }
        public string ApplicationUserUserName { get; set; }


        public string Creator { get; set; }
        public string Updater { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}

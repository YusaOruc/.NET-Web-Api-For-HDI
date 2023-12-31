using Data.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Entity
{
    public class SurveyResult : BaseEntity
    {
        public int SurveyBaseId { get; set; }
        public virtual SurveyBase SurveyBase { get; set; }

        public int SurveyQuestionId { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }

        public int SurveyQuestionOptionId { get; set; }
        public virtual SurveyQuestionOption SurveyQuestionOption { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}

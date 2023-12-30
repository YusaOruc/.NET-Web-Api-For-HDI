using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Projectables;


namespace Data.Entity
{
    public partial class SurveyBase
    {
        [Projectable]
        public int QuestionCount =>  SurveyQuestions != null ? SurveyQuestions.Count:0;
    }
}

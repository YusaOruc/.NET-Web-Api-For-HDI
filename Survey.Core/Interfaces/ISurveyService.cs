using Survey.Core.Dtos.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Interfaces
{
    public interface ISurveyService
    {
        /// <summary>
        /// Anket Ekleme
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task Add(SurveyDto dto);

        /// <summary>
        /// Anket Detay
        /// </summary>
        /// <param name="id">Anket Id</param>
        /// <returns></returns>
        Task<SurveyListDto> Get(int id);

        /// <summary>
        /// Anket Listeleme
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SurveySummaryListDto>> GetList();

        /// <summary>
        /// Anket Güncelleme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task Update(int id, SurveyUpdateDto dto);
    }
}

using Auth.Core.Interfaces;
using Data.Core.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey.Core.Dtos.Survey;
using Survey.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Api.Controllers
{
    [Route("api/surveyModule/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly HdiDbContext _context;
        public SurveyController(ISurveyService surveyService, HdiDbContext context)
        {
            _surveyService = surveyService;
            _context = context;
        }

        /// <summary>
        ///     Anket Ekleme 
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="201">Eklenen "dto" objesi</response>
        /// <response code="400">Eksik olan Fieldlar</response>
        [Authorize]
        [HttpPost("PostSurvey")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(void), 201)]
        public async Task<ActionResult> PostSurvey([FromBody] SurveyDto dto)
        {

             await _surveyService.Add(dto);

            return NoContent();
        }

        /// <summary>
        ///     Anket
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Anket bilgileri</response>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SurveyListDto), 200)]
        public async Task<ActionResult<SurveyListDto>> GetSurvey([FromRoute] int id)
        {
            var obj = await _surveyService.Get(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        /// <summary>
        ///     Anket Listeleme
        /// </summary>
        /// <response code="200">Başarılı Listeleme</response>
        /// <response code="400">Eksik olan Fieldlar</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(IEnumerable<SurveySummaryListDto>), 200)]
        public async Task<ActionResult<IEnumerable<SurveySummaryListDto>>> GetSurveys()
        {
            var obj = await _surveyService.GetList();

            return Ok(obj);
        }

        /// <summary>
        ///     Anket güncelleme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <response code="204">Başarılı Güncelleme</response>
        /// <response code="400">Eksik olan Fieldlar</response>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(void), 204)]
        public async Task<IActionResult> PutSurvey([FromRoute] int id, [FromBody] SurveyUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            if (!_context.SurveyBases.Any(e => e.Id == id))
            {
                return NotFound();
            }

            await _surveyService.Update(id, dto);

            return NoContent();
        }
    }
}

using Auth.Core.Interfaces;
using AutoMapper;
using Data.Core.DbContexts;
using Data.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey.Core.Dtos.Survey;
using Survey.Core.Dtos.SurveyResult;
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
        private readonly IMapper _mapper;
        public SurveyController(ISurveyService surveyService, HdiDbContext context, IMapper mapper)
        {
            _surveyService = surveyService;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Anket Ekleme 
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="201">Eklenen "dto" objesi</response>
        /// <response code="400">Eksik olan Fieldlar</response>
        [Authorize(Roles ="Anketor")]
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
        [Authorize(Roles = "Anketor")]
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
            if (dto.Parts != null && dto.Parts.Count > 0)
            {
                await _surveyService.RemoveParts(id, dto.Parts.Where(t => t.Id != 0).Select(t => t.Id).ToList());
                foreach (var item in dto.Parts.Where(t => t.Id != 0))
                {
                    var obj = new SurveyUpdateDto();
                    obj = _mapper.Map(item, obj);
                    await _surveyService.Update(obj.Id, obj);
                }
                foreach (var item in dto.Parts.Where(t => t.Id == 0))
                {
                    var obj = new SurveyDto();
                    obj = _mapper.Map(item, obj);
                    await _surveyService.AddPart(id,obj);
                }
            }
            else
            {
                await _surveyService.RemoveParts(id, null);
            }
            await _surveyService.Update(id, dto);

            return NoContent();
        }

        /// <summary>
        ///     Anket Listeleme
        /// </summary>
        /// <response code="200">Başarılı Listeleme</response>
        /// <response code="400">Eksik olan Fieldlar</response>
        [Authorize]
        [HttpGet("SurveyNames")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(IEnumerable<NameDto>), 200)]
        public async Task<ActionResult<IEnumerable<NameDto>>> GetSurveyNames([FromQuery] int? parentId)
        {
            var obj = await _surveyService.GetNameList(parentId);

            return Ok(obj);
        }

        /// <summary>
        ///  Anketin cevaplarını ekler
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="surveyResults"></param>
        /// <response code="201">Eklenen "dto" objesi</response>
        /// <response code="400">Eksik olan Fieldlar</response>
        [Authorize]
        [HttpPost("SurveyResultMultiple")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(void), 201)]
        public async Task<ActionResult> PostSurveyResultMultiple([FromQuery] int surveyId, [FromBody] List<SurveyResultDto> surveyResults )
        {
            await _surveyService.AddSurveyResultMultiple(surveyId, surveyResults);
            return NoContent();
        }


        /// <summary>
        ///     Anket Cevaplarını Listeleme
        /// </summary>
        /// <response code="200">Başarılı Listeleme</response>
        /// <response code="400">Eksik olan Fieldlar</response>
        [Authorize]
        [HttpGet("Results")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(IEnumerable<SurveyResultListDto>), 200)]
        public async Task<ActionResult<IEnumerable<SurveyResultListDto>>> GetSurveyResults(int? surveyId)
        {
            var obj = await _surveyService.GetSurveyResultList(surveyId);

            return Ok(obj);
        }
    }
}

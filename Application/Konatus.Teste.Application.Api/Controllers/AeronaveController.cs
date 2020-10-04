using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Konatus.Teste.Application.Interfaces;
using Konatus.Teste.Domain.Entities;
using Konatus.Teste.Domain.Interfaces.Repositories.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Konatus.Teste.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AeronaveController : ControllerBase
    {
        protected readonly IAeronaveAppService _aeronaveAppService;
        protected readonly IModeloAeronaveAppService _modeloAeronaveAppService;
        protected readonly IExcelRepository<Aeronave> _excelRepository;
        protected readonly IAeronaveCsvRepository _aeronaveCsvRepository;

        public AeronaveController(IAeronaveAppService aeronaveAppService, IExcelRepository<Aeronave> excelRepository, IAeronaveCsvRepository aeronaveCsvRepository, IModeloAeronaveAppService modeloAeronaveAppService)
        {
            _aeronaveAppService = aeronaveAppService;
            _excelRepository = excelRepository;
            _aeronaveCsvRepository = aeronaveCsvRepository;
            _modeloAeronaveAppService = modeloAeronaveAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string prefix, int page = 0)
        {
            try
            {
                var aeronaves = await _aeronaveAppService.Get(new Aeronave { Prefix = prefix ?? "" }, page);

                return Ok(aeronaves);
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível buscar aeronaves.");
#endif                                
            }
        }

        [HttpGet("Actives")]
        public async Task<IActionResult> GetActives()
        {
            try
            {
                var aeronaves = await _aeronaveAppService.GetActives();

                return Ok(aeronaves);
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível buscar as aeronaves ativas.");
#endif                                
            }
        }

        [HttpGet("Actives/Excel")]
        public async Task<IActionResult> GetActivesExcel()
        {
            try
            {
                var aeronaves = await _aeronaveAppService.GetActives();

                var stream = _excelRepository.Export(aeronaves);

                return File(
                    stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"Aeronaves_{DateTime.Now}.xlsx");
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível buscar as aeronaves ativas.");
#endif                                
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Aeronave aeronave)
        {
            try
            {
                var aeronaves = await _aeronaveAppService.Add(aeronave);

                return Ok(aeronaves);
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível adicionar a aeronave.");
#endif                                
            }
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import([FromForm] IFormFile file)
        {
            try
            {
                if (file == null) throw new Exception("Selecione um arquivo.");

                using (var stream = file.OpenReadStream())
                {
                    var aircraftTuple = await _aeronaveCsvRepository.Convert(stream);

                    foreach (var aircraftModel in aircraftTuple.aircraftsModels)
                    {
                        await _modeloAeronaveAppService.Add(aircraftModel);
                    }

                    foreach (var aircraft in aircraftTuple.aircrafts)
                    {
                        await _aeronaveAppService.Add(aircraft);
                    }

                    return Ok();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível importar as aeronaves.");
#endif                                
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Aeronave aeronave)
        {
            try
            {
                await _aeronaveAppService.Update(aeronave);

                return Ok();
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível atualizar a aeronave.");
#endif                                
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string prefix)
        {
            try
            {
                await _aeronaveAppService.Delete(new Aeronave { Prefix = prefix });

                return Ok();
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível deletar a aeronave.");
#endif
            }
        }
    }
}
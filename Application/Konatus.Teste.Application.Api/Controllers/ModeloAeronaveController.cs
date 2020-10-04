using System;
using System.Threading.Tasks;
using Konatus.Teste.Application.Interfaces;
using Konatus.Teste.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Konatus.Teste.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModeloAeronaveController : ControllerBase
    {
        protected readonly IModeloAeronaveAppService _modeloAeronaveAppService;

        public ModeloAeronaveController(IModeloAeronaveAppService modeloAeronaveAppService)
        {
            _modeloAeronaveAppService = modeloAeronaveAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string code, string alternativeCode, int page = 0)
        {
            try
            {
                var aeronaves = await _modeloAeronaveAppService.Get(new ModeloAeronave { Code = code, AlternativeCode = alternativeCode }, page);

                return Ok(aeronaves);
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível buscar modelos de aeronaves.")
#endif                                
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> All(string code, string alternativeCode, int page = 0)
        {
            try
            {
                var aeronaves = await _modeloAeronaveAppService.GetAll();

                return Ok(aeronaves);
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível buscar modelos de aeronaves.")
#endif                                
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ModeloAeronave modeloAeronave)
        {
            try
            {
                var aeronaves = await _modeloAeronaveAppService.Add(modeloAeronave);

                return Ok(aeronaves);
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível adicionar o modelos de aeronave.")
#endif                                
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ModeloAeronave modeloAeronave)
        {
            try
            {
                await _modeloAeronaveAppService.Update(modeloAeronave);

                return Ok();
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível atualizar o modelo de aeronave.")
#endif                                
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string code, string alternativeCode)
        {
            try
            {
                await _modeloAeronaveAppService.Delete(new ModeloAeronave { Code = code, AlternativeCode = alternativeCode });

                return Ok();
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
#else
                return BadRequest("Não foi possível remover o modelo de aeronave.")
#endif                                
            }
        }
    }
}
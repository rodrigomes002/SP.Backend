using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SP.Application.Processos;
using SP.Application.Processos.DTO;
using System;
using System.Collections.Generic;

namespace SP.API.Controllers
{
    [Route("api/processos")]
    [ApiController]
    public class ApiProcessos : ControllerBase
    {
        private readonly ProcessoService _service;
        private readonly ILogger<ApiProcessos> _logger;


        public ApiProcessos(ProcessoService service, ILogger<ApiProcessos> logger)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProcessoDTO>> Listar()
        {
            try
            {
                _logger.LogInformation("Recebendo requisição de listar todos os processos.");
                var resultado = this._service.ListarTodos();
                _logger.LogInformation("Retornando requisição de listar todos os processos.");
                return Ok(resultado);

            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição: " + e.Message);
                throw e;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProcessoDTO> Listar(long id)
        {
            try
            {
                _logger.LogInformation("Recebendo requisição de listar um processo.");
                var resultado = this._service.ListarPorId(id);
                _logger.LogInformation("Retornando requisição de listar um processo.");
                return Ok(resultado);

            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição :" + e.Message);
                throw e;
            }
        }

        [HttpPost("cadastrar")]
        public ActionResult Cadastrar([FromBody] ProcessoDTO requisicao)
        {
            try
            {
                _logger.LogInformation("Recebendo requisição para cadastrar um processo.");
                this._service.Cadastrar(requisicao);
                _logger.LogInformation("Retornando requisição para cadastrar um processo.");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição: " + e.Message);
                throw e;
            }
        }

        [HttpPut("atualizar")]
        public ActionResult Atualizar([FromBody] ProcessoDTO requisicao)
        {
            try
            {
                _logger.LogInformation("Recebendo requisição para cadastrar um processo.");
                this._service.Atualizar(requisicao);
                _logger.LogInformation("Retornando requisição para cadastrar um processo.");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição: " + e.Message);
                throw e;
            }
        }
    }
}

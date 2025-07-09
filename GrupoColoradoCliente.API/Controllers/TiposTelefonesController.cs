using Microsoft.AspNetCore.Mvc;
using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Interface;
using SistemaCliente.Application.Service;

namespace SistemaCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTelefonesController : ControllerBase
    {
        private readonly ITipoTelefoneService _serviceTipoTelefone;
        public TipoTelefonesController(ITipoTelefoneService serviceTipoTelefone)
        {
            _serviceTipoTelefone = serviceTipoTelefone;
        }

        /// <summary>
        /// Busca todos os clientes.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTelefoneResponseDto>>> GetAll()
        {
            var clientes = await _serviceTipoTelefone.GetAllAsync();
            return Ok(clientes);
        }

        /// <summary>
        /// Busca o cliente pelo id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTelefoneResponseDto>> GetById(int id)
        {
            var cliente = await _serviceTipoTelefone.GetByIdAsync(id);

            if (cliente == null)
                return NotFound(new { message = "Cliente não localizado" });

            return Ok(cliente);
        }

        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<TipoTelefoneResponseDto>> Create([FromBody] TipoTelefoneDto dto)
        {
            var cliente = await _serviceTipoTelefone.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = cliente }, cliente);
        }

        /// <summary>
        /// Edita o cadastro de um cliente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoTelefoneDto dto)
        {
            await _serviceTipoTelefone.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove um cliente da base.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceTipoTelefone.DeleteAsync(id);
            return NoContent();
        }
                
    }
}

using Microsoft.AspNetCore.Mvc;
using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Interface;

namespace SistemaCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;
        public TelefonesController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService ?? throw new ArgumentNullException(nameof(telefoneService));
        }

        /// <summary>
        /// Busca todos os clientes.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponseDto>>> GetAll()
        {
            var clientes = await _telefoneService.GetAllAsync();
            return Ok(clientes);
        }

        /// <summary>
        /// Busca o cliente pelo id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponseDto>> GetById(int id)
        {
            var cliente = await _telefoneService.GetByIdAsync(id);

            if (cliente == null)
                return NotFound(new { message = "Cliente não localizado" });

            return Ok(cliente);
        }

        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<TelefoneResponseDto>> Create([FromBody] TelefoneDto dto)
        {
            var cliente = await _telefoneService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = cliente.CodigoTipoTelefone }, cliente);
        }

        /// <summary>
        /// Edita o cadastro de um cliente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TelefoneDto dto)
        {
            await _telefoneService.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove um cliente da base.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _telefoneService.DeleteAsync(id);
            return NoContent();
        }              
    }
}

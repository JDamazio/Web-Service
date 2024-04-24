using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet.Application.DTOs;
using Pet.Application.Interfaces;
using Pet.Domain.Entities;

namespace Pet.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ClienteController : ControllerBase
	{
		private readonly IClienteService _service;

		public ClienteController(IClienteService service)
		{
			_service = service;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
		{
			var clientes = await _service.GetClientes();
			if (clientes == null)
			{
				return NotFound("Nenhum clientes encontrado.");
			}
			return Ok(clientes);
		}

		[HttpGet("{id:int}", Name = "GetCliente")]
		public async Task<ActionResult<ClienteDTO>> Get(int id)
		{
			var cliente = await _service.GetById(id);
			if (cliente == null)
				return NotFound("Nenhum cliente encontrado.");

			return Ok(cliente);
		}

		[HttpPost]
		public async Task<ActionResult> Post(ClienteDTO clienteDto)
		{
			if (clienteDto == null)
				return BadRequest("Dados invalidos");

			await _service.Add(clienteDto);
			return new CreatedAtRouteResult("GetCliente", new { id = clienteDto.Id }, clienteDto);
		}

		[HttpPut]
		public async Task<ActionResult> Put(int id, ClienteDTO clienteDTO)
		{
			if (id != clienteDTO.Id)
				return BadRequest("Verifique os dados.");

			if (clienteDTO == null)
				return BadRequest("Informe um cliente.");

			await _service.Update(clienteDTO);
			return Ok(clienteDTO);
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<ClienteDTO>> Delete(int id)
		{
			var cliente = await _service.GetById(id);
			if(cliente == null)
				return NotFound("Nenhum cliente encontrado.");

			await _service.Remove(id);
			return Ok(cliente);
		}
	}
}

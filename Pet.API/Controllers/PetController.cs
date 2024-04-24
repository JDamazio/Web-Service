using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet.Application.DTOs;
using Pet.Application.Interfaces;

namespace Pet.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PetController : ControllerBase
	{
		private readonly IPetService _service;

		public PetController(IPetService petService)
		{
			_service = petService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PetDTO>>> Get()
		{
			var pets = await _service.GetPets();
			if (pets == null)
			{
				return NotFound("Nenhum pet encontrado");
			}
			return Ok(pets);
		}

		[HttpGet("{id:int}", Name = "GetPet")]
		public async Task<ActionResult<PetDTO>> Get(int id)
		{
			var pet = await _service.GetById(id);
			if (pet == null) 
			{
				return NotFound("Nenhum pet encontrado");
			}
			return Ok(pet);
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult> Post(PetDTO petDTO)
		{
			if (petDTO == null)
				return BadRequest("Informe os dados");

			await _service.Add(petDTO);

			return new CreatedAtRouteResult("GetPet", new { id = petDTO.Id }, petDTO);
		}

		[HttpPut("{id:int}")]
		[Authorize]
		public async Task<ActionResult> Put(int id, PetDTO petDto)
		{
			if (id != petDto.Id)
			{
				return BadRequest("Verifique os dados");
			}

			if (petDto == null)
				return BadRequest("Informe os dados");

			await _service.Update(petDto);	
			return Ok(petDto);
		}

		[HttpDelete]
		[Authorize]
		public async Task<ActionResult<PetDTO>> Delete(int id)
		{
			var pet = await _service.GetById(id);

			if (pet == null)
				return NotFound("Pet não encontrado");

			await _service.Remove(id);

			return Ok(pet);
		}
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcialCaso03.DOMAIN.Core.Entities;
using ParcialCaso03.DOMAIN.Core.Interfaces;
using ParcialCaso03.DOMAIN.Infrastructure.Repositories;

namespace ParcialCaso03.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoryController : ControllerBase
    {
        private readonly ITerritoryRepository _territoryRepository;

        public TerritoryController(ITerritoryRepository territoryRepository)
        {
            _territoryRepository = territoryRepository;
        }

        [HttpGet("Listar Territorios")]
        public async Task<IActionResult> GetAll()
        {
            var territories = await _territoryRepository.GetAll();
            return Ok(territories);
        }

        [HttpPost("Registran Territorio")]
        public async Task<IActionResult> Create([FromBody] Territory territory)
        {
            var result = await _territoryRepository.Create(territory);
            if (result != true)
            {
                return BadRequest("El territorio ya esta registrado en la base de datos");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPut("Actualizar territorio por id/{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] Territory territory)
        {
            var result = await _territoryRepository.UpdateById(new Territory
            {
                Id = id,
                Description = territory.Description,
                Area = territory.Area,
                Population = territory.Population,
            });

            if (!result)
            {
                return BadRequest("El territorio no existe o no tiene cambios que actualizar en los registros");
            }

            return Ok(result);
        }

        [HttpDelete("Eliminar territorio por id/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _territoryRepository.DeleteById(id);
            if (!result)
                return BadRequest("No se pudo emilinar el territorio por ID");

            return Ok(result);
        }

    }
}

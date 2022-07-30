using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.DetallePlatos;
using ApiRestaurante.Core.Application.ViewModels.Platos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ApiRestaurante.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class PlatosController : BaseApiController
    {
        private readonly IPlatosService _platosService;
        private readonly IDetallePlatosService _detallePlatosService;

        public PlatosController(IPlatosService plantosService, IDetallePlatosService detallePlatosService)
        {
            _platosService = plantosService;
            _detallePlatosService = detallePlatosService;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlatosViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var platos = await _platosService.GetAllViewModel();

                if (platos == null || platos.Count == 0)
                {
                    return NotFound();
                }

                return Ok(platos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SavePlatosViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _platosService.GetByIdSaveViewModel(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(SavePlatosViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                string split = vm.Ingredientes;
                List<string> list = new List<string>();
                list = split.Split(',').ToList();

                var plato = await _platosService.Add(vm);

                foreach (var l in list)
                {
                    SaveDetallePlatosViewModel ingrediente = new();
                    ingrediente.IdPlato = plato.Id;
                    ingrediente.IdIngrediente = Int32.Parse(l);
                    await _detallePlatosService.Add(ingrediente);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SavePlatosViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int Id, SavePlatosViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _platosService.Update(vm, Id);

                await _detallePlatosService.DeleteAllAsync(Id);

                string split = vm.Ingredientes;
                List<string> list = new List<string>();
                list = split.Split(',').ToList();

                foreach (var l in list)
                {
                    SaveDetallePlatosViewModel ingrediente = new();
                    ingrediente.IdPlato = Id;
                    ingrediente.IdIngrediente = Int32.Parse(l);
                    await _detallePlatosService.Add(ingrediente);
                }

                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

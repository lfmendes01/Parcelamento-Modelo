using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelamentoAPI.Dto.Cliente;
using ParcelamentoAPI.Service;

namespace ParcelamentoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(
            IClienteService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetByIdCliente(int id)
        {
            try
            {
                var dto = _service.Get(id);
                if (dto == null)
                {
                    return NotFound();
                }

                return Ok(dto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}

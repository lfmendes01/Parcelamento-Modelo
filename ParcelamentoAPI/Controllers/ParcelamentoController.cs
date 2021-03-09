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
    public class ParcelamentoController : ControllerBase
    {
        private readonly IParcelamentoService _service;

        public ParcelamentoController(
            IParcelamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Parcelar/{id:int}/{data}")]
        public ActionResult GetByIdCliente(int id, string data)
        {
            try            
            {

                DateTime dataCalculo = DateTime.Parse(data);
                var parcelamento = _service.CalcularParcelamento(id,dataCalculo);
                if (parcelamento == null)
                {
                    return NotFound();
                }

                return Ok(parcelamento);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("Divida/{idCliente:int}")]
        public ActionResult GetDividaByIdCliente(int idCliente)
        {
            try
            {

                var parcelamento = _service.Divida(idCliente);
                if (parcelamento == null)
                {
                    return NotFound();
                }

                return Ok(parcelamento);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("SalvarParcelamento")]
        public ActionResult GetDividaByIdCliente(ClienteParcelamentoDto dto)
        {
            try
            {
                _service.SalvarParcelamento(dto);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

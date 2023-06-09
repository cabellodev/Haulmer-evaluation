using System;
using Microsoft.AspNetCore.Mvc;
using solution.Models.DTO.Response;
using solution.Service;
using static solution.Models.DTO.Request.EncryptRequest;

namespace solution.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptedController : ControllerBase
	{
        private Response _response = new Response();
        private IEncryptedService _encryptedService;

        public EncryptedController(IEncryptedService encryptedService)
        {
            _encryptedService = encryptedService;
        }

        [Route("encrypt")]
        [HttpPost]
        public dynamic encrypt(Encrypt request)
        {
            try
            {
                _response.data = _encryptedService.Encrypt(request);
                _response.exito = true;
                _response.mensaje = "Encriptación exitosa";
                return Ok(_response);

            }catch(Exception ex)
            {
                _response.exito = true;
                _response.mensaje = ex.Message;
                return BadRequest(_response);

            }
        }


        [Route("decrypt")]
        [HttpPost]
        public dynamic decrypt(Decrypt request)
        {
            try
            {
                _response.data = _encryptedService.Decrypt(request);
                _response.exito = true;
                _response.mensaje = "Desencriptado exitoso";
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.exito = true;
                _response.mensaje = ex.Message;
                return BadRequest(_response);

            }
        }
    }
}


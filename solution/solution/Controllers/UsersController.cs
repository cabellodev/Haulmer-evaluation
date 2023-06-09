using System;
using Microsoft.AspNetCore.Mvc;
using solution.Models;
using solution.Models.DTO.Response;
using solution.Service;
using static solution.Models.DTO.Request.UsersRequest;

namespace solution.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
        private IUserService _userService; // inyeccion de dependencia 
        private Response _response = new Response();

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


		[Route("listarUsuarios")]
		[HttpGet]
		public IActionResult listarUsuarios()
		{
            try
            {
                _response.data =_userService.GetUsers();
                _response.exito = true;
                _response.mensaje = "Lista de definida con exito";
                return Ok(_response); // formato personalizado de respuesta _response
            }
            catch (Exception ex)
            {
                _response.exito = false;
                _response.mensaje = ex.Message;
                return BadRequest(_response);

            }
         
		}

        [Route("guardarUsuario")]
        [HttpPost]
        public IActionResult guardarUsuario(CreateUser resquest)
        {
            try
            {
                _userService.CreateUser(resquest);
                _response.exito = true;
                _response.mensaje = "El registro fue guardado con éxito";
                return Ok(_response); // formato personalizado de respuesta _response

            }
            catch (Exception ex)
            {
                _response.exito = false;
                _response.mensaje = ex.Message;
                return BadRequest(_response);

            }

        }


    }
}


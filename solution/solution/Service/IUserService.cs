using System;
using static solution.Models.DTO.Request.EncryptRequest;
using static solution.Models.DTO.Request.UsersRequest;
using static solution.Models.DTO.Response.UsersResponse;

namespace solution.Service
{
	public interface IUserService
	{
		List<Users> GetUsers();// listar usuarios
	    void CreateUser(CreateUser request); // crear usuario
		 
    }
}


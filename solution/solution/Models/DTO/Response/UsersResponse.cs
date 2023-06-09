using System;
namespace solution.Models.DTO.Response
{
	public class UsersResponse
	{
		public class Users{
            public int? id { get; set; }
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Correo { get; set; }
            public string? Telefono { get; set; }
            public string? Contraseña { get; set; }
            public string? FechaCreacion { get; set; }
            public string? FechaActualización { get; set; }
        }

        
    }
}


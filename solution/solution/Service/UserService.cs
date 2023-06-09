using System;
using System.IO;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using solution.Models;
using Newtonsoft.Json;
using static solution.Models.DTO.Request.EncryptRequest;
using static solution.Models.DTO.Request.UsersRequest;
using static solution.Models.DTO.Response.UsersResponse;


namespace solution.Service
{

    public class UserService : IUserService
	{
        private static string projectRoot = Directory.GetCurrentDirectory();           
        private static string filePath = Path.Combine(projectRoot, "UsersData.json");

        Random random = new Random();
        DateTime currentDate = DateTime.Today;

        public List<Users> GetUsers() {
            try
            {
                string jsonContent = System.IO.File.ReadAllText(filePath);      

                List<Users> Users = JsonConvert.DeserializeObject<List<Users>>(jsonContent); 
                return Users;   // retorna el listado de usuarios

            }catch (Exception ex){
                throw new Exception(ex.Message);
            }
        }


        public void CreateUser(CreateUser request)
        {
            
            try {
                
               
                string jsonContent = System.IO.File.ReadAllText(filePath);

                List<User> Users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

                User NuevoUsuario = new User();

                NuevoUsuario.id = random.Next(4, 200);
                NuevoUsuario.Nombre = request.Nombre;
                NuevoUsuario.Nombre = request.Nombre;
                NuevoUsuario.Apellido = request.Apellido;
                NuevoUsuario.Contraseña = request.Contraseña;
                NuevoUsuario.Telefono = request.Telefono;
                NuevoUsuario.Correo = request.Correo;
                NuevoUsuario.FechaActualización = request.FechaActualización;
                NuevoUsuario.FechaCreacion = currentDate.ToString();


                Users.Add(NuevoUsuario);

                string json = JsonConvert.SerializeObject(Users);  

                File.WriteAllText(filePath, json); 

            }
            catch(Exception ex){

                throw new Exception(ex.Message);
            }
        }
    }
}


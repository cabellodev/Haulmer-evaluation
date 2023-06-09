using System;
using Microsoft.AspNetCore.Mvc;
using static solution.Models.DTO.Request.EncryptRequest;

namespace solution.Service
{
	public interface IEncryptedService
    {
        string Encrypt(Encrypt resquest); // encryptado 
        string Decrypt(Decrypt resquest);// desencryptado    
	}
}


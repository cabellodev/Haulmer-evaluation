using System;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using static solution.Models.DTO.Request.EncryptRequest;

namespace solution.Service
{
	public class EncryptedService: IEncryptedService
    {

        public string Encrypt(Encrypt request) // funcion encriptado 
        {

            try
            {
                string Hash = "ABC123456789";
                byte[] Data = UTF8Encoding.UTF8.GetBytes(request.Text);

                MD5 md5 = MD5.Create();
                TripleDES tripldes = TripleDES.Create();

                tripldes.Key = md5.ComputeHash(UTF32Encoding.UTF8.GetBytes(Hash));
                tripldes.Mode = CipherMode.ECB;

                ICryptoTransform transform = tripldes.CreateEncryptor();
                byte[] result = transform.TransformFinalBlock(Data, 0, Data.Length);

                return Convert.ToBase64String(result);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string Decrypt(Decrypt request) //funcion desencriptado
        {
            
            try
            {
                string Hash = "ABC123456789";  
                byte[] Data = Convert.FromBase64String(request.Encrypted);

                MD5 md5 = MD5.Create();
                TripleDES tripldes = TripleDES.Create();

                tripldes.Key = md5.ComputeHash(UTF32Encoding.UTF8.GetBytes(Hash));
                tripldes.Mode = CipherMode.ECB;

                ICryptoTransform transform = tripldes.CreateDecryptor();
                byte[] result = transform.TransformFinalBlock(Data, 0, Data.Length);

                return UTF8Encoding.UTF8.GetString(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}


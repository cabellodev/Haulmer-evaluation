using System;
namespace solution.Models.DTO.Request
{
	public class EncryptRequest
	{
		public class Encrypt{
			public string Text { get; set; }
		}

		public class Decrypt
		{
			public string Encrypted { get; set; }
		}
	}
}


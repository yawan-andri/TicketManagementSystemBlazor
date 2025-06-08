﻿using Jose;
using Newtonsoft.Json;
using System.Text;

namespace TicketManagementUI.Security
{
	public class EncryptionHelper<T> where T : class
	{
		byte[] secretKey;
		private readonly IConfiguration configuration;
		
		public EncryptionHelper(IConfiguration configuration)
		{
			this.configuration = configuration;
			secretKey = Encoding.UTF8.GetBytes(configuration["JWEKey"]);
		}

		public string Encode(object obj)
		{
			return JWT.Encode(obj, secretKey, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
		}

		public T Decode(string token)
		{
			var result = JWT.Decode(token, secretKey, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
			return JsonConvert.DeserializeObject<T>(result);
		}
	}
}

using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
	public class AccountService : IAccountService
	{
		private readonly SignInManager<User> signInManager;

		public AccountService(SignInManager<User> signInManager)
		{
			this.signInManager = signInManager;
		}
		public Task<BaseResponse> RegisterUser(RegisterUserRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<string>> VerifyUser(string email, string password)
		{
			throw new NotImplementedException();
		}
	}
}

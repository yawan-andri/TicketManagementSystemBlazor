using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Entities
{
	public class User : IdentityUser
	{
		public string? Avatar { get; set; }
		public bool AccountConfirmed { get; set; }

	}
}

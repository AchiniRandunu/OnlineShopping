using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineShopping.Data.Entities
{
	/// <summary>
	/// Identity user entity
	/// </summary>
	public class ApplicationUser : IdentityUser
	{
		public static object Claims { get; set; }
		[Column(TypeName = "nvarchar(150)")]
		public string FullName { get; set; }

	}
}

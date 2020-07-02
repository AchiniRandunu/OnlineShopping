using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineShopping.Data.Entities
{
	public class ApplicationUser: IdentityUser
	{
		public static object Claims { get; set; }
		[Column(TypeName = "nvarchar(150)")]
		public string FullName { get; set; }

	}
}

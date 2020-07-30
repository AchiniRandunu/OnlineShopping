using OnlineShopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.DTO
{
	public class ResponseDTO
	{
		public Object Data { get; set; }
		public string ErrorDescription { get; set; }
		public string Statuscode { get; set; }
		
	
	}
}

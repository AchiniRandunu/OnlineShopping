using System;

namespace OnlineShopping.DTO
{
    /// <summary>
    /// Response Dto
    /// </summary>
	public class ResponseDTO
	{
		public Object Data { get; set; }
		public string ErrorDescription { get; set; }
		public string Statuscode { get; set; }


	}
}

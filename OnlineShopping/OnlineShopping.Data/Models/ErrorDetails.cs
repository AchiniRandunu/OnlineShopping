using Newtonsoft.Json;

namespace OnlineShopping.Data.Models
{
	/// <summary>
	/// Error details
	/// </summary>
	public class ErrorDetails
	{
		public string Data { get; set; }
		public int StatusCode { get; set; }
		public string ErrorDescription { get; set; }


		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}


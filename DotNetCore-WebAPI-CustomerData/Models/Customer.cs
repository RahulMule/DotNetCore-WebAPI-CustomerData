using System.ComponentModel.DataAnnotations;

namespace DotNetCore_WebAPI_CustomerData.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public ICollection<Address>? Addresses { get; set; }
	}

}

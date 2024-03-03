using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNetCore_WebAPI_CustomerData.Models
{
	public class Address
	{
		[Key]
		public int Id { get; set; }

		public string City { get; set; }
		public string Region { get; set; }

		[Required]
		public int CustomerId { get; set; }

		[ForeignKey("CustomerId")]
		public Customer? Customer { get; set; }
	}

}

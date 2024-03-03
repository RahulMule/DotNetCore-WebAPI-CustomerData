using DotNetCore_WebAPI_CustomerData.DataContext;
using DotNetCore_WebAPI_CustomerData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_WebAPI_CustomerData.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
        private readonly CustomerContext _context;
        public CustomerController(CustomerContext context)
        {
            _context = context;  
        }

		[HttpPost]
		public async Task<IActionResult> AddCustomer(Customer customer)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					// Add customer and addresses
					await _context.Customers.AddAsync(customer);
					await _context.SaveChangesAsync(); // Save changes to generate customer Id

					// Addresses will be automatically added due to navigation property

					// Commit transaction
					await transaction.CommitAsync();

					return Ok(customer);
				}
				catch (Exception ex)
				{
					// Rollback transaction in case of error
					await transaction.RollbackAsync();
					return StatusCode(500, $"Internal server error: {ex.Message}");
				}
			}
		}

		[HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var customers = _context.Customers
                            .Include(x => x.Addresses)
                            .ToList();  
            return new OkObjectResult(customers);
        }
    }
}

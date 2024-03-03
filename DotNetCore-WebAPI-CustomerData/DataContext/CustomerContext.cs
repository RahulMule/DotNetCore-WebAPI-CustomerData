using DotNetCore_WebAPI_CustomerData.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_WebAPI_CustomerData.DataContext
{
	public class CustomerContext : DbContext
	{
		public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
		{
		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Address> Addresses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Address>()
				.HasOne(a => a.Customer)
				.WithMany(c => c.Addresses)
				.HasForeignKey(a => a.CustomerId)
				.IsRequired();
		}
	}
}

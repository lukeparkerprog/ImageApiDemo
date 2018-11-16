using ImageApiDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageApiDemo.Services
{
	public class MyDbContext : IdentityDbContext
	{
		public DbSet<Image> TblImages { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder option)
		{
			option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ImageApiDemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}

	}
}

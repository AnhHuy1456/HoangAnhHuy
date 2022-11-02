using System.Net.Mime;
using HoangAnhHuy_BTH2.Models;
using Microsoft .EntityFrameworkCore;

namespace HoangAnhHuy_BTH2.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<Student> Students {get; set;}
        public DbSet<HoangAnhHuy_BTH2.Models.Person>? Person { get; set; }
        public DbSet<HoangAnhHuy_BTH2.Models.Employee>? Employee { get; set; }
        public DbSet<HoangAnhHuy_BTH2.Models.Customer>? Customer { get; set; }
    }
}
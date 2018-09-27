using ClientAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.DataAccessTier
{
    public class DataContext :  IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        
        public DbSet<Person> Person { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Goals> Goals { get; set; }
        public DbSet<GoalRemarks> GoalRemarks { get; set; }        

    }
}
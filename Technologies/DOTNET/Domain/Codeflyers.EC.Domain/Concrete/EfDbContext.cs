using System.Data.Entity;
using Codeflyers.EC.Domain.Entities;

namespace Codeflyers.EC.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        // As I can't save the connection string in the conig, not supported yet, so I made this constructor
        //private string _connectionString = "Data Source=.;Initial Catalog=Codeflyers.EC.DB;Integrated Security=SSPI;";

        //public EfDbContext(): base(Config.ConnectionString)
        //{
            
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

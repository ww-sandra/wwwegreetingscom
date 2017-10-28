using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace halloween.Models
{
    public class BridgeDbContext : DbContext
    {
        //Default Constructor
        public BridgeDbContext() { }
        
        //Constructor
        public BridgeDbContext(DbContextOptions<BridgeDbContext> options):
            base(options){ }

        //Table in the DB!
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Greetings> Greetings { get; set; }
        public DbSet<Member> Member { get; set; }

    }
}

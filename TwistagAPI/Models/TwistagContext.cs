using Microsoft.EntityFrameworkCore;

namespace TwistagAPI.Models
{
    public class TwistagContext : DbContext
    {
        public TwistagContext(DbContextOptions<TwistagContext> options)
            :base(options) 
        {

        }

        public DbSet<UserInformation> UserInformations { get; set; }
    }
}

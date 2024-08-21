using CommandHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandHelper.Data
{
    public class CommandDbContext: DbContext 
    {
        public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options) { }

        public DbSet<Command> commands { get; set; }
    }
}

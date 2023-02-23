using FullStackApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FullStackApi.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public DbSet<Resource> Recourses { get; set; }
    }
}

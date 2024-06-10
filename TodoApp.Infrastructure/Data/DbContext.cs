using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;

namespace TodoApp.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<TodoUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasOne<TodoUser>()
            .WithMany()
            .HasForeignKey(t => t.OwnerId)
            .HasPrincipalKey(u => u.UserName);

        base.OnModelCreating(modelBuilder);

    }
}
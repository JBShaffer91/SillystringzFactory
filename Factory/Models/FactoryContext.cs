#nullable disable
using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public virtual DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<EngineerMachine> EngineerMachines { get; set; } // Changed to plural

    public FactoryContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<EngineerMachine>()
        .HasKey(em => new { em.EngineerId, em.MachineId }); // Define composite key

      modelBuilder.Entity<EngineerMachine>()
        .HasOne(em => em.Engineer)
        .WithMany(e => e.EngineerMachines) // Assuming this collection exists in Engineer
        .HasForeignKey(em => em.EngineerId);

      modelBuilder.Entity<EngineerMachine>()
        .HasOne(em => em.Machine)
        .WithMany(m => m.EngineerMachines) // Assuming this collection exists in Machine
        .HasForeignKey(em => em.MachineId);
    }
  }
}
#nullable enable

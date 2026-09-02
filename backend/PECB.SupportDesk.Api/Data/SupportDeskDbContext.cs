using Microsoft.EntityFrameworkCore;
using PECB.SupportDesk.Api.Models;
namespace PECB.SupportDesk.Api.Data;
public sealed class SupportDeskDbContext(DbContextOptions<SupportDeskDbContext> options) : DbContext(options) {
 public DbSet<Agent> Agents => Set<Agent>(); public DbSet<Ticket> Tickets => Set<Ticket>(); public DbSet<TicketComment> Comments => Set<TicketComment>();
 protected override void OnModelCreating(ModelBuilder b) { b.Entity<Agent>().HasIndex(x=>x.Email).IsUnique(); b.Entity<Ticket>().HasIndex(x=>x.Reference).IsUnique(); b.Entity<Agent>().Property(x=>x.Department).HasConversion<string>(); b.Entity<Ticket>().Property(x=>x.Priority).HasConversion<string>(); b.Entity<Ticket>().Property(x=>x.Status).HasConversion<string>(); b.Entity<Ticket>().HasOne(x=>x.AssignedAgent).WithMany(x=>x.Tickets).HasForeignKey(x=>x.AssignedAgentId).OnDelete(DeleteBehavior.SetNull); b.Entity<TicketComment>().HasOne(x=>x.Ticket).WithMany(x=>x.Comments).HasForeignKey(x=>x.TicketId).OnDelete(DeleteBehavior.Cascade); SeedData.Apply(b); }
}

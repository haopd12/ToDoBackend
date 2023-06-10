using App.Shared.AppSession;
using App.Shared.Uow;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Contexts;

public class ToDoContext : ImaxDbContextBase<ToDoContext>
{

	public virtual DbSet<Work>? Works { get; set; }
    public virtual DbSet<UserWork>? UsersWork { get; set; }
    public virtual DbSet<MediaTranmission>? MediaTranmissions { get; set; }
    public virtual DbSet<MediaWork>? MediaWorks { get; set; }
	public ToDoContext(DbContextOptions<ToDoContext> options, IAppSession appSession) : base(options, appSession)
    {
    }
/*
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
        modelBuilder.Entity<Work>()
            .HasKey(x => x.Id)

     }*/

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("DefaultConnection");
        }
    }
}
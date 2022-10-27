using Microsoft.EntityFrameworkCore;
using ClassRoom.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ClassRoom.Domain.Identity;

namespace ClassRoom.Persistence
{
    public class ClassRoomContext : IdentityDbContext<User, Role, int, 
                                                      IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
                                                      IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ClassRoomContext(DbContextOptions<ClassRoomContext> options) 
            : base(options){}
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<UserRole>(userRole =>
                {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});
                
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();                  
                }            
            );            
        }
        
    }
}
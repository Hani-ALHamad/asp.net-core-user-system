using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserSystem.Areas.Identity.Data;

namespace UserSystem.Models
{
    public partial class UserSystemContext : DbContext
    {
        public UserSystemContext()
        {
        }

        public UserSystemContext(DbContextOptions<UserSystemContext> options)
            : base(options)
        {
        }


        public virtual DbSet<UserAvatar> UserAvatars { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("DB URL HERE");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAvatar>(entity =>
            {
                entity.ToTable("UserAvatar");

                entity.Property(e => e.ID).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

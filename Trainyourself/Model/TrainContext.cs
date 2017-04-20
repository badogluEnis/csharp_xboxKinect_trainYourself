namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrainContext : DbContext
    {
        public TrainContext()
            : base("name=TrainContext")
        {
        }

        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .Property(e => e.Exercise1)
                .IsUnicode(false);

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.Scores)
                .WithOptional(e => e.Exercise)
                .HasForeignKey(e => e.Exercise_Id);

            modelBuilder.Entity<Score>()
                .Property(e => e.Score1)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}

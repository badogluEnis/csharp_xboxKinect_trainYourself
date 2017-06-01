namespace Model
{
    using System.Data.Entity;

    /// <summary>
    /// Here we create the connection.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class TrainContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrainContext"/> class.
        /// </summary>
        public TrainContext()
            : base("name=TrainContext")
        {
        }

        /// <summary>
        /// Gets or sets the exercises.
        /// </summary>
        /// <value>
        /// The exercises.
        /// </value>
        public virtual DbSet<Exercise> Exercises { get; set; }
        /// <summary>
        /// Gets or sets the scores.
        /// </summary>
        /// <value>
        /// The scores.
        /// </value>
        public virtual DbSet<Score> Scores { get; set; }
        /// <summary>
        /// Gets or sets the sysdiagrams.
        /// </summary>
        /// <value>
        /// The sysdiagrams.
        /// </value>
        public virtual DbSet<sysdiagram> Sysdiagrams { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
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
                .Property(e => e.Score1);

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

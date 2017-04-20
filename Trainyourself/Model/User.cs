namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Password { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public int? RecordPushups { get; set; }

        public int? RecordSquats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Scores { get; set; }

        /// <summary>
        /// Createusers the specified name.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Lastname">The lastname.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Password">The password.</param>
        /// <param name="Weight">The weight.</param>
        /// <param name="Height">The height.</param>
        public void Createuser(string Name, string Lastname, string Email, string Password)
        {
            using (TrainContext context = new TrainContext())
            {
                User user = new User
                {
                    Name = Name , Lastname = Lastname, Email = Email, Password = Password 
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}

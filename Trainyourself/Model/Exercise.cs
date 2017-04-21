namespace Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Exercise")]
    public sealed class Exercise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercise()
        {
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }

        [Column("Exercise")]
        [StringLength(50)]
        public string Exercise1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Score> Scores { get; set; }
    }
}

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Score")]
    public partial class Score
    {
        public int Id { get; set; }

        public int? UserID { get; set; }

        [Column("Score")]
        [StringLength(50)]
        public string Score1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? Exercise_Id { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual User User { get; set; }
    }
}

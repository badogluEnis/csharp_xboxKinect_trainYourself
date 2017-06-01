namespace Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This Class is from the Entity Frame work. Here you can find the Attributs from the Table Score. 
    /// </summary>
    [Table("Score")]
    public class Score
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int? UserID { get; set; }

        /// <summary>
        /// Gets or sets the score1.
        /// </summary>
        /// <value>
        /// The score1.
        /// </value>
        [Column("Score")]
        public int Score1 { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the exercise identifier.
        /// </summary>
        /// <value>
        /// The exercise identifier.
        /// </value>
        public int? Exercise_Id { get; set; }

        /// <summary>
        /// Gets or sets the exercise.
        /// </summary>
        /// <value>
        /// The exercise.
        /// </value>
        public virtual Exercise Exercise { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual User User { get; set; }
    }
}

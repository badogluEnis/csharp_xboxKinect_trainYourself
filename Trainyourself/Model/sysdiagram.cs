namespace Model
{
    using System.ComponentModel.DataAnnotations;

    public class sysdiagram
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public int PrincipalId { get; set; }

        [Key]
        public int DiagramId { get; set; }

        public int? Version { get; set; }

        public byte[] Definition { get; set; }
    }
}

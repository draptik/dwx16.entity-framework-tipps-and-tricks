namespace GO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin.Metadaten")]
    public partial class Metadaten
    {
        [Key]
        [StringLength(20)]
        public string Name { get; set; }

        public string Value { get; set; }

        [Required]
        [MaxLength(8)]
        public byte[] Timestamp { get; set; }

        [StringLength(100)]
        public string Memo { get; set; }
    }
}

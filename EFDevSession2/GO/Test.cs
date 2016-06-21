namespace GO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin.Test")]
    public partial class Test
    {
        [Key]
        [Column("Test")]
        [StringLength(10)]
        public string Test1 { get; set; }

        [StringLength(10)]
        public string Event { get; set; }
    }
}

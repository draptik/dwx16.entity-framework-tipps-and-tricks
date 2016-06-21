namespace GO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Immobilien.Flughafen")]
    public partial class Flughafen
    {
        [Key]
        [StringLength(30)]
        public string Name { get; set; }

        public DbGeography Position { get; set; }

        public int? Typ { get; set; }
    }
}

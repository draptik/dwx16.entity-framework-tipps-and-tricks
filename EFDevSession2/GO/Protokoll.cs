namespace GO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin.Protokoll")]
    public partial class Protokoll
    {
        public int ID { get; set; }

        public DateTime Zeit { get; set; }

        public string Computer { get; set; }

        public string Benutzer { get; set; }

        public string Text { get; set; }

        [StringLength(50)]
        public string Entity { get; set; }

        [StringLength(50)]
        public string Attribut { get; set; }

        [StringLength(50)]
        public string Aktion { get; set; }

        public int? EntityID { get; set; }

        public string AlterWert { get; set; }

        public string NeuerWert { get; set; }
    }
}

namespace GO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Betrieb.Pilot")]
    public partial class Pilot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pilot()
        {
            Flug = new HashSet<Flug>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }

        public DateTime? FlugscheinSeit { get; set; }

        [StringLength(1)]
        public string Flugscheintyp { get; set; }

        public int? Flugstunden { get; set; }

        [StringLength(50)]
        public string Flugschule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flug> Flug { get; set; }

        public virtual Mitarbeiter Mitarbeiter { get; set; }
    }
}

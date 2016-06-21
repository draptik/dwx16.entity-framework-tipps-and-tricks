namespace GO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Betrieb.Mitarbeiter")]
    public partial class Mitarbeiter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mitarbeiter()
        {
            Mitarbeiter1 = new HashSet<Mitarbeiter>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }

        public int? MitarbeiterNr { get; set; }

        public DateTime? Einstellungsdatum { get; set; }

        public int? VorgesetzterPersonID { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mitarbeiter> Mitarbeiter1 { get; set; }

        public virtual Mitarbeiter Mitarbeiter2 { get; set; }

        public virtual Pilot Pilot { get; set; }
    }
}

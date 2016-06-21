namespace GO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Betrieb.Flug")]
    public partial class Flug
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flug()
        {
            Passagier = new HashSet<Passagier>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlugNr { get; set; }

        [Required]
        [StringLength(20)]
        public string Abflugort { get; set; }

        [Required]
        [StringLength(20)]
        public string Zielort { get; set; }

        public DateTime Datum { get; set; }

        public bool NichtRaucherFlug { get; set; }

        public short? Plaetze { get; set; }

        public short? FreiePlaetze { get; set; }

        public int? Pilot_PersonID { get; set; }

        public DateTime? Ankunft { get; set; }

        public string Memo { get; set; }

        public bool? Bestreikt { get; set; }

        public decimal? Auslastung { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] Timestamp { get; set; }

        [StringLength(10)]
        public string test { get; set; }

        public virtual Pilot Pilot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passagier> Passagier { get; set; }
    }
}

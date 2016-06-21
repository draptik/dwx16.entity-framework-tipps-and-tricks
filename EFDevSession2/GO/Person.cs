namespace GO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Betrieb.Person")]
    public partial class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Vorname { get; set; }

        [StringLength(2)]
        public string Land { get; set; }

        public DateTime? Geburtstag { get; set; }

        public byte[] Foto { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }

        [StringLength(30)]
        public string Stadt { get; set; }

        public string Memo { get; set; }

        [StringLength(30)]
        public string Geburtsort { get; set; }

        public virtual Mitarbeiter Mitarbeiter { get; set; }

        public virtual Passagier Passagier { get; set; }
    }
}

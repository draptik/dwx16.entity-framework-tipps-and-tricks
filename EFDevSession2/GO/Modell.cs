namespace GO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modell : DbContext
    {
        public Modell()
            : base("name=Modell")
        {
        }

        public virtual DbSet<Metadaten> Metadaten { get; set; }
        public virtual DbSet<Protokoll> Protokoll { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Flug> Flug { get; set; }
        public virtual DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public virtual DbSet<Passagier> Passagier { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Pilot> Pilot { get; set; }
        public virtual DbSet<Flughafen> Flughafen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Metadaten>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<Metadaten>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<Protokoll>()
                .Property(e => e.Computer)
                .IsUnicode(false);

            modelBuilder.Entity<Protokoll>()
                .Property(e => e.Benutzer)
                .IsUnicode(false);

            modelBuilder.Entity<Protokoll>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Protokoll>()
                .Property(e => e.AlterWert)
                .IsUnicode(false);

            modelBuilder.Entity<Protokoll>()
                .Property(e => e.NeuerWert)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.Test1)
                .IsFixedLength();

            modelBuilder.Entity<Test>()
                .Property(e => e.Event)
                .IsFixedLength();

            modelBuilder.Entity<Flug>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Flug>()
                .Property(e => e.Auslastung)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Flug>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<Flug>()
                .Property(e => e.test)
                .IsFixedLength();

            modelBuilder.Entity<Flug>()
                .HasMany(e => e.Passagier)
                .WithMany(e => e.Flug)
                .Map(m => m.ToTable("Flug_Passagier", "Betrieb"));

            modelBuilder.Entity<Mitarbeiter>()
                .HasMany(e => e.Mitarbeiter1)
                .WithOptional(e => e.Mitarbeiter2)
                .HasForeignKey(e => e.VorgesetzterPersonID);

            modelBuilder.Entity<Mitarbeiter>()
                .HasOptional(e => e.Pilot)
                .WithRequired(e => e.Mitarbeiter);

            modelBuilder.Entity<Passagier>()
                .Property(e => e.KundenStatus)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Mitarbeiter)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Passagier)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Pilot>()
                .Property(e => e.Flugscheintyp)
                .IsFixedLength();

            modelBuilder.Entity<Pilot>()
                .HasMany(e => e.Flug)
                .WithOptional(e => e.Pilot)
                .HasForeignKey(e => e.Pilot_PersonID);

            modelBuilder.Entity<Flughafen>()
                .Property(e => e.Name)
                .IsFixedLength();
        }
    }
}

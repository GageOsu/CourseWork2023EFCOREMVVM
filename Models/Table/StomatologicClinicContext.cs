using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Models.Table;

public partial class StomatologicClinicContext : DbContext
{
    public StomatologicClinicContext()
    {
    }

    public StomatologicClinicContext(DbContextOptions<StomatologicClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<RegistrationService> RegistrationServices { get; set; }

    public virtual DbSet<ServicePriceHistory> ServicePriceHistories { get; set; }

    public virtual DbSet<TypeService> TypeServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GAGEOSULAPTOP;Database=StomatologicClinic; Trusted_Connection=true; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Idaccount).HasName("PK_Account_ID");

            entity.HasIndex(e => e.Login, "UQ_Account_Login").IsUnique();

            entity.Property(e => e.Idaccount).HasColumnName("IDAccount");
            entity.Property(e => e.Idemployee).HasColumnName("IDEmployee");
            entity.Property(e => e.Login).HasMaxLength(15);
            entity.Property(e => e.Password).HasMaxLength(15);

            entity.HasOne(d => d.IdemployeeNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Idemployee)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Accounts_Employees");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Idadresses).HasName("PK_Adresse_ID");

            entity.Property(e => e.Idadresses).HasColumnName("IDAdresses");
            entity.Property(e => e.Building)
                .HasMaxLength(11)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.Flat)
                .HasMaxLength(11)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(11)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.Locality)
                .HasMaxLength(65)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.NameSubject)
                .HasMaxLength(40)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Settlement)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.Structure)
                .HasMaxLength(11)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.TypeLocality).HasMaxLength(20);
            entity.Property(e => e.TypeLocation)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.TypeSettlement)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.TypeSubject).HasMaxLength(30);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategory).HasName("PK_Category_ID");

            entity.HasIndex(e => e.Category1, "UQ_Category_Category").IsUnique();

            entity.Property(e => e.Idcategory).HasColumnName("IDCategory");
            entity.Property(e => e.Category1)
                .HasMaxLength(25)
                .HasColumnName("Category");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Idemployee).HasName("PK_Employee_ID");

            entity.Property(e => e.Idemployee).HasColumnName("IDEmployee");
            entity.Property(e => e.Idposition).HasColumnName("IDPosition");
            entity.Property(e => e.MiddleNameEmployee)
                .HasMaxLength(36)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.NameEmployee).HasMaxLength(15);
            entity.Property(e => e.SurnameEmployee).HasMaxLength(23);

            entity.HasOne(d => d.IdpositionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Idposition)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Employees_Positions1");
        });

        modelBuilder.Entity<InsurancePolicy>(entity =>
        {
            entity.HasKey(e => e.IdinsurancePolicy).HasName("PK_InsurancePolicy_ID");

            entity.HasIndex(e => e.MhipolicyNumber, "UQ_InsurancePolicy_MHIPolicyNumber").IsUnique();

            entity.Property(e => e.IdinsurancePolicy).HasColumnName("IDInsurancePolicy");
            entity.Property(e => e.MhipolicyNumber)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("MHIPolicyNumber");
            entity.Property(e => e.NameInsuranceCompany).HasMaxLength(160);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Idpatient).HasName("PK_Patient_ID");

            entity.HasIndex(e => e.PassportNumber, "UQ_Patient_PassportNumber").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ_Patient_PhoneNumber").IsUnique();

            entity.Property(e => e.Idpatient)
                .ValueGeneratedNever()
                .HasColumnName("IDPatient");
            entity.Property(e => e.DateBrith).HasColumnType("date");
            entity.Property(e => e.Idadresses).HasColumnName("IDAdresses");
            entity.Property(e => e.IdinsurancePolicy).HasColumnName("IDInsurancePolicy");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(36)
                .HasDefaultValueSql("('Отсутствует')");
            entity.Property(e => e.Name).HasMaxLength(15);
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.Sex)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.SnilsNumber)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.Surname).HasMaxLength(23);

            entity.HasOne(d => d.IdadressesNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.Idadresses)
                .HasConstraintName("FK_Patients_Addresses");

            entity.HasOne(d => d.IdinsurancePolicyNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.IdinsurancePolicy)
                .HasConstraintName("FK_Patients_InsurancePolicies");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Idposition).HasName("PK_Position_ID");

            entity.HasIndex(e => e.Position1, "UQ_Position_Position").IsUnique();

            entity.Property(e => e.Idposition).HasColumnName("IDPosition");
            entity.Property(e => e.Position1)
                .HasMaxLength(23)
                .HasColumnName("Position");
        });

        modelBuilder.Entity<RegistrationService>(entity =>
        {
            entity.HasKey(e => e.IdserviceRegistration).HasName("PK_RegistrationServices_ID");

            entity.Property(e => e.IdserviceRegistration)
                .ValueGeneratedNever()
                .HasColumnName("IDServiceRegistration");
            entity.Property(e => e.DateOfService).HasColumnType("date");
            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Idemployee).HasColumnName("IDEmployee");
            entity.Property(e => e.Idpatient).HasColumnName("IDPatient");
            entity.Property(e => e.Idservice).HasColumnName("IDService");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdpatientNavigation).WithMany(p => p.RegistrationServices)
                .HasForeignKey(d => d.Idpatient)
                .HasConstraintName("FK_RegistrationServices_Patients");

            entity.HasOne(d => d.IdserviceNavigation).WithMany(p => p.RegistrationServices)
                .HasForeignKey(d => d.Idservice)
                .HasConstraintName("FK_RegistrationServices_TypeServices");

            entity.HasOne(d => d.IdserviceRegistrationNavigation).WithOne(p => p.RegistrationService)
                .HasForeignKey<RegistrationService>(d => d.IdserviceRegistration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrationServices_Employees");
        });

        modelBuilder.Entity<ServicePriceHistory>(entity =>
        {
            entity.HasKey(e => e.IdpriceHistory).HasName("PK_ServicePriceHistory_ID");

            entity.ToTable("ServicePriceHistory");

            entity.Property(e => e.IdpriceHistory).HasColumnName("IDPriceHistory");
            entity.Property(e => e.DatePriceChange)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idservice).HasColumnName("IDService");
            entity.Property(e => e.NewPrice).HasColumnType("money");
            entity.Property(e => e.OldPrice).HasColumnType("money");

            entity.HasOne(d => d.IdserviceNavigation).WithMany(p => p.ServicePriceHistories)
                .HasForeignKey(d => d.Idservice)
                .HasConstraintName("FK_ServicePriceHistory_TypeServices");
        });

        modelBuilder.Entity<TypeService>(entity =>
        {
            entity.HasKey(e => e.Idservice).HasName("PK_TypeService_ID");

            entity.ToTable(tb => tb.HasTrigger("ServicePriceHistory_UPDATE"));

            entity.HasIndex(e => e.NameService, "UQ_TypeService_NameService").IsUnique();

            entity.Property(e => e.Idservice).HasColumnName("IDService");
            entity.Property(e => e.Idcategory).HasColumnName("IDCategory");
            entity.Property(e => e.NameService).HasMaxLength(250);
            entity.Property(e => e.PriceService).HasColumnType("money");

            entity.HasOne(d => d.IdcategoryNavigation).WithMany(p => p.TypeServices)
                .HasForeignKey(d => d.Idcategory)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TypeServices_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

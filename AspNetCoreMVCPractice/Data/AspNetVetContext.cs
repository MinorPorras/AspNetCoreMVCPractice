using System;
using System.Collections.Generic;
using AspNetCoreMVCPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Data;

public partial class AspNetVetContext : DbContext
{
    public AspNetVetContext()
    {
    }

    public AspNetVetContext(DbContextOptions<AspNetVetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentType> AppointmentTypes { get; set; }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<ClinicalProcedure> ClinicalProcedures { get; set; }

    public virtual DbSet<InventoryItemType> InventoryItemTypes { get; set; }

    public virtual DbSet<InventoryMovement> InventoryMovements { get; set; }

    public virtual DbSet<InvoicesDetail> InvoicesDetails { get; set; }

    public virtual DbSet<InvoicesMaster> InvoicesMasters { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Kardex> Kardices { get; set; }

    public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<MedicineTreatment> MedicineTreatments { get; set; }

    public virtual DbSet<MedicineType> MedicineTypes { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<VetSpeciality> VetSpecialities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-J4DG90L\\SQLEXPRESS;Initial Catalog=AspNetVet;Integrated Security=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AppUsers_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Roles).WithMany(p => p.AppUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppUsers_Roles");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Appointments_Id");

            entity.HasOne(d => d.AppointmentTypes).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Types");

            entity.HasOne(d => d.Customer).WithMany(p => p.AppointmentCustomers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Customer");

            entity.HasOne(d => d.Pets).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Pets");

            entity.HasOne(d => d.Statuses).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Status");

            entity.HasOne(d => d.Vet).WithMany(p => p.AppointmentVets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Vet");
        });

        modelBuilder.Entity<AppointmentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Appointment_Types_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Breed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Breeds_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Species).WithMany(p => p.Breeds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Breeds_Species");
        });

        modelBuilder.Entity<ClinicalProcedure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Clinical_Procedures_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.AppUsers).WithMany(p => p.ClinicalProcedures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinical_Procedures_AppUsers");
        });

        modelBuilder.Entity<InventoryItemType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Inventory_Item_Types_Id");
        });

        modelBuilder.Entity<InventoryMovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Inventory_Movements_Id");

            entity.Property(e => e.DateOfMovement).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AppUsers).WithMany(p => p.InventoryMovements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Movements_AppUsers");

            entity.HasOne(d => d.ItemType).WithMany(p => p.InventoryMovements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Movements_Item_Type");

            entity.HasOne(d => d.Suppliers).WithMany(p => p.InventoryMovements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Movements_Suppliers");
        });

        modelBuilder.Entity<InvoicesDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Invoices_Detail_Id");

            entity.HasOne(d => d.InvoicesMaster).WithMany(p => p.InvoicesDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Detail_Master");

            entity.HasOne(d => d.ItemType).WithMany(p => p.InvoicesDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Detail_Item_Type");
        });

        modelBuilder.Entity<InvoicesMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Invoices_Master_Id");

            entity.Property(e => e.InvoiceDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoicesMasterCustomers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Master_Customer");

            entity.HasOne(d => d.GeneratedByNavigation).WithMany(p => p.InvoicesMasterGeneratedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Master_Generated_By");

            entity.HasOne(d => d.PaymentMethods).WithMany(p => p.InvoicesMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Master_Payment_Method");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Item_Types_Id");
        });

        modelBuilder.Entity<Kardex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Kardex_Id");

            entity.Property(e => e.DateOfMovement).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ItemType).WithMany(p => p.Kardices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kardex_Item_Type");
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Medical_History_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.VisitDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AppUsers).WithMany(p => p.MedicalHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medical_History_AppUsers");

            entity.HasOne(d => d.Pets).WithMany(p => p.MedicalHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medical_History_Pets");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Medicines_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.MedicineTypes).WithMany(p => p.Medicines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicines_Types");

            entity.HasOne(d => d.Suppliers).WithMany(p => p.Medicines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicines_Suppliers");
        });

        modelBuilder.Entity<MedicineTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Medicine_Treatments_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.TreatmentDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AppUsers).WithMany(p => p.MedicineTreatments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Treatments_Medicine_AppUsers");

            entity.HasOne(d => d.Medicines).WithMany(p => p.MedicineTreatments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Treatments_Medicines");

            entity.HasOne(d => d.Pets).WithMany(p => p.MedicineTreatments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Treatments_Pets");
        });

        modelBuilder.Entity<MedicineType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Medicine_Types_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Payment_Methods_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pets_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.AppUsers).WithMany(p => p.Pets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_AppUsers");

            entity.HasOne(d => d.Breeds).WithMany(p => p.Pets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_Breeds");

            entity.HasOne(d => d.Species).WithMany(p => p.Pets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_Species");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Products_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.ProductTypes).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Types");

            entity.HasOne(d => d.Suppliers).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Product_Types_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Roles_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Species_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Statuses_Id");

            entity.Property(e => e.Status1).HasDefaultValue(true);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Suppliers_Id");

            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserNavigation).WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppUsers_Id");
        });

        modelBuilder.Entity<VetSpeciality>(entity =>
        {
            entity.Property(e => e.IdVet).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdSpecialityNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Speciality_Id");

            entity.HasOne(d => d.IdVetNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vet_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

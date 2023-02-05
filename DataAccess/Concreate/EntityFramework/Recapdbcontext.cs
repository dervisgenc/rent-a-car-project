using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public partial class Recapdbcontext : DbContext
    {
        public Recapdbcontext()
        {
        }

        public Recapdbcontext(DbContextOptions<Recapdbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Firm> Firms { get; set; }

        public virtual DbSet<Rental> Rentals { get; set; }

        public virtual DbSet<CarPicture> CarPictures { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=recapdatabase;Username=postgres;Password=1246");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrandId).HasName("brands_pkey");

                entity.ToTable("brands");

                entity.Property(e => e.BrandId)
                    .HasIdentityOptions(null, null, null, 99999L, null, null)
                    .HasColumnName("brand_id");
                entity.Property(e => e.BrandName).HasColumnName("brand_name");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarId).HasName("cars_pkey");

                entity.ToTable("cars");

                entity.Property(e => e.CarId)
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 99999L, null, null)
                    .HasColumnName("car_id");
                entity.Property(e => e.BrandId).HasColumnName("brand_id");
                entity.Property(e => e.ColorId).HasColumnName("color_id");
                entity.Property(e => e.DailyPrice)
                    .HasColumnType("money")
                    .HasColumnName("daily_price");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.FirmId).HasColumnName("firm_id");
                entity.Property(e => e.Year).HasColumnName("year");
                entity.Property(e => e.isAvailable)
                    .HasColumnName("is_available")
                    .HasColumnType("boolean");
                    

                entity.HasOne(d => d.Brand).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cars_brand-id_fkey");

                entity.HasOne(d => d.Color).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cars_color-id_fkey");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId).HasName("colors_pkey");

                entity.ToTable("colors");

                entity.Property(e => e.ColorId)
                    .HasIdentityOptions(null, null, null, 99999L, null, null)
                    .HasColumnName("color_id");
                entity.Property(e => e.ColorName).HasColumnName("color_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {

                entity.ToTable("customers");

                entity.Property(e => e.CustomerId)
                    .HasIdentityOptions(null, null, null, 99999L, null, null)
                    .HasColumnName("customer_id");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.IdentityNumber).HasColumnName("identity_number");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<Firm>(entity =>
            {

                entity.ToTable("firms");

                entity.Property(e => e.FirmId)
                    .HasIdentityOptions(null, null, null, 99999L, null, null)
                    .HasColumnName("firm_id");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.FirmName).HasColumnName("firm_name");
                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => e.RentalId).HasName("rentals_pkey");

                entity.ToTable("rentals");

                entity.Property(e => e.RentalId)
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 99999L, null, null)
                    .HasColumnName("rental_id");
                entity.Property(e => e.CarId).HasColumnName("car_id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.FirmId).HasColumnName("firm_id");
                entity.Property(e => e.RentDate).HasColumnName("rent_date");
                entity.Property(e => e.ReturnDate).HasColumnName("return_date");

                entity.HasOne(d => d.Car).WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rentals_car_id_fkey");

                entity.HasOne(d => d.Customer).WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rentals_customer_id_fkey");

                entity.HasOne(d => d.Firm).WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rentals_firm_id_fkey");
            });

            modelBuilder.Entity<CarPicture>(entity =>
            {
                entity.HasKey(e => e.PictureId).HasName("car_pictures_pkey");

                entity.ToTable("car_pictures");

                entity.Property(e => e.PictureId)
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 99999L, null, null)
                    .HasColumnName("picture_id");
                entity.Property(e => e.CarId).HasColumnName("car_id");
                entity.Property(e => e.ImagePath).HasColumnName("image_path");
                entity.Property(e => e.Date).HasColumnName("date");

                entity.HasOne(d => d.Car).WithMany(p => p.CarPictures)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pictures_car_id_fkey");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

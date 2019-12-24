using System;
using CryptoCityWallet.Entities.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CryptoCityWallet.DataAccessLayer
{
    public partial class dbWorldCCityContext : DbContext
    {
        public dbWorldCCityContext()
        {
        }

        public dbWorldCCityContext(DbContextOptions<dbWorldCCityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAddressCity> TblAddressCity { get; set; }
        public virtual DbSet<TblAddressCountry> TblAddressCountry { get; set; }
        public virtual DbSet<TblAppSystem> TblAppSystem { get; set; }
        public virtual DbSet<TblAuditFields> TblAuditFields { get; set; }
        public virtual DbSet<TblBusinessPackage> TblBusinessPackage { get; set; }
        public virtual DbSet<TblBusinessPackageType> TblBusinessPackageType { get; set; }
        public virtual DbSet<TblClosedTransaction> TblClosedTransaction { get; set; }
        public virtual DbSet<TblCurrency> TblCurrency { get; set; }
        public virtual DbSet<TblDividend> TblDividend { get; set; }
        public virtual DbSet<TblExchangeRate> TblExchangeRate { get; set; }
        public virtual DbSet<TblIncomeDistribution> TblIncomeDistribution { get; set; }
        public virtual DbSet<TblIncomeType> TblIncomeType { get; set; }
        public virtual DbSet<TblUserAddress> TblUserAddress { get; set; }
        public virtual DbSet<TblUserAuth> TblUserAuth { get; set; }
        public virtual DbSet<TblUserAuthHistory> TblUserAuthHistory { get; set; }
        public virtual DbSet<TblUserBonus> TblUserBonus { get; set; }
        public virtual DbSet<TblUserBusinessPackage> TblUserBusinessPackage { get; set; }
        public virtual DbSet<TblUserDepositRequest> TblUserDepositRequest { get; set; }
        public virtual DbSet<TblUserIncomePartition> TblUserIncomePartition { get; set; }
        public virtual DbSet<TblUserIncomeTransaction> TblUserIncomeTransaction { get; set; }
        public virtual DbSet<TblUserInfo> TblUserInfo { get; set; }
        public virtual DbSet<TblUserMap> TblUserMap { get; set; }
        public virtual DbSet<TblUserRank> TblUserRank { get; set; }
        public virtual DbSet<TblUserRole> TblUserRole { get; set; }
        public virtual DbSet<TblUserVolumes> TblUserVolumes { get; set; }
        public virtual DbSet<TblUserWallet> TblUserWallet { get; set; }
        public virtual DbSet<TblUserWalletAddress> TblUserWalletAddress { get; set; }
        public virtual DbSet<TblUserWalletTransaction> TblUserWalletTransaction { get; set; }
        public virtual DbSet<TblUserWithdrawalRequest> TblUserWithdrawalRequest { get; set; }
        public virtual DbSet<TblWalletType> TblWalletType { get; set; }
        public virtual DbSet<VClose> VClose { get; set; }
        public virtual DbSet<VMember> VMember { get; set; }
        public virtual DbSet<VOrder> VOrder { get; set; }
        public virtual DbSet<VUserData> VUserData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=dbworldccity.caxbcdtsfhob.ap-southeast-1.rds.amazonaws.com;Database=dbWorldCCity;Username=dbAdmin;Password=Jr2Ge4FvY!=Z5u!^");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAddressCity>(entity =>
            {
                entity.ToTable("tbl_AddressCity", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Latitude).HasColumnType("numeric(18,10)");

                entity.Property(e => e.Longitude).HasColumnType("numeric(18,10)");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.PostalCode).HasMaxLength(16);
            });

            modelBuilder.Entity<TblAddressCountry>(entity =>
            {
                entity.ToTable("tbl_AddressCountry", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.IsoCode2).HasMaxLength(2);

                entity.Property(e => e.IsoCode3).HasMaxLength(3);

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneCountryCode).HasMaxLength(9);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TblAddressCountry)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("CurrencyID");
            });

            modelBuilder.Entity<TblAppSystem>(entity =>
            {
                entity.ToTable("tbl_AppSystem", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PublicByte).IsRequired();

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblAuditFields>(entity =>
            {
                entity.ToTable("tbl_AuditFields", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<TblBusinessPackage>(entity =>
            {
                entity.ToTable("tbl_BusinessPackage", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PackageCode).HasMaxLength(16);

                entity.Property(e => e.PackageDescription).HasMaxLength(500);

                entity.Property(e => e.PackageName).HasMaxLength(100);

                entity.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");

                entity.Property(e => e.ValueFrom).HasColumnType("numeric(18,8)");

                entity.Property(e => e.ValueTo).HasColumnType("numeric(18,8)");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TblBusinessPackage)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("CurrencyID");

                entity.HasOne(d => d.PackageType)
                    .WithMany(p => p.TblBusinessPackage)
                    .HasForeignKey(d => d.PackageTypeId)
                    .HasConstraintName("PackageTypeID");
            });

            modelBuilder.Entity<TblBusinessPackageType>(entity =>
            {
                entity.ToTable("tbl_BusinessPackageType", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TblClosedTransaction>(entity =>
            {
                entity.ToTable("tbl_ClosedTransaction", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<TblCurrency>(entity =>
            {
                entity.ToTable("tbl_Currency", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CurrencyIsoCode3)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TblDividend>(entity =>
            {
                entity.ToTable("tbl_Dividend", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DividendPrice).HasColumnType("numeric(18,10)");

                entity.Property(e => e.DividendRate).HasColumnType("numeric(18,10)");

                entity.Property(e => e.DividendUserAuthId).HasColumnName("DividendUserAuthID");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.DividendUserAuth)
                    .WithMany(p => p.TblDividend)
                    .HasForeignKey(d => d.DividendUserAuthId)
                    .HasConstraintName("tbl_dividend_fk");
            });

            modelBuilder.Entity<TblExchangeRate>(entity =>
            {
                entity.ToTable("tbl_ExchangeRate", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.EffectivityDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ExpiryDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Fee).HasColumnType("numeric(18,10)");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.SourceCurrencyId).HasColumnName("SourceCurrencyID");

                entity.Property(e => e.TargetCurrencyId).HasColumnName("TargetCurrencyID");

                entity.Property(e => e.Value).HasColumnType("numeric(18,10)");

                entity.HasOne(d => d.SourceCurrency)
                    .WithMany(p => p.TblExchangeRateSourceCurrency)
                    .HasForeignKey(d => d.SourceCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SourceCurrencyID");

                entity.HasOne(d => d.TargetCurrency)
                    .WithMany(p => p.TblExchangeRateTargetCurrency)
                    .HasForeignKey(d => d.TargetCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TargetCurrencyID");
            });

            modelBuilder.Entity<TblIncomeDistribution>(entity =>
            {
                entity.ToTable("tbl_IncomeDistribution", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BusinessPackageId).HasColumnName("BusinessPackageID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DistributionType)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.IncomeTypeId).HasColumnName("IncomeTypeID");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Value).HasColumnType("numeric(18,10)");

                entity.HasOne(d => d.BusinessPackage)
                    .WithMany(p => p.TblIncomeDistribution)
                    .HasForeignKey(d => d.BusinessPackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BusinessPackageID");

                entity.HasOne(d => d.IncomeType)
                    .WithMany(p => p.TblIncomeDistribution)
                    .HasForeignKey(d => d.IncomeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IncomeTypeID");
            });

            modelBuilder.Entity<TblIncomeType>(entity =>
            {
                entity.ToTable("tbl_IncomeType", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.IncomePercentage).HasColumnType("numeric(18,10)");

                entity.Property(e => e.IncomeShortName).HasMaxLength(50);

                entity.Property(e => e.IncomeTypeCode)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.IncomeTypeDescription).HasMaxLength(500);

                entity.Property(e => e.IncomeTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<TblUserAddress>(entity =>
            {
                entity.ToTable("tbl_UserAddress", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.CountryIsoCode2).HasMaxLength(2);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.StateName).HasColumnType("bit varying(50)[]");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserAddress)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserAuth>(entity =>
            {
                entity.ToTable("tbl_UserAuth", "dbo");

                entity.HasIndex(e => e.UserName)
                    .HasName("Username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ResetPasswordCodeExpiration).HasColumnType("timestamp with time zone");

                entity.Property(e => e.TemporaryPassword).HasMaxLength(256);

                entity.Property(e => e.UserAlias).HasMaxLength(256);

                entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.UserInfo)
                    .WithMany(p => p.TblUserAuth)
                    .HasForeignKey(d => d.UserInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_UserAuth_UserInfoID_fkey");
            });

            modelBuilder.Entity<TblUserAuthHistory>(entity =>
            {
                entity.ToTable("tbl_UserAuthHistory", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(18);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LoginSource).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserAuthHistory)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_userauthhistory_fk");
            });

            modelBuilder.Entity<TblUserBonus>(entity =>
            {
                entity.ToTable("tbl_UserBonus", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BonusName).HasMaxLength(45);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserBonus)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_userbonus_fk");
            });

            modelBuilder.Entity<TblUserBusinessPackage>(entity =>
            {
                entity.ToTable("tbl_UserBusinessPackage", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActivationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.BusinessPackageId).HasColumnName("BusinessPackageID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ExpiryDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");

                entity.Property(e => e.UserDepositRequestId).HasColumnName("UserDepositRequestID");

                entity.HasOne(d => d.BusinessPackage)
                    .WithMany(p => p.TblUserBusinessPackage)
                    .HasForeignKey(d => d.BusinessPackageId)
                    .HasConstraintName("BusinessPackageID");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserBusinessPackage)
                    .HasForeignKey(d => d.UserAuthId)
                    .HasConstraintName("UserAuthID");

                entity.HasOne(d => d.UserDepositRequest)
                    .WithMany(p => p.TblUserBusinessPackage)
                    .HasForeignKey(d => d.UserDepositRequestId)
                    .HasConstraintName("UserDepositRequestID");
            });

            modelBuilder.Entity<TblUserDepositRequest>(entity =>
            {
                entity.ToTable("tbl_UserDepositRequest", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Amount).HasColumnType("numeric(18,10)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ExpiryDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");

                entity.HasOne(d => d.SourceCurrency)
                    .WithMany(p => p.TblUserDepositRequest)
                    .HasForeignKey(d => d.SourceCurrencyId)
                    .HasConstraintName("SourceCurrencyId");

                entity.HasOne(d => d.TargetWalletType)
                    .WithMany(p => p.TblUserDepositRequest)
                    .HasForeignKey(d => d.TargetWalletTypeId)
                    .HasConstraintName("TargetWalletTypeId");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserDepositRequest)
                    .HasForeignKey(d => d.UserAuthId)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserIncomePartition>(entity =>
            {
                entity.ToTable("tbl_UserIncomePartition", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Percentage).HasColumnType("numeric(18,8)");

                entity.HasOne(d => d.IncomeType)
                    .WithMany(p => p.TblUserIncomePartition)
                    .HasForeignKey(d => d.IncomeTypeId)
                    .HasConstraintName("IncomeTypeId");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.TblUserIncomePartition)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("UserRoleId");
            });

            modelBuilder.Entity<TblUserIncomeTransaction>(entity =>
            {
                entity.ToTable("tbl_UserIncomeTransaction", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.IncomePercentage).HasColumnType("numeric(18,10)");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserIncomeTransaction)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserInfo>(entity =>
            {
                entity.ToTable("tbl_UserInfo", "dbo");

                entity.HasIndex(e => e.Email)
                    .HasName("Email")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.ConfirmedEmail).HasMaxLength(50);

                entity.Property(e => e.CountryIsoCode2).HasMaxLength(2);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PhoneNumber).HasMaxLength(24);

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("UID")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblUserMap>(entity =>
            {
                entity.ToTable("tbl_UserMap", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UserUid)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TblUserMapIdNavigation)
                    .HasForeignKey<TblUserMap>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");

                entity.HasOne(d => d.SponsorUser)
                    .WithMany(p => p.TblUserMapSponsorUser)
                    .HasForeignKey(d => d.SponsorUserId)
                    .HasConstraintName("SponsorUserId");

                entity.HasOne(d => d.UplineUser)
                    .WithMany(p => p.TblUserMapUplineUser)
                    .HasForeignKey(d => d.UplineUserId)
                    .HasConstraintName("UplineUserId");
            });

            modelBuilder.Entity<TblUserRank>(entity =>
            {
                entity.ToTable("tbl_UserRank", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.RankName).HasMaxLength(20);

                entity.Property(e => e.RankRateAffiliate).HasColumnType("numeric(18,10)");

                entity.Property(e => e.RankRateBinary).HasColumnType("numeric(18,10)");

                entity.Property(e => e.RankRateDaily).HasColumnType("numeric(18,10)");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserRank)
                    .HasForeignKey(d => d.UserAuthId)
                    .HasConstraintName("UserAuthId");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity.ToTable("tbl_UserRole", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AccessRole).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserRole)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_UserRole_UserAuthID_fkey");
            });

            modelBuilder.Entity<TblUserVolumes>(entity =>
            {
                entity.ToTable("tbl_UserVolumes", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.MemberRankCd).HasColumnName("MemberRankCD");

                entity.Property(e => e.MemberVolumeLeft).HasColumnType("numeric(18,10)");

                entity.Property(e => e.MemberVolumeOwn).HasColumnType("numeric(18,10)");

                entity.Property(e => e.MemberVolumeRight).HasColumnType("numeric(18,10)");

                entity.Property(e => e.MemberVolumeUni).HasColumnType("numeric(18,10)");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserVolumes)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthId");
            });

            modelBuilder.Entity<TblUserWallet>(entity =>
            {
                entity.ToTable("tbl_UserWallet", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Balance).HasColumnType("numeric(24,8)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserWallet)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_UserWallet_UserAuthId_fkey");

                entity.HasOne(d => d.WalletType)
                    .WithMany(p => p.TblUserWallet)
                    .HasForeignKey(d => d.WalletTypeId)
                    .HasConstraintName("tbl_UserWallet_WalletTypeId_fkey");
            });

            modelBuilder.Entity<TblUserWalletAddress>(entity =>
            {
                entity.ToTable("tbl_UserWalletAddress", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasMaxLength(512);

                entity.Property(e => e.Balance).HasColumnType("numeric(18,10)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CurrencyIsoCode3).HasMaxLength(3);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserWalletAddress)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserWalletTransaction>(entity =>
            {
                entity.ToTable("tbl_UserWalletTransaction", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Amount).HasColumnType("numeric(18,10)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.RunningBalance).HasColumnType("numeric(18,10)");

                entity.HasOne(d => d.SourceUserWallet)
                    .WithMany(p => p.TblUserWalletTransaction)
                    .HasForeignKey(d => d.SourceUserWalletId)
                    .HasConstraintName("SourceUserWalletId");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserWalletTransaction)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserWithdrawalRequest>(entity =>
            {
                entity.ToTable("tbl_UserWithdrawalRequest", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Remarks).HasColumnType("bit varying(500)");

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18,10)");

                entity.HasOne(d => d.SourceWalletType)
                    .WithMany(p => p.TblUserWithdrawalRequest)
                    .HasForeignKey(d => d.SourceWalletTypeId)
                    .HasConstraintName("SourceWalletTypeId");

                entity.HasOne(d => d.TargetCurrency)
                    .WithMany(p => p.TblUserWithdrawalRequest)
                    .HasForeignKey(d => d.TargetCurrencyId)
                    .HasConstraintName("TargetCurrencyId");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserWithdrawalRequest)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblWalletType>(entity =>
            {
                entity.ToTable("tbl_WalletType", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.Desc).HasMaxLength(500);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TblWalletType)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("CurrencyID");
            });

            modelBuilder.Entity<VClose>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_close", "dbo");

                entity.Property(e => e.CloseDevidend).HasColumnType("numeric");
            });

            modelBuilder.Entity<VMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_member", "dbo");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MemberRankCd).HasColumnName("MemberRankCD");

                entity.Property(e => e.MemberVolumeLeft).HasColumnType("numeric(18,10)");

                entity.Property(e => e.MemberVolumeOwn).HasColumnType("numeric(18,10)");

                entity.Property(e => e.MemberVolumeRight).HasColumnType("numeric(18,10)");

                entity.Property(e => e.MemberVolumeUni).HasColumnType("numeric(18,10)");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50);

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");
            });

            modelBuilder.Entity<VOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_order", "dbo");

                entity.Property(e => e.Amount).HasColumnType("numeric(18,10)");

                entity.Property(e => e.BusinessPackageId).HasColumnName("BusinessPackageID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");

                entity.Property(e => e.UserDepositRequestId).HasColumnName("UserDepositRequestID");

                entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");
            });

            modelBuilder.Entity<VUserData>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("v_UserData", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ResetPasswordCodeExpiration).HasColumnType("timestamp with time zone");

                entity.Property(e => e.TemporaryPassword).HasMaxLength(256);

                entity.Property(e => e.UserAlias).HasMaxLength(256);

                entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

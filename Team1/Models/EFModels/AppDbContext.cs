using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Team1.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext")
		{
		}

		public virtual DbSet<AdminRole> AdminRoles { get; set; }
		public virtual DbSet<AttractionCategory> AttractionCategories { get; set; }
		public virtual DbSet<AttractionContent> AttractionContents { get; set; }
		public virtual DbSet<AttractionImage> AttractionImages { get; set; }
		public virtual DbSet<AttractionOrder> AttractionOrders { get; set; }
		public virtual DbSet<AttractionOrderStatus> AttractionOrderStatuses { get; set; }
		public virtual DbSet<Attraction> Attractions { get; set; }
		public virtual DbSet<AttractionTicket> AttractionTickets { get; set; }
		public virtual DbSet<AttractionTicketStock> AttractionTicketStocks { get; set; }
		public virtual DbSet<AttractionTicketType> AttractionTicketTypes { get; set; }
		public virtual DbSet<AttrationOrderItem> AttrationOrderItems { get; set; }
		public virtual DbSet<BEAdmin> BEAdmins { get; set; }
		public virtual DbSet<CarBrand> CarBrands { get; set; }
		public virtual DbSet<CarEnergyType> CarEnergyTypes { get; set; }
		public virtual DbSet<CarModelImage> CarModelImages { get; set; }
		public virtual DbSet<CarModel> CarModels { get; set; }
		public virtual DbSet<CarOrder> CarOrders { get; set; }
		public virtual DbSet<CarOrderStatus> CarOrderStatuses { get; set; }
		public virtual DbSet<Car> Cars { get; set; }
		public virtual DbSet<CarStatus> CarStatuses { get; set; }
		public virtual DbSet<CarTransmission> CarTransmissions { get; set; }
		public virtual DbSet<City> Cities { get; set; }
		public virtual DbSet<CommentImage> CommentImages { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }
		public virtual DbSet<District> Districts { get; set; }
		public virtual DbSet<Gender> Genders { get; set; }
		public virtual DbSet<HotelCategory> HotelCategories { get; set; }
		public virtual DbSet<HotelImage> HotelImages { get; set; }
		public virtual DbSet<HotelOrderCancelReason> HotelOrderCancelReasons { get; set; }
		public virtual DbSet<HotelOrderItem> HotelOrderItems { get; set; }
		public virtual DbSet<HotelOrder> HotelOrders { get; set; }
		public virtual DbSet<HotelOrderStatus> HotelOrderStatuses { get; set; }
		public virtual DbSet<HotelRoomImage> HotelRoomImages { get; set; }
		public virtual DbSet<HotelRoom> HotelRooms { get; set; }
		public virtual DbSet<Hotel> Hotels { get; set; }
		public virtual DbSet<HotelType> HotelTypes { get; set; }
		public virtual DbSet<MemberActivityRecord> MemberActivityRecords { get; set; }
		public virtual DbSet<MemberLevel> MemberLevels { get; set; }
		public virtual DbSet<MemberPersonalInfo> MemberPersonalInfos { get; set; }
		public virtual DbSet<MemberProfile> MemberProfiles { get; set; }
		public virtual DbSet<Member> Members { get; set; }
		public virtual DbSet<PackageAttractionItem> PackageAttractionItems { get; set; }
		public virtual DbSet<PackageHotelRoomItem> PackageHotelRoomItems { get; set; }
		public virtual DbSet<PackageMemo> PackageMemos { get; set; }
		public virtual DbSet<PackageOrderStatus> PackageOrderStatuses { get; set; }
		public virtual DbSet<PackageOrde> PackageOrdes { get; set; }
		public virtual DbSet<Package> Packages { get; set; }
		public virtual DbSet<Permission> Permissions { get; set; }
		public virtual DbSet<PointTransction> PointTransctions { get; set; }
		public virtual DbSet<QA> QAs { get; set; }
		public virtual DbSet<RolePermission> RolePermissions { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttractionImage>()
				.Property(e => e.FileName)
				.IsUnicode(false);

			modelBuilder.Entity<AttractionOrder>()
				.Property(e => e.Price)
				.HasPrecision(10, 2);

			modelBuilder.Entity<AttractionOrder>()
				.HasMany(e => e.AttrationOrderItems)
				.WithRequired(e => e.AttractionOrder)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AttractionOrderStatus>()
				.HasMany(e => e.AttractionOrders)
				.WithRequired(e => e.AttractionOrderStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Attraction>()
				.HasMany(e => e.AttractionContents)
				.WithRequired(e => e.Attraction)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Attraction>()
				.HasMany(e => e.AttractionImages)
				.WithRequired(e => e.Attraction)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Attraction>()
				.HasMany(e => e.AttractionTickets)
				.WithRequired(e => e.Attraction)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Attraction>()
				.HasMany(e => e.PackageAttractionItems)
				.WithRequired(e => e.Attraction)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AttractionTicket>()
				.Property(e => e.Price)
				.HasPrecision(10, 2);

			modelBuilder.Entity<AttractionTicket>()
				.HasMany(e => e.AttractionTicketStocks)
				.WithRequired(e => e.AttractionTicket)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AttractionTicket>()
				.HasMany(e => e.AttrationOrderItems)
				.WithRequired(e => e.AttractionTicket)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AttractionTicketType>()
				.HasMany(e => e.AttractionTickets)
				.WithRequired(e => e.AttractionTicketType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AttrationOrderItem>()
				.Property(e => e.UnitPrice)
				.HasPrecision(10, 2);

			modelBuilder.Entity<BEAdmin>()
				.Property(e => e.Account)
				.IsUnicode(false);

			modelBuilder.Entity<BEAdmin>()
				.Property(e => e.EncryptedPassword)
				.IsUnicode(false);

			modelBuilder.Entity<BEAdmin>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<BEAdmin>()
				.HasMany(e => e.AdminRoles)
				.WithRequired(e => e.BEAdmin)
				.HasForeignKey(e => e.AdminId);

			modelBuilder.Entity<BEAdmin>()
				.HasMany(e => e.CarOrders)
				.WithOptional(e => e.BEAdmin)
				.HasForeignKey(e => e.AdminId);

			modelBuilder.Entity<BEAdmin>()
				.HasMany(e => e.HotelOrders)
				.WithRequired(e => e.BEAdmin)
				.HasForeignKey(e => e.AdminId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CarBrand>()
				.HasMany(e => e.CarModels)
				.WithRequired(e => e.CarBrand)
				.HasForeignKey(e => e.BrandId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CarEnergyType>()
				.HasMany(e => e.CarModels)
				.WithRequired(e => e.CarEnergyType)
				.HasForeignKey(e => e.EnergyTypeId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CarModel>()
				.HasMany(e => e.Cars)
				.WithRequired(e => e.CarModel)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CarOrderStatus>()
				.HasMany(e => e.CarOrders)
				.WithRequired(e => e.CarOrderStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Car>()
				.HasMany(e => e.CarOrders)
				.WithRequired(e => e.Car)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CarStatus>()
				.HasMany(e => e.Cars)
				.WithRequired(e => e.CarStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CarTransmission>()
				.HasMany(e => e.CarModels)
				.WithRequired(e => e.CarTransmission)
				.HasForeignKey(e => e.TransmissionId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<City>()
				.HasMany(e => e.Attractions)
				.WithRequired(e => e.City)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<City>()
				.HasMany(e => e.Districts)
				.WithRequired(e => e.City)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Comment>()
				.HasMany(e => e.CommentImages)
				.WithRequired(e => e.Comment)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<District>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<District>()
				.HasMany(e => e.Cars)
				.WithRequired(e => e.District)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<District>()
				.HasMany(e => e.Hotels)
				.WithRequired(e => e.District)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<HotelOrder>()
				.Property(e => e.OrderSn)
				.IsUnicode(false);

			modelBuilder.Entity<HotelOrder>()
				.Property(e => e.Phone)
				.IsUnicode(false);

			modelBuilder.Entity<HotelOrder>()
				.HasMany(e => e.HotelOrderItems)
				.WithRequired(e => e.HotelOrder)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<HotelOrderStatus>()
				.HasMany(e => e.HotelOrders)
				.WithRequired(e => e.HotelOrderStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<HotelRoom>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<HotelRoom>()
				.Property(e => e.MainImage)
				.IsUnicode(false);

			modelBuilder.Entity<HotelRoom>()
				.HasMany(e => e.HotelOrderItems)
				.WithRequired(e => e.HotelRoom)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<HotelRoom>()
				.HasMany(e => e.HotelRoomImages)
				.WithRequired(e => e.HotelRoom)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<HotelRoom>()
				.HasMany(e => e.PackageHotelRoomItems)
				.WithRequired(e => e.HotelRoom)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Hotel>()
				.Property(e => e.Name)
				.IsFixedLength();

			modelBuilder.Entity<Hotel>()
				.Property(e => e.Grade)
				.HasPrecision(3, 1);

			modelBuilder.Entity<Hotel>()
				.Property(e => e.Phone)
				.IsFixedLength();

			modelBuilder.Entity<Hotel>()
				.Property(e => e.MainImage)
				.IsUnicode(false);

			modelBuilder.Entity<Hotel>()
				.HasMany(e => e.HotelImages)
				.WithRequired(e => e.Hotel)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<HotelType>()
				.HasMany(e => e.Hotels)
				.WithRequired(e => e.HotelType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<MemberActivityRecord>()
				.Property(e => e.IpAddress)
				.IsUnicode(false);

			modelBuilder.Entity<MemberLevel>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<MemberPersonalInfo>()
				.Property(e => e.IDNumber)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<MemberPersonalInfo>()
				.Property(e => e.PhoneNumber)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<MemberPersonalInfo>()
				.Property(e => e.EmCPhone)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<MemberProfile>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Account)
				.IsFixedLength();

			modelBuilder.Entity<Member>()
				.Property(e => e.EncryptedPassword)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Salt)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.AttractionOrders)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.CarOrders)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Comments)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.HotelOrders)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.MemberActivityRecords)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.PackageOrdes)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.PointTransctions)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PackageOrderStatus>()
				.HasMany(e => e.PackageOrdes)
				.WithRequired(e => e.PackageOrderStatus)
				.HasForeignKey(e => e.PackageOrdeStatusId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Package>()
				.Property(e => e.Image)
				.IsUnicode(false);

			modelBuilder.Entity<Package>()
				.HasMany(e => e.PackageAttractionItems)
				.WithRequired(e => e.Package)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Package>()
				.HasMany(e => e.PackageHotelRoomItems)
				.WithRequired(e => e.Package)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Package>()
				.HasMany(e => e.PackageMemos)
				.WithRequired(e => e.Package)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Package>()
				.HasMany(e => e.PackageOrdes)
				.WithRequired(e => e.Package)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Permission>()
				.HasMany(e => e.RolePermissions)
				.WithRequired(e => e.Permission)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PointTransction>()
				.Property(e => e.TransactionType)
				.IsUnicode(false);

			modelBuilder.Entity<PointTransction>()
				.Property(e => e.TransactionCategory)
				.IsUnicode(false);

			modelBuilder.Entity<PointTransction>()
				.Property(e => e.Amount)
				.IsUnicode(false);

			modelBuilder.Entity<Role>()
				.HasMany(e => e.AdminRoles)
				.WithRequired(e => e.Role)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Role>()
				.HasMany(e => e.RolePermissions)
				.WithRequired(e => e.Role)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ServiceCategory>()
				.HasMany(e => e.Comments)
				.WithRequired(e => e.ServiceCategory)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ServiceCategory>()
				.HasMany(e => e.QAs)
				.WithRequired(e => e.ServiceCategory)
				.WillCascadeOnDelete(false);
		}
	}
}

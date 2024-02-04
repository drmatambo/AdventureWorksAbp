//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics.CodeAnalysis;
//using Volo.Abp;
//using Volo.Abp.EntityFrameworkCore.Modeling;
//using VumbaSoft.AdventureWorksAbp.Production.BillsOfMaterials;
//using VumbaSoft.AdventureWorksAbp.Production.Cultures;
//using VumbaSoft.AdventureWorksAbp.Production.Illustrations;
//using VumbaSoft.AdventureWorksAbp.Production.Locations;
//using VumbaSoft.AdventureWorksAbp.Production.ProductCategories;
//using VumbaSoft.AdventureWorksAbp.Production.ProductCostHistories;
//using VumbaSoft.AdventureWorksAbp.Production.ProductDescriptions;
//using VumbaSoft.AdventureWorksAbp.Production.ProductInventories;
//using VumbaSoft.AdventureWorksAbp.Production.ProductListPriceHistories;
//using VumbaSoft.AdventureWorksAbp.Production.ProductModelIllustrations;
//using VumbaSoft.AdventureWorksAbp.Production.ProductModelProductDescriptionCultures;
//using VumbaSoft.AdventureWorksAbp.Production.ProductModels;
//using VumbaSoft.AdventureWorksAbp.Production.ProductPhotos;
//using VumbaSoft.AdventureWorksAbp.Production.ProductProductPhotos;
//using VumbaSoft.AdventureWorksAbp.Production.ProductReviews;
//using VumbaSoft.AdventureWorksAbp.Production.Products;
//using VumbaSoft.AdventureWorksAbp.Production.ProductSubcategories;
//using VumbaSoft.AdventureWorksAbp.Production.ScrapReasons;
//using VumbaSoft.AdventureWorksAbp.Production.TransactionHistories;
//using VumbaSoft.AdventureWorksAbp.Production.TransactionHistoryArchives;
//using VumbaSoft.AdventureWorksAbp.Production.UnitMeasures;
//using VumbaSoft.AdventureWorksAbp.Production.WorkOrderRoutings;
//using VumbaSoft.AdventureWorksAbp.Production.WorkOrders;

//namespace VumbaSoft.AdventureWorksAbp.EntityConfigModelBuilderExtentios
//{
//    public static class ProductionDbContextModelBuilderExtensions
//    {
//        public static void ConfigureProduction([NotNull] this ModelBuilder builder)
//        {
//            Check.NotNull(builder, nameof(builder));

//            builder.Entity<BillOfMaterials>(b =>
//            {
//                //b.HasKey(e => e.BillOfMaterialsId)
//                //    .HasName("PK_BillOfMaterials_BillOfMaterialsID")
//                //    .IsClustered(false);

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "BillsOfMaterials", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema, 
//                    table => table.HasComment("Lookup table containing the departments within the Adventure Works Cycles company.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props


//                b.HasIndex(e => 
//                    new { e.ProductAssemblyId, 
//                          e.ComponentId, 
//                          e.StartDate 
//                        }, "AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate")
//                .IsUnique()
//                .IsClustered();

//                b.HasIndex(e => e.UnitMeasureCode, "IX_BillOfMaterials_UnitMeasureCode");

//                //b.Property(e => e.BillOfMaterialsId)
//                //    .HasComment("Primary key for BillOfMaterials records.")
//                //    .HasColumnName("BillOfMaterialsID");

//                b.Property(e => e.Bomlevel)
//                    .HasComment("Indicates the depth the component is from its parent (AssemblyID).")
//                    .HasColumnName("BOMLevel");

//                b.Property(e => e.ComponentId)
//                    .HasComment("Component identification number. Foreign key to Product.ProductID.")
//                    .HasColumnName("ComponentID");

//                b.Property(e => e.EndDate)
//                    .HasComment("Date the component stopped being used in the assembly item.")
//                    .HasColumnType("datetime");

//                //b.Property(e => e.ModifiedDate)
//                //    .HasDefaultValueSql("(getdate())")
//                //    .HasComment("Date and time the record was last updated.")
//                //    .HasColumnType("datetime");

//                b.Property(e => e.PerAssemblyQty)
//                    .HasDefaultValueSql("((1.00))")
//                    .HasComment("Quantity of the component needed to create the assembly.")
//                    .HasColumnType("decimal(8, 2)");

//                b.Property(e => e.ProductAssemblyId)
//                    .HasComment("Parent product identification number. Foreign key to Product.ProductID.")
//                    .HasColumnName("ProductAssemblyID");

//                b.Property(e => e.StartDate)
//                    .HasDefaultValueSql("(getdate())")
//                    .HasComment("Date the component started being used in the assembly item.")
//                    .HasColumnType("datetime");

//                b.Property(e => e.UnitMeasureCode)
//                    .IsRequired()
//                    .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                    .IsFixedLength()
//                    .HasComment("Standard code identifying the unit of measure for the quantity.");

//                b.HasOne(d => d.Component).WithMany(p => p.BillOfMaterialsComponent)
//                    .HasForeignKey(d => d.ComponentId)
//                    .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ProductAssembly)
//                    .WithMany(p => p.BillOfMaterialsProductAssembly)
//                    .HasForeignKey(d => d.ProductAssemblyId)
//                    .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.UnitMeasureCodeNavigation).WithMany(p => p.BillOfMaterials)
//                    .HasForeignKey(d => d.UnitMeasureCode)
//                    .OnDelete(DeleteBehavior.ClientSetNull);

//            });

//            builder.Entity<Culture>(b =>
//            {
//                //b.HasKey(e => e.CultureId).HasName("PK_Culture_CultureID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Cultures", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema, 
//                    table => table.HasComment("Lookup table containing the languages in which some AdventureWorks data is stored.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_Culture_Name").IsUnique();

//                //b.Property(e => e.CultureId)
//                //.HasMaxLength(AdventureWorksAbpSharedConsts.CultureIdMaxLength)
//                //.IsFixedLength()
//                //.HasComment("Primary key for Culture records.")
//                //.HasColumnName("CultureID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Culture description.");
//            });

//            builder.Entity<Illustration>(b =>
//            {
//                //b.HasKey(e => e.IllustrationId).HasName("PK_Illustration_IllustrationID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Illustrations", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Bicycle assembly diagrams.")
//                );

//                //b.Property(e => e.IllustrationId)
//                //.HasComment("Primary key for Illustration records.")
//                //.HasColumnName("IllustrationID");

//                b.Property(e => e.Diagram)
//                .HasComment("Illustrations used in manufacturing instructions. Stored as XML.")
//                .HasColumnType("xml");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");
//            });

//            builder.Entity<Location>(b =>
//            {
//                //b.HasKey(e => e.LocationId).HasName("PK_Location_LocationID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Locations", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Product inventory and manufacturing locations.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_Location_Name").IsUnique();

//                //b.Property(e => e.LocationId)
//                //.HasComment("Primary key for Location records.")
//                //.HasColumnName("LocationID");

//                b.Property(e => e.Availability)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Work capacity (in hours) of the manufacturing location.")
//                .HasColumnType("decimal(8, 2)");

//                b.Property(e => e.CostRate)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Standard hourly cost of the manufacturing location.")
//                .HasColumnType("smallmoney");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Location description.");
//            });

//            builder.Entity<ProductCategory>(b =>
//            {
//                //b.HasKey(e => e.ProductCategoryId).HasName("PK_ProductCategory_ProductCategoryID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductCategories", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Lookup table containing the High-level product categorization.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_ProductCategory_Name").IsUnique();

//                //b.HasIndex(e => e.Rowguid, "AK_ProductCategory_rowguid").IsUnique();

//                //b.Property(e => e.ProductCategoryId)
//                //.HasComment("Primary key for ProductCategory records.")
//                //.HasColumnName("ProductCategoryID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(50)
//                .HasComment("Category description.");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");
//            });

//            builder.Entity<ProductCostHistory>(b =>
//            {
//                b.HasKey(e => new { e.ProductId, 
//                                    e.StartDate })
//                .HasName("PK_ProductCostHistory_ProductID_StartDate");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductCostHistories", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Changes in the cost of a product over time.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID")
//                .HasColumnName("ProductID");

//                b.Property(e => e.StartDate)
//                .HasComment("Product cost start date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.EndDate)
//                .HasComment("Product cost end date.")
//                .HasColumnType("datetime");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.StandardCost)
//                .HasComment("Standard cost of the product.")
//                .HasColumnType("money");

//                b.HasOne(d => d.Product).WithMany(p => p.ProductCostHistory)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ProductDescription>(b =>
//            {
//                //b.HasKey(e => e.ProductDescriptionId).HasName("PK_ProductDescription_ProductDescriptionID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductDescriptions", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Product descriptions in several languages.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                //b.HasIndex(e => e.Rowguid, "AK_ProductDescription_rowguid").IsUnique();

//                //b.Property(e => e.ProductDescriptionId)
//                //.HasComment("Primary key for ProductDescription records.")
//                //.HasColumnName("ProductDescriptionID");

//                b.Property(e => e.Description)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.DescriptionMaxLength)
//                .HasComment("Description of the product.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");
//            });

//            builder.Entity<ProductInventory>(b =>
//            {
//                b.HasKey(e => new { e.ProductId, 
//                                    e.LocationId })
//                .HasName("PK_ProductInventory_ProductID_LocationID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductInventories", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Product descriptions in several languages.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.LocationId)
//                .HasComment("Inventory location identification number. Foreign key to Location.LocationID. ")
//                .HasColumnName("LocationID");

//                b.Property(e => e.Bin).HasComment("Storage container on a shelf in an inventory location.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Quantity).HasComment("Quantity of products in the inventory location.");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.Property(e => e.Shelf)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.ShelfStorageLocationMaxLength)
//                .HasComment("Storage compartment within an inventory location.");

//                b.HasOne(d => d.Location).WithMany(p => p.ProductInventory)
//                .HasForeignKey(d => d.LocationId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.Product).WithMany(p => p.ProductInventory)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ProductListPriceHistory>(b =>
//            {
//                b.HasKey(e => new { e.ProductId, 
//                                    e.StartDate })
//                .HasName("PK_ProductListPriceHistory_ProductID_StartDate");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductListPriceHistories", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Changes in the list price of a product over time.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID")
//                .HasColumnName("ProductID");

//                b.Property(e => e.StartDate)
//                .HasComment("List price start date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.EndDate)
//                .HasComment("List price end date")
//                .HasColumnType("datetime");

//                b.Property(e => e.ListPrice)
//                .HasComment("Product list price.")
//                .HasColumnType("money");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.HasOne(d => d.Product).WithMany(p => p.ProductListPriceHistory)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ProductModelIllustration>(b =>
//            {
//                b.HasKey(e => new { e.ProductModelId, 
//                                    e.IllustrationId })
//                .HasName("PK_ProductModelIllustration_ProductModelID_IllustrationID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductModelIllustrations", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Changes in the list price of a product over time.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.Property(e => e.ProductModelId)
//                .HasComment("Primary key. Foreign key to ProductModel.ProductModelID.")
//                .HasColumnName("ProductModelID");

//                b.Property(e => e.IllustrationId)
//                .HasComment("Primary key. Foreign key to Illustration.IllustrationID.")
//                .HasColumnName("IllustrationID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.HasOne(d => d.Illustration).WithMany(p => p.ProductModelIllustration)
//                .HasForeignKey(d => d.IllustrationId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ProductModel).WithMany(p => p.ProductModelIllustration)
//                .HasForeignKey(d => d.ProductModelId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ProductModelProductDescriptionCulture>(b =>
//            {
//                b.HasKey(e => new { e.ProductModelId, 
//                                    e.ProductDescriptionId, 
//                                    e.CultureId })
//                .HasName("PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductModelProductDescriptionCultures", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Cross-reference table mapping product descriptions and the language the description is written in.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.Property(e => e.ProductModelId)
//                .HasComment("Primary key. Foreign key to ProductModel.ProductModelID.")
//                .HasColumnName("ProductModelID");

//                b.Property(e => e.ProductDescriptionId)
//                .HasComment("Primary key. Foreign key to ProductDescription.ProductDescriptionID.")
//                .HasColumnName("ProductDescriptionID");

//                b.Property(e => e.CultureId)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.CultureIdMaxLength)
//                .IsFixedLength()
//                .HasComment("Culture identification number. Foreign key to Culture.CultureID.")
//                .HasColumnName("CultureID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.HasOne(d => d.Culture).WithMany(p => p.ProductModelProductDescriptionCulture)
//                .HasForeignKey(d => d.CultureId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ProductDescription).WithMany(p => p.ProductModelProductDescriptionCulture)
//                .HasForeignKey(d => d.ProductDescriptionId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ProductModel).WithMany(p => p.ProductModelProductDescriptionCulture)
//                .HasForeignKey(d => d.ProductModelId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ProductModel>(b =>
//            {
//                //b.HasKey(e => e.ProductModelId).HasName("PK_ProductModel_ProductModelID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductModels", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Product model classification.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_ProductModel_Name").IsUnique();

//                b.HasIndex(e => e.CatalogDescription, "PXML_ProductModel_CatalogDescription");

//                b.HasIndex(e => e.Instructions, "PXML_ProductModel_Instructions");

//                //b.Property(e => e.ProductModelId)
//                //.HasComment("Primary key for ProductModel records.")
//                //.HasColumnName("ProductModelID");

//                b.Property(e => e.CatalogDescription)
//                .HasComment("Detailed product catalog information in xml format.")
//                .HasColumnType("xml");

//                b.Property(e => e.Instructions)
//                .HasComment("Manufacturing instructions in xml format.")
//                .HasColumnType("xml");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(50)
//                .HasComment("Product model description.");

//            });

//            builder.Entity<ProductPhoto>(b =>
//            {
//                //b.HasKey(e => e.ProductPhotoId).HasName("PK_ProductPhoto_ProductPhotoID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductPhotos", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Product model classification.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                //b.Property(e => e.ProductPhotoId)
//                //.HasComment("Primary key for ProductPhoto records.")
//                //.HasColumnName("ProductPhotoID");

//                b.Property(e => e.LargePhoto).HasComment("Large image of the product.");
//                b.Property(e => e.LargePhotoFileName)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.LargePhotoMaxLength)
//                .HasComment("Large image file name.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.ThumbNailPhoto).HasComment("Small image of the product.");
//                b.Property(e => e.ThumbnailPhotoFileName)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.ThumbNailPhotoMaxLength)
//                .HasComment("Small image file name.");
//            });

//            builder.Entity<ProductProductPhoto>(b =>
//            {
//                b.HasKey(e => new { e.ProductId, 
//                                    e.ProductPhotoId })
//                .HasName("PK_ProductProductPhoto_ProductID_ProductPhotoID")
//                .IsClustered(false);

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductProductPhotos", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Cross-reference table mapping products and product photos.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.ProductPhotoId)
//                .HasComment("Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.")
//                .HasColumnName("ProductPhotoID");

//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");

//                b.Property(e => e.Primary).HasComment("0 = Photo is not the principal image. 1 = Photo is the principal image.");

//                b.HasOne(d => d.Product).WithMany(p => p.ProductProductPhoto)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ProductPhoto).WithMany(p => p.ProductProductPhoto)
//                .HasForeignKey(d => d.ProductPhotoId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ProductReview>(b =>
//            {
//                //b.HasKey(e => e.ProductReviewId).HasName("PK_ProductReview_ProductReviewID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductReviews", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Customer reviews of products they have purchased.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => new { e.ProductId, e.ReviewerName }, "IX_ProductReview_ProductID_Name");

//                //b.Property(e => e.ProductReviewId)
//                //.HasComment("Primary key for ProductReview records.")
//                //.HasColumnName("ProductReviewID");

//                b.Property(e => e.Comments)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.ReviewersCommentsMaxLength)
//                .HasComment("Reviewer's comments");

//                b.Property(e => e.EmailAddress)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.EmailAddressMaxLength)
//                .HasComment("Reviewer's e-mail address.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.Rating).HasComment("Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.");
//                b.Property(e => e.ReviewDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date review was submitted.")
//                .HasColumnType("datetime");

//                b.Property(e => e.ReviewerName)
//                .IsRequired()
//                .HasMaxLength(50)
//                .HasComment("Name of the reviewer.");

//                b.HasOne(d => d.Product).WithMany(p => p.ProductReview)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<Product>(b =>
//            {
//                //b.HasKey(e => e.ProductId).HasName("PK_Product_ProductID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Products", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Products sold or used in the manfacturing of sold products.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_Product_Name").IsUnique();

//                b.HasIndex(e => e.ProductNumber, "AK_Product_ProductNumber").IsUnique();

//                b.HasIndex(e => e.Rowguid, "AK_Product_rowguid").IsUnique();

//                b.Property(e => e.ProductId)
//                .HasComment("Primary key for Product records.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.Class)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedOneLetterLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("H = High, M = Medium, L = Low");

//                b.Property(e => e.Color)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.ColorMaxLength)
//                .HasComment("Product color.");

//                b.Property(e => e.DaysToManufacture).HasComment("Number of days required to manufacture the product.");

//                b.Property(e => e.DiscontinuedDate)
//                .HasComment("Date the product was discontinued.")
//                .HasColumnType("datetime");

//                b.Property(e => e.FinishedGoodsFlag)
//                .IsRequired()
//                .HasDefaultValueSql("((1))")
//                .HasComment("0 = Product is not a salable item. 1 = Product is salable.");

//                b.Property(e => e.ListPrice)
//                .HasComment("Selling price.")
//                .HasColumnType("money");

//                b.Property(e => e.MakeFlag)
//                .IsRequired()
//                .HasDefaultValueSql("((1))")
//                .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Name of the product.");

//                b.Property(e => e.ProductLine)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedOneLetterLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");

//                b.Property(e => e.ProductModelId)
//                .HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.")
//                .HasColumnName("ProductModelID");

//                b.Property(e => e.ProductNumber)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.ProductNumberMaxLength)
//                .HasComment("Unique product identification number.");

//                b.Property(e => e.ProductSubcategoryId)
//                .HasComment("Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. ")
//                .HasColumnName("ProductSubcategoryID");

//                b.Property(e => e.ReorderPoint).HasComment("Inventory level that triggers a purchase order or work order. ");

//                b.Property(e => e.Rowguid)
//                .HasDefaultValueSql("(newid())")
//                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                .HasColumnName("rowguid");

//                b.Property(e => e.SafetyStockLevel).HasComment("Minimum inventory quantity. ");

//                b.Property(e => e.SellEndDate)
//                .HasComment("Date the product was no longer available for sale.")
//                .HasColumnType("datetime");

//                b.Property(e => e.SellStartDate)
//                .HasComment("Date the product was available for sale.")
//                .HasColumnType("datetime");

//                b.Property(e => e.Size)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.ProductSizeMaxLength)
//                .HasComment("Product size.");

//                b.Property(e => e.SizeUnitMeasureCode)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("Unit of measure for Size column.");

//                b.Property(e => e.StandardCost)
//                .HasComment("Standard cost of the product.")
//                .HasColumnType("money");

//                b.Property(e => e.Style)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedOneLetterLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("Product style: W = Womens, M = Mens, U = Universal");

//                b.Property(e => e.Weight)
//                .HasComment("Product weight.")
//                .HasColumnType("decimal(8, 2)");

//                b.Property(e => e.WeightUnitMeasureCode)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("Unit of measure for Weight column.");


//                b.HasOne(d => d.ProductModel).WithMany(p => p.Product)
//                .HasForeignKey(d => d.ProductModelId);

//                b.HasOne(d => d.ProductSubcategory)
//                .WithMany(p => p.Product)
//                .HasForeignKey(d => d.ProductSubcategoryId);

//                b.HasOne(d => d.SizeUnitMeasureCodeNavigation)
//                .WithMany(p => p.ProductSizeUnitMeasureCodeNavigation)
//                .HasForeignKey(d => d.SizeUnitMeasureCode);

//                b.HasOne(d => d.WeightUnitMeasureCodeNavigation)
//                .WithMany(p => p.ProductWeightUnitMeasureCodeNavigation)
//                .HasForeignKey(d => d.WeightUnitMeasureCode);

//            });

//            builder.Entity<ProductSubcategory>(b =>
//            {
//                //b.HasKey(e => e.ProductSubcategoryId).HasName("PK_ProductSubcategory_ProductSubcategoryID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductSubcategories", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Product subcategories. See ProductCategory table.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_ProductSubcategory_Name").IsUnique();

//                b.HasIndex(e => e.Rowguid, "AK_ProductSubcategory_rowguid").IsUnique();

//                //b.Property(e => e.ProductSubcategoryId)
//                //.HasComment("Primary key for ProductSubcategory records.")
//                //.HasColumnName("ProductSubcategoryID");

//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Subcategory description.");

//                b.Property(e => e.ProductCategoryId)
//                .HasComment("Product category identification number. Foreign key to ProductCategory.ProductCategoryID.")
//                .HasColumnName("ProductCategoryID");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.HasOne(d => d.ProductCategory).WithMany(p => p.ProductSubcategory)
//                .HasForeignKey(d => d.ProductCategoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ScrapReason>(b =>
//            {
//                //b.HasKey(e => e.ScrapReasonId).HasName("PK_ScrapReason_ScrapReasonID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ScrapReasons", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Manufacturing failure reasons lookup table.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_ScrapReason_Name").IsUnique();

//                //b.Property(e => e.ScrapReasonId)
//                //.HasComment("Primary key for ScrapReason records.")
//                //.HasColumnName("ScrapReasonID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Failure description.");
//            });

//            builder.Entity<TransactionHistory>(b =>
//            {
//                //b.HasKey(e => e.TransactionId).HasName("PK_TransactionHistory_TransactionID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "TransactionHistories", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema, 
//                    table => table.HasComment("Record of each purchase order, sales order, or work order transaction year to date.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.ProductId, "IX_TransactionHistory_ProductID");

//                b.HasIndex(e => new { e.ReferenceOrderId, e.ReferenceOrderLineId }, "IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID");

//                //b.Property(e => e.TransactionId)
//                //.HasComment("Primary key for TransactionHistory records.")
//                //.HasColumnName("TransactionID");

//                b.Property(e => e.ActualCost)
//                .HasComment("Product cost.")
//                .HasColumnType("money");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.Quantity).HasComment("Product quantity.");
//                b.Property(e => e.ReferenceOrderId)
//                .HasComment("Purchase order, sales order, or work order identification number.")
//                .HasColumnName("ReferenceOrderID");

//                b.Property(e => e.ReferenceOrderLineId)
//                .HasComment("Line number associated with the purchase order, sales order, or work order.")
//                .HasColumnName("ReferenceOrderLineID");

//                b.Property(e => e.TransactionDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time of the transaction.")
//                .HasColumnType("datetime");

//                b.Property(e => e.TransactionType)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedOneLetterLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("W = WorkOrder, S = SalesOrder, P = PurchaseOrder");

//                b.HasOne(d => d.Product).WithMany(p => p.TransactionHistory)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//                //TODO: Continuar
//            });

//            builder.Entity<TransactionHistoryArchive>(b =>
//            {
//                //b.HasKey(e => e.TransactionId).Hasame("PK_TransactionHistoryArchive_TransactionID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "TransactionHistoryArchives", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Transactions for previous years.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.ProductId, "IX_TransactionHistoryArchive_ProductID");

//                b.HasIndex(e => new { e.ReferenceOrderId, e.ReferenceOrderLineId }, "IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID");

//                b.Property(e => e.TransactionId)
//                .ValueGeneratedNever()
//                .HasComment("Primary key for TransactionHistoryArchive records.")
//                .HasColumnName("TransactionID");

//                b.Property(e => e.ActualCost)
//                .HasComment("Product cost.")
//                .HasColumnType("money");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");
//                b.Property(e => e.Quantity).HasComment("Product quantity.");

//                b.Property(e => e.ReferenceOrderId)
//                .HasComment("Purchase order, sales order, or work order identification number.")
//                .HasColumnName("ReferenceOrderID");

//                b.Property(e => e.ReferenceOrderLineId)
//                .HasComment("Line number associated with the purchase order, sales order, or work order.")
//                .HasColumnName("ReferenceOrderLineID");

//                b.Property(e => e.TransactionDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time of the transaction.")
//                .HasColumnType("datetime");

//                b.Property(e => e.TransactionType)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedOneLetterLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("W = Work Order, S = Sales Order, P = Purchase Order");
//            });

//            builder.Entity<UnitMeasure>(b =>
//            {
//                b.HasKey(e => e.UnitMeasureCode).HasName("PK_UnitMeasure_UnitMeasureCode");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "UnitMeasures", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Unit of measure lookup table.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_UnitMeasure_Name").IsUnique();

//                b.Property(e => e.UnitMeasureCode)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("Primary key.");

//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Unit of measure description.");
//            });

//            builder.Entity<WorkOrderRouting>(b =>
//            {
//                b.HasKey(e => new { e.WorkOrderId, 
//                                    e.ProductId, 
//                                    e.OperationSequence })
//                .HasName("PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "WorkOrderRoutings", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema,
//                    table => table.HasComment("Work order detail.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.ProductId, "IX_WorkOrderRouting_ProductID");

//                b.Property(e => e.WorkOrderId)
//                .HasComment("Primary key. Foreign key to WorkOrder.WorkOrderID.")
//                .HasColumnName("WorkOrderID");

//                b.Property(e => e.ProductId)
//                .HasComment("Primary key. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.OperationSequence).HasComment("Primary key. Indicates the manufacturing process sequence.");
//                b.Property(e => e.ActualCost)
//                .HasComment("Actual manufacturing cost.")
//                .HasColumnType("money");

//                b.Property(e => e.ActualEndDate)
//                .HasComment("Actual end date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.ActualResourceHrs)
//                .HasComment("Number of manufacturing hours used.")
//                .HasColumnType("decimal(9, 4)");

//                b.Property(e => e.ActualStartDate)
//                .HasComment("Actual start date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.LocationId)
//                .HasComment("Manufacturing location where the part is processed. Foreign key to Location.LocationID.")
//                .HasColumnName("LocationID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.PlannedCost)
//                .HasComment("Estimated manufacturing cost.")
//                .HasColumnType("money");

//                b.Property(e => e.ScheduledEndDate)
//                .HasComment("Planned manufacturing end date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.ScheduledStartDate)
//                .HasComment("Planned manufacturing start date.")
//                .HasColumnType("datetime");


//                b.HasOne(d => d.Location)
//                .WithMany(p => p.WorkOrderRouting)
//                .HasForeignKey(d => d.LocationId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.WorkOrder)
//                .WithMany(p => p.WorkOrderRouting)
//                .HasForeignKey(d => d.WorkOrderId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<WorkOrder>(b =>
//            {
//                //b.HasKey(e => e.WorkOrderId).HasName("PK_WorkOrder_WorkOrderID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "WorkOrders", 
//                    AdventureWorksAbpSharedConsts.ProductionDbSchema, 
//                    table =>
//                        {
//                            table.HasComment("Manufacturing work orders.");
//                            table.HasTrigger("iWorkOrder");
//                            table.HasTrigger("uWorkOrder");
//                        }
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.ProductId, "IX_WorkOrder_ProductID");

//                b.HasIndex(e => e.ScrapReasonId, "IX_WorkOrder_ScrapReasonID");

//                //b.Property(e => e.WorkOrderId)
//                //.HasComment("Primary key for WorkOrder records.")
//                //.HasColumnName("WorkOrderID");

//                b.Property(e => e.DueDate)
//                .HasComment("Work order due date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.EndDate)
//                .HasComment("Work order end date.")
//                .HasColumnType("datetime");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.OrderQty).HasComment("Product quantity to build.");

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.ScrapReasonId)
//                .HasComment("Reason for inspection failure.")
//                .HasColumnName("ScrapReasonID");

//                b.Property(e => e.ScrappedQty).HasComment("Quantity that failed inspection.");

//                b.Property(e => e.StartDate)
//                .HasComment("Work order start date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.StockedQty)
//                .HasComputedColumnSql("(isnull([OrderQty]-[ScrappedQty],(0)))", false)
//                .HasComment("Quantity built and put in inventory.");

//                b.HasOne(d => d.Product)
//                .WithMany(p => p.WorkOrder)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ScrapReason)
//                .WithMany(p => p.WorkOrder)
//                .HasForeignKey(d => d.ScrapReasonId)
//                .OnDelete(DeleteBehavior.ClientSetNull); ;
//            });
//        }
//    }
//}

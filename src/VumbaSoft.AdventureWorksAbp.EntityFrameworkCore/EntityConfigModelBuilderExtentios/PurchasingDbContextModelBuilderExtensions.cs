//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics.CodeAnalysis;
//using Volo.Abp;
//using Volo.Abp.EntityFrameworkCore.Modeling;
//using VumbaSoft.AdventureWorksAbp.Purchansing.ProductVendors;
//using VumbaSoft.AdventureWorksAbp.Purchansing.PurchaseOrderDetails;
//using VumbaSoft.AdventureWorksAbp.Purchansing.PurchaseOrderHeaders;
//using VumbaSoft.AdventureWorksAbp.Purchansing.ShipMethods;
//using VumbaSoft.AdventureWorksAbp.Purchansing.Vendors;

//namespace VumbaSoft.AdventureWorksAbp.EntityConfigModelBuilderExtentios
//{
//    public static class PurchasingDbContextModelBuilderExtensions
//    {
//        public static void ConfigurePurchasing([NotNull] this ModelBuilder builder)
//        {
//            Check.NotNull(builder, nameof(builder));

//            builder.Entity<ProductVendor>(b =>
//            {
//                b.HasKey(e => new { e.ProductId, 
//                                    e.BusinessEntityId })
//                    .HasName("PK_ProductVendor_ProductID_BusinessEntityID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ProductVendors", AdventureWorksAbpSharedConsts.PurchasingDbSchema,
//                    table => table.HasComment("Cross-reference table mapping vendors with the products they supply")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.BusinessEntityId, "IX_ProductVendor_BusinessEntityID");

//                b.HasIndex(e => e.UnitMeasureCode, "IX_ProductVendor_UnitMeasureCode");

//                b.Property(e => e.ProductId)
//                .HasComment("Primary key. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.BusinessEntityId)
//                .HasComment("Primary key. Foreign key to Vendor.BusinessEntityID.")
//                .HasColumnName("BusinessEntityID");

//                b.Property(e => e.AverageLeadTime).HasComment("The average span of time (in days) between placing an order with the vendor and receiving the purchased product.");

//                b.Property(e => e.LastReceiptCost)
//                .HasComment("The selling price when last purchased.")
//                .HasColumnType("money");

//                b.Property(e => e.LastReceiptDate)
//                .HasComment("Date the product was last received by the vendor.")
//                .HasColumnType("datetime");

//                b.Property(e => e.MaxOrderQty).HasComment("The maximum quantity that should be ordered.");

//                b.Property(e => e.MinOrderQty).HasComment("The minimum quantity that should be ordered.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.OnOrderQty).HasComment("The quantity currently on order.");

//                b.Property(e => e.StandardPrice)
//                .HasComment("The vendor's usual selling price.")
//                .HasColumnType("money");

//                b.Property(e => e.UnitMeasureCode)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("The product's unit of measure.");

//                b.HasOne(d => d.BusinessEntity).WithMany(p => p.ProductVendor)
//                .HasForeignKey(d => d.BusinessEntityId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.Product).WithMany(p => p.ProductVendor)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.UnitMeasureCodeNavigation).WithMany(p => p.ProductVendor)
//                .HasForeignKey(d => d.UnitMeasureCode)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<PurchaseOrderDetail>(b =>
//            {
//                b.HasKey(e => new { e.PurchaseOrderId, 
//                                    e.PurchaseOrderDetailId })
//                .HasName("PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "PurchaseOrderDetails", 
//                    AdventureWorksAbpSharedConsts.PurchasingDbSchema, table =>
//                    {
//                        table.HasComment("Individual products associated with a specific purchase order. See PurchaseOrderHeader.");
//                        table.HasTrigger("iPurchaseOrderDetail");
//                        table.HasTrigger("uPurchaseOrderDetail");
//                    }
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.ProductId, "IX_PurchaseOrderDetail_ProductID");

//                b.Property(e => e.PurchaseOrderId)
//                .HasComment("Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.")
//                .HasColumnName("PurchaseOrderID");

//                b.Property(e => e.PurchaseOrderDetailId)
//                .ValueGeneratedOnAdd()
//                .HasComment("Primary key. One line number per purchased product.")
//                .HasColumnName("PurchaseOrderDetailID");

//                b.Property(e => e.DueDate)
//                .HasComment("Date the product is expected to be received.")
//                .HasColumnType("datetime");

//                b.Property(e => e.LineTotal)
//                .HasComputedColumnSql("(isnull([OrderQty]*[UnitPrice],(0.00)))", false)
//                .HasComment("Per product subtotal. Computed as OrderQty * UnitPrice.")
//                .HasColumnType("money");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.OrderQty).HasComment("Quantity ordered.");

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.ReceivedQty)
//                .HasComment("Quantity actually received from the vendor.")
//                .HasColumnType("decimal(8, 2)");

//                b.Property(e => e.RejectedQty)
//                .HasComment("Quantity rejected during inspection.")
//                .HasColumnType("decimal(8, 2)");

//                b.Property(e => e.StockedQty)
//                .HasComputedColumnSql("(isnull([ReceivedQty]-[RejectedQty],(0.00)))", false)
//                .HasComment("Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.")
//                .HasColumnType("decimal(9, 2)");

//                b.Property(e => e.UnitPrice)
//                .HasComment("Vendor's selling price of a single product.")
//                .HasColumnType("money");

//                b.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderDetail)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderDetail)
//                .HasForeignKey(d => d.PurchaseOrderId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<PurchaseOrderHeader>(b =>
//            {
//                //b.HasKey(e => e.PurchaseOrderId).HasName("PK_PurchaseOrderHeader_PurchaseOrderID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "PurchaseOrderHeaders", 
//                    AdventureWorksAbpSharedConsts.PurchasingDbSchema, table =>
//                    {
//                        table.HasComment("General purchase order information. See PurchaseOrderDetail.");
//                        table.HasTrigger("uPurchaseOrderHeader");
//                    }
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.EmployeeId, "IX_PurchaseOrderHeader_EmployeeID");

//                b.HasIndex(e => e.VendorId, "IX_PurchaseOrderHeader_VendorID");

//                //b.Property(e => e.PurchaseOrderId)
//                //.HasComment("Primary key.")
//                //.HasColumnName("PurchaseOrderID");

//                b.Property(e => e.EmployeeId)
//                .HasComment("Employee who created the purchase order. Foreign key to Employee.BusinessEntityID.")
//                .HasColumnName("EmployeeID");

//                b.Property(e => e.Freight)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Shipping cost.")
//                .HasColumnType("money");

//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");

//                b.Property(e => e.OrderDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Purchase order creation date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.RevisionNumber).HasComment("Incremental number to track changes to the purchase order over time.");

//                b.Property(e => e.ShipDate)
//                .HasComment("Estimated shipment date from the vendor.")
//                .HasColumnType("datetime");

//                b.Property(e => e.ShipMethodId)
//                .HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.")
//                .HasColumnName("ShipMethodId");

//                b.Property(e => e.Status)
//                .HasDefaultValueSql("((1))")
//                .HasComment("Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete");

//                b.Property(e => e.SubTotal)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal) for the appropriate PurchaseOrderID.")
//                .HasColumnType("money");
                
//                b.Property(e => e.TaxAmt)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Tax amount.")
//                .HasColumnType("money");
               
//                b.Property(e => e.TotalDue)
//                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", true)
//                .HasComment("Total due to vendor. Computed as Subtotal + TaxAmt + Freight.")
//                .HasColumnType("money");
                
//                b.Property(e => e.VendorId)
//                .HasComment("Vendor with whom the purchase order is placed. Foreign key to Vendor.BusinessEntityID.")
//                .HasColumnName("VendorID");

//                b.HasOne(d => d.Employee).WithMany()
//                .HasForeignKey(d => d.EmployeeId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ShipMethod).WithMany(p => p.PurchaseOrderHeader)
//                .HasForeignKey(d => d.ShipMethodId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.Vendor).WithMany(p => p.PurchaseOrderHeader)
//                .HasForeignKey(d => d.VendorId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ShipMethod>(b =>
//            {
//                //b.HasKey(e => e.ShipMethodId).HasName("PK_ShipMethod_ShipMethodID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ShipMethods", 
//                    AdventureWorksAbpSharedConsts.PurchasingDbSchema, 
//                    table => table.HasComment("Shipping company lookup table.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_ShipMethod_Name").IsUnique();

//                //b.HasIndex(e => e.Rowguid, "AK_ShipMethod_rowguid").IsUnique();

//                //b.Property(e => e.ShipMethodId)
//                //.HasComment("Primary key for ShipMethod records.")
//                //.HasColumnName("ShipMethodID");
                
//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");
                
//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Shipping company name.");
                
//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");
                
//                b.Property(e => e.ShipBase)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Minimum shipping charge.")
//                .HasColumnType("money");
                
//                b.Property(e => e.ShipRate)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Shipping charge per pound.")
//                .HasColumnType("money");
//            });

//            builder.Entity<Vendor>(b =>
//            {
//                //b.HasKey(e => e.BusinessEntityId).HasName("PK_Vendor_BusinessEntityID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Vendors", 
//                    AdventureWorksAbpSharedConsts.PurchasingDbSchema, table =>
//                    {
//                        table.HasComment("Companies from whom Adventure Works Cycles purchases parts or other goods.");
//                        table.HasTrigger("dVendor");
//                    }
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.AccountNumber, "AK_Vendor_AccountNumber").IsUnique();

//                b.Property(e => e.BusinessEntityId)
//                .ValueGeneratedNever()
//                .HasComment("Primary key for Vendor records.  Foreign key to BusinessEntity.BusinessEntityID")
//                .HasColumnName("BusinessEntityID");
                
//                b.Property(e => e.AccountNumber)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.AccountNumberMaxLength)
//                .HasComment("Vendor account (identification) number.");
                
//                b.Property(e => e.ActiveFlag)
//                .IsRequired()
//                .HasDefaultValueSql("((1))")
//                .HasComment("0 = Vendor no longer used. 1 = Vendor is actively used.");
                
//                b.Property(e => e.CreditRating).HasComment("1 = Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average");
                
//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");
                
//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Company name.");
                
//                b.Property(e => e.PreferredVendorStatus)
//                .IsRequired()
//                .HasDefaultValueSql("((1))")
//                .HasComment("0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.");
                
//                b.Property(e => e.PurchasingWebServiceUrl)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.WebUrlAddressMaxLength)
//                .HasComment("Vendor URL.")
//                .HasColumnName("PurchasingWebServiceURL");

//                b.HasOne(d => d.BusinessEntity).WithOne(p => p.Vendor)
//                .HasForeignKey<Vendor>(d => d.BusinessEntityId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });
//        }
//    }
//}

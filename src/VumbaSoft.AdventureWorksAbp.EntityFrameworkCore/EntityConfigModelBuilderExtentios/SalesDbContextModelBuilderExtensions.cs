//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics.CodeAnalysis;
//using Volo.Abp;
//using Volo.Abp.EntityFrameworkCore.Modeling;
//using VumbaSoft.AdventureWorksAbp.Sales.CountryRegionCurrencies;
//using VumbaSoft.AdventureWorksAbp.Sales.CreditCards;
//using VumbaSoft.AdventureWorksAbp.Sales.Currencies;
//using VumbaSoft.AdventureWorksAbp.Sales.CurrencyRates;
//using VumbaSoft.AdventureWorksAbp.Sales.Customers;
//using VumbaSoft.AdventureWorksAbp.Sales.PersonCreditCards;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesOrderDetails;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesOrderHeaders;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesOrderHeaderSalesReasons;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesPersonQuotaHistories;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesPersons;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesReasons;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesTaxRates;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesTerritories;
//using VumbaSoft.AdventureWorksAbp.Sales.SalesTerritoryHistories;
//using VumbaSoft.AdventureWorksAbp.Sales.ShoppingCartItems;
//using VumbaSoft.AdventureWorksAbp.Sales.SpecialOfferProducts;
//using VumbaSoft.AdventureWorksAbp.Sales.SpecialOffers;
//using VumbaSoft.AdventureWorksAbp.Sales.Stores;

//namespace VumbaSoft.AdventureWorksAbp.EntityConfigModelBuilderExtentios
//{
//    public static class SalesDbContextModelBuilderExtensions
//    {
//        public static void ConfigureSales([NotNull] this ModelBuilder builder)
//        {
//            Check.NotNull(builder, nameof(builder));

//            builder.Entity<CountryRegionCurrency>(b =>
//            {
//                b.HasKey(e => new { e.CountryRegionCode, 
//                                    e.CurrencyCode })
//                    .HasName("PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "CountryRegionCurrencies", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Cross-reference table mapping ISO currency codes to a country or region.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.CurrencyCode, "IX_CountryRegionCurrency_CurrencyCode");

//                b.Property(e => e.CountryRegionCode)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .HasComment("ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.");

//                b.Property(e => e.CurrencyCode)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("ISO standard currency code. Foreign key to Currency.CurrencyCode.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.HasOne(d => d.CountryRegionCodeNavigation).WithMany(p => p.CountryRegionCurrency)
//                .HasForeignKey(d => d.CountryRegionCode)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.CurrencyCodeNavigation).WithMany(p => p.CountryRegionCurrency)
//                .HasForeignKey(d => d.CurrencyCode)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<CreditCard>(b =>
//            {
//                //b.HasKey(e => e.CreditCardId).HasName("PK_CreditCard_CreditCardID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "CreditCards", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Customer credit card information."));

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.CardNumber, "AK_CreditCard_CardNumber").IsUnique();

//                //b.Property(e => e.CreditCardId)
//                //.HasComment("Primary key for CreditCard records.")
//                //.HasColumnName("CreditCardID");

//                b.Property(e => e.CardNumber)
//                .IsRequired()
//                .HasMaxLength(25)
//                .HasComment("Credit card number.");

//                b.Property(e => e.CardType)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Credit card name.");

//                b.Property(e => e.ExpMonth).HasComment("Credit card expiration month.");

//                b.Property(e => e.ExpYear).HasComment("Credit card expiration year.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");
//            });

//            builder.Entity<Currency>(b =>
//            {
//                //b.HasKey(e => e.CurrencyCode).HasName("PK_Currency_CurrencyCode");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Currencies", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Lookup table containing standard ISO currencies.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_Currency_Name").IsUnique();

//                b.Property(e => e.CurrencyCode)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("The ISO code for the Currency.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");
                
//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Currency name.");
//            });

//            builder.Entity<CurrencyRate>(b =>
//            {
//                //b.HasKey(e => e.CurrencyRateId).HasName("PK_CurrencyRate_CurrencyRateID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "CurrencyRates", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Currency exchange rates.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => new { e.CurrencyRateDate, e.FromCurrencyCode, e.ToCurrencyCode }, 
//                    "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode"
//                ).IsUnique();

//                //b.Property(e => e.CurrencyRateId)
//                //.HasComment("Primary key for CurrencyRate records.")
//                //.HasColumnName("CurrencyRateID");
                
//                b.Property(e => e.AverageRate)
//                .HasComment("Average exchange rate for the day.")
//                .HasColumnType("money");
                
//                b.Property(e => e.CurrencyRateDate)
//                .HasComment("Date and time the exchange rate was obtained.")
//                .HasColumnType("datetime");
                
//                b.Property(e => e.EndOfDayRate)
//                .HasComment("Final exchange rate for the day.")
//                .HasColumnType("money");
                
//                b.Property(e => e.FromCurrencyCode)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("Exchange rate was converted from this currency code.");
                
//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");
                
//                b.Property(e => e.ToCurrencyCode)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//                .IsFixedLength()
//                .HasComment("Exchange rate was converted to this currency code.");

//                b.HasOne(d => d.FromCurrencyCodeNavigation).WithMany(p => p.CurrencyRateFromCurrencyCodeNavigation)
//                .HasForeignKey(d => d.FromCurrencyCode)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ToCurrencyCodeNavigation).WithMany(p => p.CurrencyRateToCurrencyCodeNavigation)
//                .HasForeignKey(d => d.ToCurrencyCode)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<Customer>(b =>
//            {
//                //b.HasKey(e => e.CustomerId).HasName("PK_Customer_CustomerID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Customers", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Current customer information. Also see the Person and Store tables.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.AccountNumber, "AK_Customer_AccountNumber").IsUnique();

//                //b.HasIndex(e => e.Rowguid, "AK_Customer_rowguid").IsUnique();

//                b.HasIndex(e => e.TerritoryId, "IX_Customer_TerritoryID");

//                //b.Property(e => e.CustomerId)
//                //.HasComment("Primary key.")
//                //.HasColumnName("CustomerID");

//                b.Property(e => e.AccountNumber)
//                .IsRequired()
//                .HasMaxLength(10)
//                .IsUnicode(false)
//                .HasComputedColumnSql("(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))", false)
//                .HasComment("Unique number identifying the customer assigned by the accounting system.");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.PersonId)
//                .HasComment("Foreign key to Person.BusinessEntityID")
//                .HasColumnName("PersonID");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.Property(e => e.StoreId)
//                .HasComment("Foreign key to Store.BusinessEntityID")
//                .HasColumnName("StoreID");

//                b.Property(e => e.TerritoryId)
//                .HasComment("ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.")
//                .HasColumnName("TerritoryID");

//                b.HasOne(d => d.Person).WithMany(p => p.Customer).HasForeignKey(d => d.PersonId);

//                b.HasOne(d => d.Store).WithMany(p => p.Customer).HasForeignKey(d => d.StoreId);

//                b.HasOne(d => d.Territory).WithMany(p => p.Customer).HasForeignKey(d => d.TerritoryId);
//            });

//            builder.Entity<PersonCreditCard>(b =>
//            {
//                b.HasKey(e => new { e.BusinessEntityId, 
//                                    e.CreditCardId })
//                .HasName("PK_PersonCreditCard_BusinessEntityID_CreditCardID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "PersonCreditCards", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Cross-reference table mapping people to their credit card information in the CreditCard table. ")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.Property(e => e.BusinessEntityId)
//                .HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.")
//                .HasColumnName("BusinessEntityID");

//                b.Property(e => e.CreditCardId)
//                .HasComment("Credit card identification number. Foreign key to CreditCard.CreditCardID.")
//                .HasColumnName("CreditCardID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.HasOne(d => d.BusinessEntity).WithMany(p => p.PersonCreditCard)
//                .HasForeignKey(d => d.BusinessEntityId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.CreditCard).WithMany(p => p.PersonCreditCard)
//                .HasForeignKey(d => d.CreditCardId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<SalesOrderDetail>(b =>
//            {
//                b.HasKey(e => new { e.SalesOrderId, 
//                                    e.SalesOrderDetailId })
//                .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesOrderDetails", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, tb =>
//                    {
//                        tb.HasComment("Individual products associated with a specific sales order. See SalesOrderHeader.");
//                        tb.HasTrigger("iduSalesOrderDetail");
//                    }
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                //b.HasIndex(e => e.Rowguid, "AK_SalesOrderDetail_rowguid").IsUnique();

//                b.HasIndex(e => e.ProductId, "IX_SalesOrderDetail_ProductID");

//                b.Property(e => e.SalesOrderId)
//                .HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.")
//                .HasColumnName("SalesOrderID");

//                b.Property(e => e.SalesOrderDetailId)
//                .ValueGeneratedOnAdd()
//                .HasComment("Primary key. One incremental unique number per product sold.")
//                .HasColumnName("SalesOrderDetailID");

//                b.Property(e => e.CarrierTrackingNumber)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.CarrierTrackingNumberMaxLength)
//                .HasComment("Shipment tracking number supplied by the shipper.");

//                b.Property(e => e.LineTotal)
//                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
//                .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.")
//                .HasColumnType("numeric(38, 6)");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.OrderQty).HasComment("Quantity ordered per product.");

//                b.Property(e => e.ProductId)
//                .HasComment("Product sold to customer. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.Property(e => e.SpecialOfferId)
//                .HasComment("Promotional code. Foreign key to SpecialOffer.SpecialOfferID.")
//                .HasColumnName("SpecialOfferID");

//                b.Property(e => e.UnitPrice)
//                .HasComment("Selling price of a single product.")
//                .HasColumnType("money");

//                b.Property(e => e.UnitPriceDiscount)
//                .HasComment("Discount amount.")
//                .HasColumnType("money");

//                b.HasOne(d => d.SalesOrder)
//                .WithMany(p => p.SalesOrderDetail)
//                .HasForeignKey(d => d.SalesOrderId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.SpecialOfferProduct).WithMany(p => p.SalesOrderDetail)
//                .HasForeignKey(d => new { d.SpecialOfferId, d.ProductId })
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID");
//            });

//            builder.Entity<SalesOrderHeader>(b =>
//            {
//                //b.HasKey(e => e.SalesOrderId).HasName("PK_SalesOrderHeader_SalesOrderID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesOrderHeaders", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, table =>
//                    {
//                        table.HasComment("General sales order information.");
//                        table.HasTrigger("uSalesOrderHeader");
//                    }
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.SalesOrderNumber, "AK_SalesOrderHeader_SalesOrderNumber").IsUnique();

//                //b.HasIndex(e => e.Rowguid, "AK_SalesOrderHeader_rowguid").IsUnique();

//                b.HasIndex(e => e.CustomerId, "IX_SalesOrderHeader_CustomerID");

//                b.HasIndex(e => e.SalesPersonId, "IX_SalesOrderHeader_SalesPersonID");

//                //b.Property(e => e.SalesOrderId)
//                //.HasComment("Primary key.")
//                //.HasColumnName("SalesOrderID");
                
//                b.Property(e => e.AccountNumber)
//                .HasMaxLength(15)
//                .HasComment("Financial accounting number reference.");
                
//                b.Property(e => e.BillToAddressId)
//                .HasComment("Customer billing address. Foreign key to Address.AddressID.")
//                .HasColumnName("BillToAddressID");
                
//                b.Property(e => e.Comment)
//                .HasMaxLength(128)
//                .HasComment("Sales representative comments.");
                
//                b.Property(e => e.CreditCardApprovalCode)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.CreditCardNumberMaxLength)
//                .IsUnicode(false)
//                .HasComment("Approval code provided by the credit card company.");
                
//                b.Property(e => e.CreditCardId)
//                .HasComment("Credit card identification number. Foreign key to CreditCard.CreditCardID.")
//                .HasColumnName("CreditCardID");
                
//                b.Property(e => e.CurrencyRateId)
//                .HasComment("Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.")
//                .HasColumnName("CurrencyRateID");
                
//                b.Property(e => e.CustomerId)
//                .HasComment("Customer identification number. Foreign key to Customer.BusinessEntityID.")
//                .HasColumnName("CustomerID");
                
//                b.Property(e => e.DueDate)
//                .HasComment("Date the order is due to the customer.")
//                .HasColumnType("datetime");
                
//                b.Property(e => e.Freight)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Shipping cost.")
//                .HasColumnType("money");
                
//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");
                
//                b.Property(e => e.OnlineOrderFlag)
//                .IsRequired()
//                .HasDefaultValueSql("((1))")
//                .HasComment("0 = Order placed by sales person. 1 = Order placed online by customer.");
                
//                b.Property(e => e.OrderDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Dates the sales order was created.")
//                .HasColumnType("datetime");
                
//                b.Property(e => e.PurchaseOrderNumber)
//                .HasMaxLength(AdventureWorksAbpSharedConsts.PurchaseOrderNumberMaxLength)
//                .HasComment("Customer purchase order number reference.");
                
//                b.Property(e => e.RevisionNumber)
//                .HasComment("Incremental number to track changes to the sales order over time.");
               
//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");
                
//                b.Property(e => e.SalesOrderNumber)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.SalesOrderNumberMaxLength)
//                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", false)
//                .HasComment("Unique sales order identification number.");
               
//                b.Property(e => e.SalesPersonId)
//                .HasComment("Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.")
//                .HasColumnName("SalesPersonID");
                
//                b.Property(e => e.ShipDate)
//                .HasComment("Date the order was shipped to the customer.")
//                .HasColumnType("datetime");
                
//                b.Property(e => e.ShipMethodId)
//                .HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.")
//                .HasColumnName("ShipMethodID");
                
//                b.Property(e => e.ShipToAddressId)
//                .HasComment("Customer shipping address. Foreign key to Address.AddressID.")
//                .HasColumnName("ShipToAddressID");
               
//                b.Property(e => e.Status)
//                .HasDefaultValueSql("((1))")
//                .HasComment("Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled");
                
//                b.Property(e => e.SubTotal)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.")
//                .HasColumnType("money");
                
//                b.Property(e => e.TaxAmt)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Tax amount.")
//                .HasColumnType("money");
                
//                b.Property(e => e.TerritoryId)
//                .HasComment("Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.")
//                .HasColumnName("TerritoryID");
                
//                b.Property(e => e.TotalDue)
//                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false)
//                .HasComment("Total due from customer. Computed as Subtotal + TaxAmt + Freight.")
//                .HasColumnType("money");

//                b.HasOne(d => d.BillToAddress).WithMany(p => p.SalesOrderHeaderBillToAddress)
//                .HasForeignKey(d => d.BillToAddressId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.CreditCard).WithMany(p => p.SalesOrderHeader)
//                .HasForeignKey(d => d.CreditCardId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.CurrencyRate).WithMany(p => p.SalesOrderHeader)
//                .HasForeignKey(d => d.CurrencyRateId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.Customer).WithMany(p => p.SalesOrderHeader)
//                .HasForeignKey(d => d.CustomerId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.SalesPerson).WithMany(p => p.SalesOrderHeader)
//                .HasForeignKey(d => d.SalesPersonId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ShipMethod).WithMany(p => p.SalesOrderHeader)
//                .HasForeignKey(d => d.ShipMethodId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.ShipToAddress).WithMany(p => p.SalesOrderHeaderShipToAddress)
//                .HasForeignKey(d => d.ShipToAddressId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.Territory).WithMany(p => p.SalesOrderHeader)
//                .HasForeignKey(d => d.TerritoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<SalesOrderHeaderSalesReason>(b =>
//            {
//                b.HasKey(e => new { e.SalesOrderId, e.SalesReasonId })
//                    .HasName("PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesOrderHeaderSalesReasons", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Cross-reference table mapping sales orders to sales reason codes.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.Property(e => e.SalesOrderId)
//                .HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.")
//                .HasColumnName("SalesOrderID");

//                b.Property(e => e.SalesReasonId)
//                .HasComment("Primary key. Foreign key to SalesReason.SalesReasonID.")
//                .HasColumnName("SalesReasonID");

//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");

//                b.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderHeaderSalesReason).HasForeignKey(d => d.SalesOrderId);

//                b.HasOne(d => d.SalesReason).WithMany(p => p.SalesOrderHeaderSalesReason)
//                .HasForeignKey(d => d.SalesReasonId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<SalesPersonQuotaHistory>(b =>
//            {
//                b.HasKey(e => new { e.BusinessEntityId, 
//                                    e.QuotaDate })
//                .HasName("PK_SalesPersonQuotaHistory_BusinessEntityID_QuotaDate");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesPersonQuotaHistories", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Sales performance tracking.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Rowguid, "AK_SalesPersonQuotaHistory_rowguid").IsUnique();

//                b.Property(e => e.BusinessEntityId)
//                .HasComment("Sales person identification number. Foreign key to SalesPerson.BusinessEntityID.")
//                .HasColumnName("BusinessEntityID");

//                b.Property(e => e.QuotaDate)
//                .HasComment("Sales quota date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");

//                b.Property(e => e.Rowguid)
//                .HasDefaultValueSql("(newid())")
//                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                .HasColumnName("rowguid");

//                b.Property(e => e.SalesQuota)
//                .HasComment("Sales quota amount.")
//                .HasColumnType("money");

//                b.HasOne(d => d.BusinessEntity).WithMany(p => p.SalesPersonQuotaHistory)
//                .HasForeignKey(d => d.BusinessEntityId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<SalesPerson>(b =>
//            {
//                //b.HasKey(e => e.BusinessEntityId).HasName("PK_SalesPerson_BusinessEntityID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesPersons", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Sales representative current information.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.BusinessEntityId, "AK_SalesPerson_BusinessEntityId").IsUnique();

//                b.Property(e => e.BusinessEntityId)
//                .ValueGeneratedNever()
//                .HasComment("Primary key for SalesPerson records. Foreign key to Employee.BusinessEntityID")
//                .HasColumnName("BusinessEntityID");

//                b.Property(e => e.Bonus)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Bonus due if quota is met.")
//                .HasColumnType("money");

//                b.Property(e => e.CommissionPct)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Commision percent received per sale.")
//                .HasColumnType("smallmoney");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.Property(e => e.SalesLastYear)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Sales total of previous year.")
//                .HasColumnType("money");

//                b.Property(e => e.SalesQuota)
//                .HasComment("Projected yearly sales.")
//                .HasColumnType("money");

//                b.Property(e => e.SalesYtd)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Sales total year to date.")
//                .HasColumnType("money")
//                .HasColumnName("SalesYTD");

//                b.Property(e => e.TerritoryId)
//                .HasComment("Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.")
//                .HasColumnName("TerritoryID");

//                b.HasOne(d => d.BusinessEntity).WithOne(p => p.SalesPerson)
//                .HasForeignKey<SalesPerson>(d => d.BusinessEntityId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.Territory).WithMany(p => p.SalesPerson)
//                .HasForeignKey(d => d.TerritoryId);
//            });

//            builder.Entity<SalesReason>(b =>
//            {
//                //b.HasKey(e => e.SalesReasonId).HasName("PK_SalesReason_SalesReasonID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesReasons", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Lookup table of customer purchase reasons.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                //b.Property(e => e.SalesReasonId)
//                //.HasComment("Primary key for SalesReason records.")
//                //.HasColumnName("SalesReasonID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Sales reason description.");

//                b.Property(e => e.ReasonType)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Category the sales reason belongs to.");
//            });

//            builder.Entity<SalesTaxRate>(b =>
//            {
//                //b.HasKey(e => e.SalesTaxRateId).HasName("PK_SalesTaxRate_SalesTaxRateID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesTaxRates", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Tax rate lookup table.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => new { e.StateProvinceId, 
//                                      e.TaxType }, "AK_SalesTaxRate_StateProvinceID_TaxType")
//                .IsUnique();

//                //b.HasIndex(e => e.Rowguid, "AK_SalesTaxRate_rowguid").IsUnique();

//                //b.Property(e => e.SalesTaxRateId)
//                //.HasComment("Primary key for SalesTaxRate records.")
//                //.HasColumnName("SalesTaxRateID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Tax rate description.");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.Property(e => e.StateProvinceId)
//                .HasComment("State, province, or country/region the sales tax applies to.")
//                .HasColumnName("StateProvinceID");

//                b.Property(e => e.TaxRate)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Tax rate amount.")
//                .HasColumnType("smallmoney");

//                b.Property(e => e.TaxType).HasComment("1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.");

//                b.HasOne(d => d.StateProvince).WithMany()
//                .HasForeignKey(d => d.StateProvinceId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<SalesTerritory>(b =>
//            {
//                //b.HasKey(e => e.TerritoryId).HasName("PK_SalesTerritory_TerritoryID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesTerritories", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Sales territory lookup table.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => e.Name, "AK_SalesTerritory_Name").IsUnique();

//                //b.HasIndex(e => e.Rowguid, "AK_SalesTerritory_rowguid").IsUnique();

//                //b.Property(e => e.TerritoryId)
//                //.HasComment("Primary key for SalesTerritory records.")
//                //.HasColumnName("TerritoryID");
                
//                b.Property(e => e.CostLastYear)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Business costs in the territory the previous year.")
//                .HasColumnType("money");
                
//                b.Property(e => e.CostYtd)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Business costs in the territory year to date.")
//                .HasColumnType("money")
//                .HasColumnName("CostYTD");
                
//                b.Property(e => e.CountryRegionCode)
//                .IsRequired()
//                .HasMaxLength(3)
//                .HasComment("ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode.");
                
//                b.Property(e => e.Group)
//                .IsRequired()
//                .HasMaxLength(50)
//                .HasComment("Geographic area to which the sales territory belong.");
                
//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");
                
//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(50)
//                .HasComment("Sales territory description");
                
//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");
                
//                b.Property(e => e.SalesLastYear)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Sales in the territory the previous year.")
//                .HasColumnType("money");
                
//                b.Property(e => e.SalesYtd)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Sales in the territory year to date.")
//                .HasColumnType("money")
//                .HasColumnName("SalesYTD");

//                b.HasOne(d => d.CountryRegionCodeNavigation).WithMany(p => p.SalesTerritory)
//                .HasForeignKey(d => d.CountryRegionCode)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<SalesTerritoryHistory>(b =>
//            {
//                b.HasKey(e => new { e.BusinessEntityId, 
//                                    e.StartDate, 
//                                    e.TerritoryId })
//                .HasName("PK_SalesTerritoryHistory_BusinessEntityID_StartDate_TerritoryID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SalesTerritoryHistories", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Sales representative transfers to other sales territories.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                //b.HasIndex(e => e.Rowguid, "AK_SalesTerritoryHistory_rowguid").IsUnique();

//                b.Property(e => e.BusinessEntityId)
//                .HasComment("Primary key. The sales rep.  Foreign key to SalesPerson.BusinessEntityID.")
//                .HasColumnName("BusinessEntityID");

//                b.Property(e => e.StartDate)
//                .HasComment("Primary key. Date the sales representive started work in the territory.")
//                .HasColumnType("datetime");

//                b.Property(e => e.TerritoryId)
//                .HasComment("Primary key. Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.")
//                .HasColumnName("TerritoryID");

//                b.Property(e => e.EndDate)
//                .HasComment("Date the sales representative left work in the territory.")
//                .HasColumnType("datetime");

//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.HasOne(d => d.BusinessEntity).WithMany(p => p.SalesTerritoryHistory)
//                .HasForeignKey(d => d.BusinessEntityId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.Territory).WithMany(p => p.SalesTerritoryHistory)
//                .HasForeignKey(d => d.TerritoryId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<ShoppingCartItem>(b =>
//            {
//                //b.HasKey(e => e.ShoppingCartItemId).HasName("PK_ShoppingCartItem_ShoppingCartItemID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ShoppingCartItems", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Contains online customer orders until the order is submitted or cancelled.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                b.HasIndex(e => new { e.ShoppingCartId, 
//                                      e.ProductId }, "IX_ShoppingCartItem_ShoppingCartID_ProductID");

//                //b.Property(e => e.ShoppingCartItemId)
//                //.HasComment("Primary key for ShoppingCartItem records.")
//                //.HasColumnName("ShoppingCartItemID");

//                b.Property(e => e.DateCreated)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date the time the record was created.")
//                .HasColumnType("datetime");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.ProductId)
//                .HasComment("Product ordered. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                b.Property(e => e.Quantity)
//                .HasDefaultValueSql("((1))")
//                .HasComment("Product quantity ordered.");

//                b.Property(e => e.ShoppingCartId)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Shopping cart identification number.")
//                .HasColumnName("ShoppingCartID");

//                b.HasOne(d => d.Product).WithMany(p => p.ShoppingCartItem)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<SpecialOfferProduct>(b =>
//            {
//                b.HasKey(e => new { e.SpecialOfferId, 
//                                    e.ProductId })
//                .HasName("PK_SpecialOfferProduct_SpecialOfferID_ProductID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SpecialOfferProducts", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Cross-reference table mapping products to special offer discounts.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                //b.HasIndex(e => e.Rowguid, "AK_SpecialOfferProduct_rowguid").IsUnique();

//                b.HasIndex(e => e.ProductId, "IX_SpecialOfferProduct_ProductID");

//                b.Property(e => e.SpecialOfferId)
//                .HasComment("Primary key for SpecialOfferProduct records.")
//                .HasColumnName("SpecialOfferID");

//                b.Property(e => e.ProductId)
//                .HasComment("Product identification number. Foreign key to Product.ProductID.")
//                .HasColumnName("ProductID");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.HasOne(d => d.Product).WithMany(p => p.SpecialOfferProduct)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.SpecialOffer).WithMany(p => p.SpecialOfferProduct)
//                .HasForeignKey(d => d.SpecialOfferId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });

//            builder.Entity<SpecialOffer>(b =>
//            {
//                //b.HasKey(e => e.SpecialOfferId).HasName("PK_SpecialOffer_SpecialOfferID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "SpecialOffers", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Sale discounts lookup table.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                //b.HasIndex(e => e.Rowguid, "AK_SpecialOffer_rowguid").IsUnique();

//                //b.Property(e => e.SpecialOfferId)
//                //.HasComment("Primary key for SpecialOffer records.")
//                //.HasColumnName("SpecialOfferID");

//                b.Property(e => e.Category)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Group the discount applies to such as Reseller or Customer.");

//                b.Property(e => e.Description)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.RemarksMaxLength)
//                .HasComment("Discount description.");

//                b.Property(e => e.DiscountPct)
//                .HasDefaultValueSql("((0.00))")
//                .HasComment("Discount precentage.")
//                .HasColumnType("smallmoney");

//                b.Property(e => e.EndDate)
//                .HasComment("Discount end date.")
//                .HasColumnType("datetime");
//                b.Property(e => e.MaxQty).HasComment("Maximum discount percent allowed.");

//                b.Property(e => e.MinQty).HasComment("Minimum discount percent allowed.");

//                b.Property(e => e.ModifiedDate)
//                .HasDefaultValueSql("(getdate())")
//                .HasComment("Date and time the record was last updated.")
//                .HasColumnType("datetime");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.Property(e => e.StartDate)
//                .HasComment("Discount start date.")
//                .HasColumnType("datetime");

//                b.Property(e => e.Type)
//                .IsRequired()
//                .HasMaxLength(50)
//                .HasComment("Discount type category.");
//            });

//            builder.Entity<Store>(b =>
//            {
//                //b.HasKey(e => e.BusinessEntityId).HasName("PK_Store_BusinessEntityID");

//                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Stores", 
//                    AdventureWorksAbpSharedConsts.SalesDbSchema, 
//                    table => table.HasComment("Customers (resellers) of Adventure Works products.")
//                );

//                b.ConfigureByConvention(); //auto configure for the base class props

//                //b.HasIndex(e => e.Rowguid, "AK_Store_rowguid").IsUnique();

//                b.HasIndex(e => e.SalesPersonId, "IX_Store_SalesPersonID");

//                b.HasIndex(e => e.Demographics, "PXML_Store_Demographics");

//                b.Property(e => e.BusinessEntityId)
//                .ValueGeneratedNever()
//                .HasComment("Primary key. Foreign key to Customer.BusinessEntityID.")
//                .HasColumnName("BusinessEntityID");

//                b.Property(e => e.Demographics)
//                .HasComment("Demographic informationg about the store such as the number of employees, annual sales and store type.")
//                .HasColumnType("xml");

//                //b.Property(e => e.ModifiedDate)
//                //.HasDefaultValueSql("(getdate())")
//                //.HasComment("Date and time the record was last updated.")
//                //.HasColumnType("datetime");

//                b.Property(e => e.Name)
//                .IsRequired()
//                .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//                .HasComment("Name of the store.");

//                //b.Property(e => e.Rowguid)
//                //.HasDefaultValueSql("(newid())")
//                //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//                //.HasColumnName("rowguid");

//                b.Property(e => e.SalesPersonId)
//                .HasComment("ID of the sales person assigned to the customer. Foreign key to SalesPerson.BusinessEntityID.")
//                .HasColumnName("SalesPersonID");

//                b.HasOne(d => d.BusinessEntity).WithOne(p => p.Store)
//                .HasForeignKey<Store>(d => d.BusinessEntityId)
//                .OnDelete(DeleteBehavior.ClientSetNull);

//                b.HasOne(d => d.SalesPerson).WithMany(p => p.Store)
//                .HasForeignKey(d => d.SalesPersonId)
//                .OnDelete(DeleteBehavior.ClientSetNull);
//            });
//        }
//    }
//}

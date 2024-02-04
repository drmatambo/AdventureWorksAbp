//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp;
//using Volo.Abp.Data;
//using Volo.Abp.EntityFrameworkCore.Modeling;
////using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
//using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
//using VumbaSoft.AdventureWorksAbp.Persons.Addresses;
//using VumbaSoft.AdventureWorksAbp.Persons.AddressTypes;
//using VumbaSoft.AdventureWorksAbp.Persons.BusinessEntities;
//using VumbaSoft.AdventureWorksAbp.Persons.BusinessEntityAddresses;
//using VumbaSoft.AdventureWorksAbp.Persons.BusinessEntityContacts;
//using VumbaSoft.AdventureWorksAbp.Persons.ContactTypes;
//using VumbaSoft.AdventureWorksAbp.Persons.CountryRegions;
//using VumbaSoft.AdventureWorksAbp.Persons.EmailAddresses;
//using VumbaSoft.AdventureWorksAbp.Persons.PersonPhones;
//using VumbaSoft.AdventureWorksAbp.Persons.Persons;
//using VumbaSoft.AdventureWorksAbp.Persons.PhoneNumberTypes;
//using VumbaSoft.AdventureWorksAbp.Persons.StateProvinces;

//namespace VumbaSoft.AdventureWorksAbp.EntityConfigModelBuilderExtentios;

//public static class PersonDbContextModelBuilderExtensions
//{
//    public static void ConfigurePerson([NotNull] this ModelBuilder builder)
//    {
//        Check.NotNull(builder, nameof(builder));

//        builder.Entity<Address>(b =>
//        {
//            //b.HasKey(e => e.AddressId).HasName("PK_Address_AddressID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Addresses", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema, 
//                table => table.HasComment("Street address information for customers, employees, and vendors.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            //b.HasIndex(e => e.Rowguid, "AK_Address_rowguid").IsUnique();

//            b.HasIndex(e => new { 
//                                  e.AddressLine1, 
//                                  e.AddressLine2, 
//                                  e.City, 
//                                  e.StateProvinceId, 
//                                  e.PostalCode }, "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode")
//            .IsUnique();

//            b.HasIndex(e => e.StateProvinceId, "IX_Address_StateProvinceID");

//            //b.Property(e => e.AddressId)
//            //.HasComment("Primary key for Address records.")
//            //.HasColumnName("AddressID");

//            b.Property(e => e.AddressLine1)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.AdressLineMaxLength)
//            .HasComment("First street address line.");

//            b.Property(e => e.AddressLine2)
//            .HasMaxLength(AdventureWorksAbpSharedConsts.AdressLineMaxLength)
//            .HasComment("Second street address line.");

//            b.Property(e => e.City)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.CityMaxLength)
//            .HasComment("Name of the city.");

//            b.Property(e => e.ModifiedDate)
//            .HasDefaultValueSql("(getdate())")
//            .HasComment("Date and time the record was last updated.")
//            .HasColumnType("datetime");

//            b.Property(e => e.PostalCode)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.ZipPostalCodeMaxLength)
//            .HasComment("Postal code for the street address.");

//            //b.Property(e => e.Rowguid)
//            //.HasDefaultValueSql("(newid())")
//            //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//            //.HasColumnName("rowguid");

//            b.Property(e => e.StateProvinceId)
//            .HasComment("Unique identification number for the state or province. Foreign key to StateProvince table.")
//            .HasColumnName("StateProvinceID");

//            b.HasOne(d => d.StateProvince).WithMany()
//            .HasForeignKey(d => d.StateProvinceId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.StateProvince).WithMany()
//            .HasForeignKey(d => d.StateProvinceId)
//            .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        builder.Entity<AddressType>(b =>
//        {
//        //b.HasKey(e => e.AddressTypeId).HasName("PK_AddressType_AddressTypeID");

//        b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "AddressTypes", 
//            AdventureWorksAbpSharedConsts.PersonsDbSchema, 
//            table => table.HasComment("Types of addresses stored in the Address table.")
//        );

//        b.ConfigureByConvention(); //auto configure for the base class props

//        b.HasIndex(e => e.Name, "AK_AddressType_Name").IsUnique();

//        //b.HasIndex(e => e.Rowguid, "AK_AddressType_rowguid").IsUnique();

//        //b.Property(e => e.AddressTypeId)
//        //.HasComment("Primary key for AddressType records.")
//        //.HasColumnName("AddressTypeID");

//        //b.Property(e => e.ModifiedDate)
//        //.HasDefaultValueSql("(getdate())")
//        //.HasComment("Date and time the record was last updated.")
//        //.HasColumnType("datetime");

//        b.Property(e => e.Name)
//        .IsRequired()
//        .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//        .HasComment("Address type description. For example, Billing, Home, or Shipping.");

//        //b.Property(e => e.Rowguid)
//        //.HasDefaultValueSql("(newid())")
//        //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//        //.HasColumnName("rowguid");

//        });

//        builder.Entity<BusinessEntity>(b =>
//        {
//            //b.HasKey(e => e.BusinessEntityId).HasName("PK_BusinessEntity_BusinessEntityID");

//            //b.ToTable("BusinessEntity", "Person", tb => tb.HasComment("Source of the ID that connects vendors, customers, and employees with address and contact information."));
//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "BusinessEntities", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("Source of the ID that connects vendors, customers, and employees with address and contact information.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            //b.HasIndex(e => e.Rowguid, "AK_BusinessEntity_rowguid").IsUnique();

//            //b.Property(e => e.BusinessEntityId)
//            //.HasComment("Primary key for all customers, vendors, and employees.")
//            //.HasColumnName("BusinessEntityID");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            //b.Property(e => e.Rowguid)
//            //.HasDefaultValueSql("(newid())")
//            //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//            //.HasColumnName("rowguid");

//        });

//        builder.Entity<BusinessEntityAddress>(b =>
//        {
//            b.HasKey(e => new { e.BusinessEntityId, 
//                                e.AddressId, 
//                                e.AddressTypeId })
//            .HasName("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID");

//            //b.ToTable("BusinessEntityAddress", "Person", tb => tb.HasComment("Cross-reference table mapping customers, vendors, and employees to their addresses."));

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "BusinessEntityAddresses", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("Cross-reference table mapping customers, vendors, and employees to their addresses.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            //b.HasIndex(e => e.Rowguid, "AK_BusinessEntityAddress_rowguid").IsUnique();

//            b.HasIndex(e => e.AddressId, "IX_BusinessEntityAddress_AddressID");

//            b.HasIndex(e => e.AddressTypeId, "IX_BusinessEntityAddress_AddressTypeID");

//            b.Property(e => e.BusinessEntityId)
//            .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.")
//            .HasColumnName("BusinessEntityID");

//            b.Property(e => e.AddressId)
//            .HasComment("Primary key. Foreign key to Address.AddressID.")
//            .HasColumnName("AddressID");

//            b.Property(e => e.AddressTypeId)
//            .HasComment("Primary key. Foreign key to AddressType.AddressTypeID.")
//            .HasColumnName("AddressTypeID");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            //b.Property(e => e.Rowguid)
//            //.HasDefaultValueSql("(newid())")
//            //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//            //.HasColumnName("rowguid");

//            b.HasOne(d => d.Address).WithMany(p => p.BusinessEntityAddress)
//            .HasForeignKey(d => d.AddressId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.AddressType).WithMany(p => p.BusinessEntityAddress)
//            .HasForeignKey(d => d.AddressTypeId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.BusinessEntity).WithMany(p => p.BusinessEntityAddress)
//            .HasForeignKey(d => d.BusinessEntityId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//        });

//        builder.Entity<BusinessEntityContact>(b =>
//        {
//            b.HasKey(e => new { e.BusinessEntityId, 
//                                e.PersonId, 
//                                e.ContactTypeId })
//            .HasName("PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID");

//            //b.ToTable("BusinessEntityContact", "Person", tb => tb.HasComment("Cross-reference table mapping stores, vendors, and employees to people"));

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "BusinessEntityContacts", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("Cross-reference table mapping stores, vendors, and employees to people")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            //b.HasIndex(e => e.Rowguid, "AK_BusinessEntityContact_rowguid").IsUnique();

//            b.HasIndex(e => e.ContactTypeId, "IX_BusinessEntityContact_ContactTypeID");

//            b.HasIndex(e => e.PersonId, "IX_BusinessEntityContact_PersonID");

//            b.Property(e => e.BusinessEntityId)
//            .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.")
//            .HasColumnName("BusinessEntityID");

//            b.Property(e => e.PersonId)
//            .HasComment("Primary key. Foreign key to Person.BusinessEntityID.")
//            .HasColumnName("PersonID");

//            b.Property(e => e.ContactTypeId)
//            .HasComment("Primary key.  Foreign key to ContactType.ContactTypeID.")
//            .HasColumnName("ContactTypeID");

//            b.Property(e => e.ModifiedDate)
//            .HasDefaultValueSql("(getdate())")
//            .HasComment("Date and time the record was last updated.")
//            .HasColumnType("datetime");

//            //b.Property(e => e.Rowguid)
//            //.HasDefaultValueSql("(newid())")
//            //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//            //.HasColumnName("rowguid");

//            b.HasOne(d => d.BusinessEntity).WithMany(p => p.BusinessEntityContact)
//            .HasForeignKey(d => d.BusinessEntityId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.ContactType).WithMany(p => p.BusinessEntityContact)
//            .HasForeignKey(d => d.ContactTypeId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.Person).WithMany(p => p.BusinessEntityContact)
//            .HasForeignKey(d => d.PersonId)
//            .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        builder.Entity<ContactType>(b =>
//        {
//            //b.HasKey(e => e.ContactTypeId).HasName("PK_ContactType_ContactTypeID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "ContactTypes", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("Lookup table containing the types of business entity contacts.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(e => e.Name, "AK_ContactType_Name").IsUnique();

//            //b.Property(e => e.ContactTypeId)
//            //.HasComment("Primary key for ContactType records.")
//            //.HasColumnName("ContactTypeID");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            b.Property(e => e.Name)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("Contact type description.");
//        });

//        builder.Entity<CountryRegion>(b =>
//        {
//            //b.HasKey(e => e.CountryRegionCode).HasName("PK_CountryRegion_CountryRegionCode");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "CountryRegions", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("Lookup table containing the ISO standard codes for countries and regions.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(e => e.Name, "AK_CountryRegion_Name").IsUnique();

//            b.Property(e => e.CountryRegionCode)
//            .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//            .HasComment("ISO standard code for countries and regions.");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            b.Property(e => e.Name)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("Country or region name.");
//        });

//        builder.Entity<EmailAddress>(b =>
//        {
//            b.HasKey(e => new { e.BusinessEntityId, 
//                                e.EmailAddressId })
//            .HasName("PK_EmailAddress_BusinessEntityID_EmailAddressID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "EmailAddresses", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("Where to send a person email.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(e => e.EmailAddress1, "IX_EmailAddress_EmailAddress");

//            b.Property(e => e.BusinessEntityId)
//            .HasComment("Primary key. Person associated with this email address.  Foreign key to Person.BusinessEntityID")
//            .HasColumnName("BusinessEntityID");

//            b.Property(e => e.EmailAddressId)
//            .ValueGeneratedOnAdd()
//            .HasComment("Primary key. ID of this email address.")
//            .HasColumnName("EmailAddressID");

//            b.Property(e => e.EmailAddress1)
//            .HasMaxLength(AdventureWorksAbpSharedConsts.EmailAddressMaxLength)
//            .HasComment("E-mail address for the person.")
//            .HasColumnName("EmailAddress");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            //b.Property(e => e.Rowguid)
//            //.HasDefaultValueSql("(newid())")
//            //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//            //.HasColumnName("rowguid");

//            b.HasOne(d => d.BusinessEntity).WithMany(p => p.EmailAddress)
//            .HasForeignKey(d => d.BusinessEntityId)
//            .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        builder.Entity<PersonPhone>(b =>
//        {
//            b.HasKey(e => new { e.BusinessEntityId, 
//                                e.PhoneNumber, 
//                                e.PhoneNumberTypeId })
//            .HasName("PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "PersonPhones", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("Telephone number and type of a person.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(e => e.PhoneNumber, "IX_PersonPhone_PhoneNumber");

//            b.Property(e => e.BusinessEntityId)
//            .HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.")
//            .HasColumnName("BusinessEntityID");

//            b.Property(e => e.PhoneNumber)
//            .HasMaxLength(AdventureWorksAbpSharedConsts.PhoneMaxLength)
//            .HasComment("Telephone number identification number.");

//            b.Property(e => e.PhoneNumberTypeId)
//            .HasComment("Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.")
//            .HasColumnName("PhoneNumberTypeID");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            b.HasOne(d => d.BusinessEntity).WithMany(p => p.PersonPhone)
//            .HasForeignKey(d => d.BusinessEntityId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.PhoneNumberType).WithMany(p => p.PersonPhone)
//            .HasForeignKey(d => d.PhoneNumberTypeId)
//            .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        builder.Entity<Person>(b =>
//        {
//            //b.HasKey(e => e.BusinessEntityId).HasName("PK_Person_BusinessEntityID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Persons", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema, 
//                table =>
//                    {
//                        table.HasComment("Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.");
//                        table.HasTrigger("iuPerson");
//                    }
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            //b.HasIndex(e => e.Rowguid, "AK_Person_rowguid").IsUnique();

//            b.HasIndex(e => new { e.LastName, e.FirstName, e.MiddleName }, "IX_Person_LastName_FirstName_MiddleName");

//            b.HasIndex(e => e.AdditionalContactInfo, "PXML_Person_AddContact");

//            b.HasIndex(e => e.Demographics, "PXML_Person_Demographics");

//            b.HasIndex(e => e.Demographics, "XMLPATH_Person_Demographics");

//            b.HasIndex(e => e.Demographics, "XMLPROPERTY_Person_Demographics");

//            b.HasIndex(e => e.Demographics, "XMLVALUE_Person_Demographics");

//            //b.Property(e => e.BusinessEntityId)
//            //.ValueGeneratedNever()
//            //.HasComment("Primary key for Person records.")
//            //.HasColumnName("BusinessEntityID");

//            b.Property(e => e.AdditionalContactInfo)
//            .HasComment("Additional contact information about the person stored in xml format. ")
//            .HasColumnType("xml");

//            b.Property(e => e.Demographics)
//            .HasComment("Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.")
//            .HasColumnType("xml");

//            b.Property(e => e.EmailPromotion).HasComment("0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. ");

//            b.Property(e => e.FirstName)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("First name of the person.");

//            b.Property(e => e.LastName)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.LastNameMaxLength)
//            .HasComment("Last name of the person.");

//            b.Property(e => e.MiddleName)
//            .HasMaxLength(AdventureWorksAbpSharedConsts.MidNameMaxLength)
//            .HasComment("Middle name or middle initial of the person.");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            b.Property(e => e.NameStyle).HasComment("0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");

//            b.Property(e => e.PersonType)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//            .IsFixedLength()
//            .HasComment("Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact");

//            //b.Property(e => e.Rowguid)
//            //.HasDefaultValueSql("(newid())")
//            //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//            //.HasColumnName("rowguid");

//            b.Property(e => e.Suffix)
//            .HasMaxLength(10)
//            .HasComment("Surname suffix. For example, Sr. or Jr.");

//            b.Property(e => e.Title)
//            .HasMaxLength(8)
//            .HasComment("A courtesy title. For example, Mr. or Ms.");

//            //b.HasOne(d => d.BusinessEntity).WithOne(p => p.Person)
//            //.HasForeignKey<Person>(d => d.BusinessEntityId)
//            //.OnDelete(DeleteBehavior.ClientSetNull);

//            //b.HasOne(d => d.BusinessEntity).WithOne(p => p.Person)
//            //.HasForeignKey<Person>()
//            //.OnDelete(DeleteBehavior.ClientSetNull);
//        });



//        builder.Entity<PhoneNumberType>(b =>
//        {
//            //b.HasKey(e => e.PhoneNumberTypeId).HasName("PK_PhoneNumberType_PhoneNumberTypeID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "PhoneNumberTypes", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("Type of phone number of a person.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            //b.Property(e => e.PhoneNumberTypeId)
//            //.HasComment("Primary key for telephone number type records.")
//            //.HasColumnName("PhoneNumberTypeID");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            b.Property(e => e.Name)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("Name of the telephone number type");
//        });

//        //TODO: Duplicated table in Demographics module, to be solved 
//        builder.Entity<StateProvince>(b =>
//        {
//            //b.HasKey(e => e.StateProvinceId).HasName("PK_StateProvince_StateProvinceID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "StateProvinces", 
//                AdventureWorksAbpSharedConsts.PersonsDbSchema,
//                table => table.HasComment("State and province lookup table.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(e => e.Name, "AK_StateProvince_Name").IsUnique();

//            b.HasIndex(e => new { e.StateProvinceCode, 
//                                  e.CountryRegionCode }, "AK_StateProvince_StateProvinceCode_CountryRegionCode")
//            .IsUnique();

//            //b.HasIndex(e => e.Rowguid, "AK_StateProvince_rowguid").IsUnique();

//            //b.Property(e => e.StateProvinceId)
//            //.HasComment("Primary key for StateProvince records.")
//            //.HasColumnName("StateProvinceID");

//            b.Property(e => e.CountryRegionCode)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//            .HasComment("ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ");

//            b.Property(e => e.IsOnlyStateProvinceFlag)
//            .IsRequired()
//            .HasDefaultValueSql("((1))")
//            .HasComment("0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.");

//            //b.Property(e => e.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            b.Property(e => e.Name)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("State or province description.");

//            b.Property(e => e.Rowguid)
//            .HasDefaultValueSql("(newid())")
//            .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//            .HasColumnName("rowguid");

//            b.Property(e => e.StateProvinceCode)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength)
//            .IsFixedLength()
//            .HasComment("ISO standard state or province code.");

//            b.Property(e => e.TerritoryId)
//            .HasComment("ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.")
//            .HasColumnName("TerritoryID");

//            b.HasOne(d => d.CountryRegionCodeNavigation).WithMany(p => p.StateProvince)
//            .HasForeignKey(d => d.CountryRegionCode)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.Territory).WithMany(p => p.StateProvince)
//            .HasForeignKey(d => d.TerritoryId)
//            .OnDelete(DeleteBehavior.ClientSetNull);
//        });
//    }
//}

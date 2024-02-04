//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics.CodeAnalysis;
//using Volo.Abp;
//using Volo.Abp.EntityFrameworkCore.Modeling;
//using VumbaSoft.AdventureWorksAbp.HumanResources.Departments;
//using VumbaSoft.AdventureWorksAbp.HumanResources.EmployeeDepartmentHistories;
//using VumbaSoft.AdventureWorksAbp.HumanResources.EmployeePayHistories;
//using VumbaSoft.AdventureWorksAbp.HumanResources.Employees;
//using VumbaSoft.AdventureWorksAbp.HumanResources.JobCandidates;
//using VumbaSoft.AdventureWorksAbp.HumanResources.Shifties;

//namespace VumbaSoft.AdventureWorksAbp.EntityConfigModelBuilderExtentios;

//public static class HumanResourcesDbContextModelBuilderExtensions
//{
//    public static void ConfigureHumanResources([NotNull] this ModelBuilder builder)
//    {
//        Check.NotNull(builder, nameof(builder));

//        builder.Entity<Department>(b =>
//        {
//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Departments", 
//                AdventureWorksAbpSharedConsts.HumanResourcesDbSchema, 
//                table => table.HasComment("Lookup table containing the departments within the Adventure Works Cycles company.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(x => x.Name, "AK_Department_Name").IsUnique();

//            b.Property(x => x.GroupName)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("Name of the group to which the department belongs.");

//            b.Property(x => x.Name)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("Name of the department.");
//        });

//        builder.Entity<EmployeeDepartmentHistory>(b =>
//        {
//            b.HasKey(x => new { x.BusinessEntityId, 
//                                x.StartDate, 
//                                x.DepartmentId, 
//                                x.ShiftId })
//                .HasName("PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "EmployeeDepartmentHistories", 
//                AdventureWorksAbpSharedConsts.HumanResourcesDbSchema, 
//                table => table.HasComment("Employee department transfers.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(x => x.DepartmentId, "IX_EmployeeDepartmentHistory_DepartmentID");

//            b.HasIndex(x => x.ShiftId, "IX_EmployeeDepartmentHistory_ShiftID");

//            b.Property(x => x.BusinessEntityId)
//            .HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.")
//            .HasColumnName("BusinessEntityID");

//            b.Property(x => x.StartDate)
//            .HasComment("Date the employee started work in the department.")
//            .HasColumnType("date");

//            b.Property(x => x.DepartmentId)
//            .HasComment("Department in which the employee worked including currently. Foreign key to Department.DepartmentID.")
//            .HasColumnName("DepartmentID");

//            b.Property(x => x.ShiftId)
//            .HasComment("Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.")
//            .HasColumnName("ShiftID");

//            b.Property(x => x.EndDate)
//            .HasComment("Date the employee left the department. NULL = Current department.")
//            .HasColumnType("date");

//            b.HasOne(d => d.BusinessEntity).WithMany(p => p.EmployeeDepartmentHistory)
//            .HasForeignKey(d => d.BusinessEntityId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.Department).WithMany()
//            .HasForeignKey(d => d.DepartmentId)
//            .OnDelete(DeleteBehavior.ClientSetNull);

//            b.HasOne(d => d.Shift).WithMany()
//            .HasForeignKey(d => d.ShiftId)
//            .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        builder.Entity<EmployeePayHistory>(b =>
//        {
//            b.HasKey(x => new { x.BusinessEntityId, 
//                                x.RateChangeDate })
//            .HasName("PK_EmployeePayHistory_BusinessEntityID_RateChangeDate");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "EmployeePayHistories", 
//                AdventureWorksAbpSharedConsts.HumanResourcesDbSchema, 
//                table => table.HasComment("Employee pay history.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.Property(x => x.BusinessEntityId)
//            .HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.")
//            .HasColumnName("BusinessEntityID");

//            b.Property(x => x.RateChangeDate)
//            .HasComment("Date the change in pay is effective")
//            .HasColumnType("datetime");

//            b.Property(x => x.PayFrequency).HasComment("1 = Salary received monthly, 2 = Salary received biweekly");

//            b.Property(x => x.Rate)
//            .HasComment("Salary hourly rate.")
//            .HasColumnType("money");

//            b.HasOne(d => d.BusinessEntity).WithMany(p => p.EmployeePayHistory)
//            .HasForeignKey(d => d.BusinessEntityId)
//            .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        builder.Entity<Employee>(b =>
//        {
//            //b.HasIndex(x => x.LoginId, "AK_Employee_LoginID").IsUnique();
//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Employees", 
//                AdventureWorksAbpSharedConsts.HumanResourcesDbSchema, 
//                table => table.HasComment("Employees table")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(x => x.NationalIdnumber, "AK_Employee_NationalIDNumber").IsUnique();

//            //b.HasIndex(x => x.Rowguid, "AK_Employee_rowguid").IsUnique();

//            b.Property(x => x.BusinessEntityId)
//            .ValueGeneratedNever()
//            .HasComment("Primary key for Employee records.  Foreign key to Businessb.BusinessEntityID.")
//            .HasColumnName("BusinessEntityID");

//            b.Property(x => x.BirthDate)
//            .HasComment("Date of birth.")
//            .HasColumnType("date");

//            b.Property(x => x.CurrentFlag)
//            .IsRequired()
//            .HasDefaultValueSql("((1))")
//            .HasComment("0 = Inactive, 1 = Active");

//            b.Property(x => x.Gender)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedOneLetterLengthColumnMaxLength)
//            .IsFixedLength()
//            .HasComment("M = Male, F = Female");

//            b.Property(x => x.HireDate)
//            .HasComment("Employee hired on this date.")
//            .HasColumnType("date");

//            b.Property(x => x.JobTitle)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("Work title such as Buyer or Sales Representative.");

//            //b.Property(x => x.LoginId)
//            //.IsRequired()
//            //.HasMaxLength(256)
//            //.HasComment("Network login.")
//            //.HasColumnName("LoginID");

//            b.Property(x => x.MaritalStatus)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.IsFixedOneLetterLengthColumnMaxLength)
//            .IsFixedLength()
//            .HasComment("M = Married, S = Single, D = Divorced");

//            b.Property(x => x.NationalIdnumber)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NationalIdentityMaxLength)
//            .HasComment("Unique national identification number such as a social security number.")
//            .HasColumnName("NationalIDNumber");

//            b.Property(x => x.OrganizationLevel)
//            .HasComputedColumnSql("([OrganizationNode].[GetLevel]())", false)
//            .HasComment("The depth of the employee in the corporate hierarchy.");

//            //b.Property(x => x.Rowguid)
//            //.HasDefaultValueSql("(newid())")
//            //.HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
//            //.HasColumnName("rowguid");

//            b.Property(x => x.SalariedFlag)
//            .IsRequired()
//            .HasDefaultValueSql("((1))")
//            .HasComment("Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.");

//            b.Property(x => x.SickLeaveHours).HasComment("Number of available sick leave hours.");

//            b.Property(x => x.PaidDaysOfLeave).HasComment("Paid days of leave, included in the collective bargaining");

//            b.Property(x => x.VacationHours).HasComment("Number of available vacation hours.");

//            b.HasOne(d => d.BusinessEntity).WithOne(p => p.Employee)
//            .HasForeignKey<Employee>(d => d.BusinessEntityId)
//            .OnDelete(DeleteBehavior.ClientSetNull);
//        });

//        builder.Entity<JobCandidate>(b =>
//        {
//            //b.HasKey(x => x.JobCandidateId).HasName("PK_JobCandidate_JobCandidateID");

//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "JobCandidates",
//                AdventureWorksAbpSharedConsts.HumanResourcesDbSchema, 
//                table => table.HasComment("Résumés submitted to Human Resources by job applicants.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(x => x.BusinessEntityId, "IX_JobCandidate_BusinessEntityID");

//            //b.Property(x => x.JobCandidateId)
//            //.HasComment("Primary key for JobCandidate records.")
//            //.HasColumnName("JobCandidateID");

//            b.Property(x => x.BusinessEntityId)
//            .HasComment("Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.")
//            .HasColumnName("BusinessEntityID");

//            //b.Property(x => x.ModifiedDate)
//            //.HasDefaultValueSql("(getdate())")
//            //.HasComment("Date and time the record was last updated.")
//            //.HasColumnType("datetime");

//            b.Property(x => x.Resume)
//            .HasComment("Résumé in XML format.")
//            .HasColumnType("xml");

//            b.HasOne(d => d.BusinessEntity).WithMany(p => p.JobCandidate)
//            .HasForeignKey(d => d.BusinessEntityId);

//        });

//        builder.Entity<Shift>(b =>
//        {
//            b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Shifties", 
//                AdventureWorksAbpSharedConsts.HumanResourcesDbSchema, 
//                table => table.HasComment("Work shift lookup table.")
//            );

//            b.ConfigureByConvention(); //auto configure for the base class props

//            b.HasIndex(x => x.Name, "AK_Shift_Name").IsUnique();

//            b.HasIndex(x => new { x.StartTime, x.EndTime }, "AK_Shift_StartTime_EndTime").IsUnique();

//            b.Property(x => x.StartTime).HasComment("Shift start time.");

//            b.Property(x => x.EndTime).HasComment("Shift end time.");

//            b.Property(x => x.MealStartTime).HasComment("The start time for the allowed time for meals during the shift job.");

//            b.Property(x => x.MealEndTime).HasComment("The end time for the allowed time for meals during the shift job.");

//            b.Property(x => x.RestStartTime).HasComment("The start time for the allowed time for rest during the shift job.");

//            b.Property(x => x.RestEndTime).HasComment("The end time for the allowed time for rest during the shift job.");

//            b.Property(x => x.Name)
//            .IsRequired()
//            .HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength)
//            .HasComment("Shift description.");
//        });
//    }
//}

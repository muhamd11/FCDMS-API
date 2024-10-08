﻿// <auto-generated />
using System;
using App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240820112005_inshlizeDB")]
    partial class inshlizeDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Core.Models.ClinicModules.MedicalHistoriesModules.MedicalHistory", b =>
                {
                    b.Property<Guid>("medicalHistoryToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("activationType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("primaryFullCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("userPatientToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("medicalHistoryToken");

                    b.HasIndex("fullCode")
                        .IsUnique()
                        .HasFilter("[fullCode] IS NOT NULL");

                    b.HasIndex("userPatientToken");

                    b.ToTable("MedicalHistories", "ClinicManagement");
                });

            modelBuilder.Entity("App.Core.Models.ClinicModules.NutritionalImprovementsModules.NutritionalImprovement", b =>
                {
                    b.Property<Guid>("nutritionalImprovementToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("activationType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("patientBmr")
                        .HasPrecision(30, 18)
                        .HasColumnType("decimal(30,18)");

                    b.Property<decimal>("patientHeightInCm")
                        .HasPrecision(30, 18)
                        .HasColumnType("decimal(30,18)");

                    b.Property<decimal>("patientWeightInKg")
                        .HasPrecision(30, 18)
                        .HasColumnType("decimal(30,18)");

                    b.Property<string>("primaryFullCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("userPatientToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("nutritionalImprovementToken");

                    b.HasIndex("createdDate");

                    b.HasIndex("fullCode")
                        .IsUnique()
                        .HasFilter("[fullCode] IS NOT NULL");

                    b.HasIndex("userPatientToken");

                    b.ToTable("NutritionalImprovements", "ClinicManagement");
                });

            modelBuilder.Entity("App.Core.Models.ClinicModules.OperationsModules.Operation", b =>
                {
                    b.Property<Guid>("operationToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("activationType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("operationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("operationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("primaryFullCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("userPatientToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("operationToken");

                    b.HasIndex("fullCode")
                        .IsUnique()
                        .HasFilter("[fullCode] IS NOT NULL");

                    b.HasIndex("operationDate");

                    b.HasIndex("operationName");

                    b.HasIndex("userPatientToken");

                    b.ToTable("Operations", "ClinicManagement");
                });

            modelBuilder.Entity("App.Core.Models.ClinicModules.VisitsModules.Visit", b =>
                {
                    b.Property<Guid>("visitToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("activationType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateOnly>("expectedDateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("generalNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryFullCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("userPatientComplaining")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userPatientToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("visitDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("visitToken");

                    b.HasIndex("fullCode")
                        .IsUnique()
                        .HasFilter("[fullCode] IS NOT NULL");

                    b.HasIndex("userPatientToken");

                    b.ToTable("Visits", "ClinicManagement");
                });

            modelBuilder.Entity("App.Core.Models.SystemBase.LogActions.LogAction", b =>
                {
                    b.Property<decimal>("logActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("logActionId"));

                    b.Property<DateTimeOffset>("actionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("actionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("newActionData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("oldActionData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("logActionId");

                    b.HasIndex("userToken");

                    b.ToTable("LogActions", "SystemBase");
                });

            modelBuilder.Entity("App.Core.Models.SystemBase.Roles.SystemRole", b =>
                {
                    b.Property<Guid>("systemRoleToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("activationType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryFullCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("systemRoleCanUseDefault")
                        .HasColumnType("bit");

                    b.Property<string>("systemRoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("systemRoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("systemRoleUserTypeToken")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("systemRoleToken");

                    b.ToTable("SystemRoles", "SystemBase");

                    b.HasData(
                        new
                        {
                            systemRoleToken = new Guid("ad792233-ba34-40f0-afb6-ed4c742abb1f"),
                            createdDate = new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            fullCode = "1",
                            systemRoleCanUseDefault = true,
                            systemRoleDescription = "مضافة من قبل النظام",
                            systemRoleName = "صلاحيات مطور اساسية",
                            systemRoleUserTypeToken = 1
                        },
                        new
                        {
                            systemRoleToken = new Guid("f0a30312-33ad-4969-b904-cb2edfdaccc6"),
                            createdDate = new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            fullCode = "2",
                            systemRoleCanUseDefault = true,
                            systemRoleDescription = "مضافة من قبل النظام",
                            systemRoleName = "صلاحيات دكتور اساسية",
                            systemRoleUserTypeToken = 2
                        },
                        new
                        {
                            systemRoleToken = new Guid("1b14e306-a0cd-4334-a30d-3f4d92b5ae68"),
                            createdDate = new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            fullCode = "3",
                            systemRoleCanUseDefault = true,
                            systemRoleDescription = "مضافة من قبل النظام",
                            systemRoleName = "صلاحيات موظف اساسية",
                            systemRoleUserTypeToken = 3
                        },
                        new
                        {
                            systemRoleToken = new Guid("2b979b0d-66d7-4b2d-b048-e448c902b1fe"),
                            createdDate = new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            fullCode = "4",
                            systemRoleCanUseDefault = true,
                            systemRoleDescription = "مضافة من قبل النظام",
                            systemRoleName = "صلاحيات مريض اساسية",
                            systemRoleUserTypeToken = 4
                        });
                });

            modelBuilder.Entity("App.Core.Models.SystemBase._01._2_SystemRoleFunctions.SystemRoleFunction", b =>
                {
                    b.Property<Guid>("systemRoleFunctionToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("customizeFunctionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("functionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("functionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("functionsType")
                        .HasColumnType("int");

                    b.Property<bool>("isHavePrivilege")
                        .HasColumnType("bit");

                    b.Property<string>("moduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("systemRoleToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("systemRoleFunctionToken");

                    b.ToTable("SystemRoleFunctions", "SystemBase");
                });

            modelBuilder.Entity("App.Core.Models.Users.User", b =>
                {
                    b.Property<Guid>("userToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("activationType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primaryFullCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("systemRoleToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userLoginName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCCName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneDialCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userTypeToken")
                        .HasColumnType("int");

                    b.HasKey("userToken");

                    b.HasIndex("primaryFullCode")
                        .IsUnique()
                        .HasFilter("[primaryFullCode] IS NOT NULL");

                    b.HasIndex("systemRoleToken");

                    b.HasIndex("userTypeToken");

                    b.ToTable("Users", "Users");

                    b.HasData(
                        new
                        {
                            userToken = new Guid("ade938f3-6406-4d09-a806-ab02e28c6902"),
                            createdDate = new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            fullCode = "1",
                            primaryFullCode = "Developer_1",
                            systemRoleToken = new Guid("ad792233-ba34-40f0-afb6-ed4c742abb1f"),
                            userLoginName = "admin",
                            userName = "مدير النظام",
                            userPassword = "MDAwMA==",
                            userTypeToken = 1
                        });
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee.UserEmployee", b =>
                {
                    b.Property<Guid>("userEmployeeToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("userGender")
                        .HasColumnType("int");

                    b.Property<string>("userNationalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userNationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userEmployeeToken");

                    b.HasIndex("userToken")
                        .IsUnique()
                        .HasFilter("[userToken] IS NOT NULL");

                    b.ToTable("UserEmployees", "Users");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor.UserDoctor", b =>
                {
                    b.Property<Guid>("userDoctorToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userDoctorToken");

                    b.HasIndex("userToken")
                        .IsUnique();

                    b.ToTable("UserDoctors", "Users");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules.OtpRecord", b =>
                {
                    b.Property<Guid>("OtpToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("expireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userOtp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OtpToken");

                    b.ToTable("OtpRecords", "Users");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01_1_UserTypes.UserProfile", b =>
                {
                    b.Property<Guid>("userProfileToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("userBirthDate")
                        .HasColumnType("date");

                    b.Property<string>("userContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCC2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCC3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCC4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCCName2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCCName3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCCName4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userProfileToken");

                    b.HasIndex("userToken")
                        .IsUnique()
                        .HasFilter("[userToken] IS NOT NULL");

                    b.ToTable("UserProfiles", "Users");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData.UserPatient", b =>
                {
                    b.Property<Guid>("userPatientToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("lastPeriodDate")
                        .HasColumnType("date");

                    b.Property<int>("userPatientAge")
                        .HasColumnType("int");

                    b.Property<int>("userPatientBloodType")
                        .HasColumnType("int");

                    b.Property<int>("userPatientChildrenCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userPatientToken");

                    b.HasIndex("userToken")
                        .IsUnique()
                        .HasFilter("[userToken] IS NOT NULL");

                    b.ToTable("UserPatients", "Users");
                });

            modelBuilder.Entity("App.Core.Models.ClinicModules.MedicalHistoriesModules.MedicalHistory", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userPatientData")
                        .WithMany()
                        .HasForeignKey("userPatientToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("App.Core.Models.ClinicModules.MedicalHistoriesModules.BaseMeasurement", "patientBloodPressureMeasurement", b1 =>
                        {
                            b1.Property<Guid>("medicalHistoryToken")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("isMeasured")
                                .HasColumnType("bit");

                            b1.Property<DateOnly>("measurementDate")
                                .HasColumnType("date");

                            b1.Property<double?>("measurementValue")
                                .HasColumnType("float");

                            b1.HasKey("medicalHistoryToken");

                            b1.ToTable("MedicalHistories", "ClinicManagement");

                            b1.WithOwner()
                                .HasForeignKey("medicalHistoryToken");
                        });

                    b.OwnsOne("App.Core.Models.ClinicModules.MedicalHistoriesModules.BaseMeasurement", "patientSugarMeasurement", b1 =>
                        {
                            b1.Property<Guid>("medicalHistoryToken")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("isMeasured")
                                .HasColumnType("bit");

                            b1.Property<DateOnly>("measurementDate")
                                .HasColumnType("date");

                            b1.Property<double?>("measurementValue")
                                .HasColumnType("float");

                            b1.HasKey("medicalHistoryToken");

                            b1.ToTable("MedicalHistories", "ClinicManagement");

                            b1.WithOwner()
                                .HasForeignKey("medicalHistoryToken");
                        });

                    b.OwnsOne("App.Core.Models.ClinicModules.MedicalHistoriesModules.BaseMeasurement", "patientThyroidSensitivityMeasurement", b1 =>
                        {
                            b1.Property<Guid>("medicalHistoryToken")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("isMeasured")
                                .HasColumnType("bit");

                            b1.Property<DateOnly>("measurementDate")
                                .HasColumnType("date");

                            b1.Property<double?>("measurementValue")
                                .HasColumnType("float");

                            b1.HasKey("medicalHistoryToken");

                            b1.ToTable("MedicalHistories", "ClinicManagement");

                            b1.WithOwner()
                                .HasForeignKey("medicalHistoryToken");
                        });

                    b.Navigation("patientBloodPressureMeasurement");

                    b.Navigation("patientSugarMeasurement");

                    b.Navigation("patientThyroidSensitivityMeasurement");

                    b.Navigation("userPatientData");
                });

            modelBuilder.Entity("App.Core.Models.ClinicModules.NutritionalImprovementsModules.NutritionalImprovement", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userPatientData")
                        .WithMany()
                        .HasForeignKey("userPatientToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userPatientData");
                });

            modelBuilder.Entity("App.Core.Models.ClinicModules.OperationsModules.Operation", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userPatientData")
                        .WithMany()
                        .HasForeignKey("userPatientToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userPatientData");
                });

            modelBuilder.Entity("App.Core.Models.ClinicModules.VisitsModules.Visit", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userPatientData")
                        .WithMany()
                        .HasForeignKey("userPatientToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("App.Core.Models.ClinicModules.VisitsModules.FetalInformation", "fetalInformations", b1 =>
                        {
                            b1.Property<Guid>("visitToken")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("fetalAgeInMonths")
                                .HasPrecision(30, 18)
                                .HasColumnType("decimal(30,18)");

                            b1.Property<decimal>("fetalAgeInWeeks")
                                .HasPrecision(30, 18)
                                .HasColumnType("decimal(30,18)");

                            b1.Property<int>("fetalGender")
                                .HasColumnType("int");

                            b1.Property<decimal>("fetalHeartBeatPerMinute")
                                .HasPrecision(30, 18)
                                .HasColumnType("decimal(30,18)");

                            b1.Property<decimal>("fetalWeightInKg")
                                .HasPrecision(30, 18)
                                .HasColumnType("decimal(30,18)");

                            b1.HasKey("visitToken");

                            b1.ToTable("Visits", "ClinicManagement");

                            b1.WithOwner()
                                .HasForeignKey("visitToken");
                        });

                    b.Navigation("fetalInformations");

                    b.Navigation("userPatientData");
                });

            modelBuilder.Entity("App.Core.Models.SystemBase.LogActions.LogAction", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithMany()
                        .HasForeignKey("userToken");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.Users.User", b =>
                {
                    b.HasOne("App.Core.Models.SystemBase.Roles.SystemRole", "roleData")
                        .WithMany("usersData")
                        .HasForeignKey("systemRoleToken");

                    b.Navigation("roleData");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee.UserEmployee", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithOne("userEmployeeData")
                        .HasForeignKey("App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee.UserEmployee", "userToken");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor.UserDoctor", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithOne("userDoctorData")
                        .HasForeignKey("App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor.UserDoctor", "userToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01_1_UserTypes.UserProfile", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithOne("userProfileData")
                        .HasForeignKey("App.Core.Models.UsersModule._01_1_UserTypes.UserProfile", "userToken");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData.UserPatient", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithOne("userPatientData")
                        .HasForeignKey("App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData.UserPatient", "userToken");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.SystemBase.Roles.SystemRole", b =>
                {
                    b.Navigation("usersData");
                });

            modelBuilder.Entity("App.Core.Models.Users.User", b =>
                {
                    b.Navigation("userDoctorData");

                    b.Navigation("userEmployeeData");

                    b.Navigation("userPatientData");

                    b.Navigation("userProfileData");
                });
#pragma warning restore 612, 618
        }
    }
}

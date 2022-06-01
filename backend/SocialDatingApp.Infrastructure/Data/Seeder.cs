using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialDatingApp.Core;
using SocialDatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Infrastructure.Data
{
    public static class Seeder
    {
        public static void SeedData(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                using (var transaction = context.Database.BeginTransaction())
                {
                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(new List<User>()
                        {
                            new User
                            {
                                Id = "900ecda1-f34c-4fc0-8282-d9871f514e5f",
                                FirstName = "Geralt",
                                LastName = "Z Rivii",
                                UserName = "Geralt",
                                NormalizedUserName = "GERALT",
                                Email = "geralt.rivia@wyzima.com",
                                NormalizedEmail = "GERALT.RIVIA@WYZIMA.COM",
                                Age = 25,
                                Localization = "Kaer Morhen",
                                EmailConfirmed = false,
                                PasswordHash = "AQAAAAEAACcQAAAAEJqklDpdP+gBn9mjGhF5YbI59sm2b/nTaFqOwJUSCxTddPkHeY3p0CtE7yBZlUbtUg==", // Password = Wyzima1@
                                SecurityStamp = "QYCRUXSDCYH5GDNEHDK2CX4A22YVMZS2",
                                ConcurrencyStamp = "512b36d3-4876-48a8-8d27-a882b13c1bfd",
                                PhoneNumberConfirmed = false,
                                TwoFactorEnabled = false,
                                LockoutEnabled = false,
                                AccessFailedCount = 0
                            },
                            new User
                            {
                                Id = "1950ebbc-a093-422b-af5f-22521e88f45f",
                                FirstName = "Yennefer",
                                LastName = "Z Vengerbergu",
                                UserName = "Yennefer",
                                NormalizedUserName = "YENNEFER",
                                Email = "yennefer.vengerberg@wyzima.com",
                                NormalizedEmail = "YENNEFER.VENGERBERG@WYZIMA.COM",
                                Age = 22,
                                Localization = "Velen",
                                EmailConfirmed = false,
                                PasswordHash = "AQAAAAEAACcQAAAAEFocob1MtZCfgqScOc3p2StReFOYfCe75biZciqZYo76mXZHd5SmcGByzaGvdEthYA==", // Password = Wyzima1@
                                SecurityStamp = "2YPMWBMDJB2OVGU7HLCZBZUKUYTVMJNF",
                                ConcurrencyStamp = "8594d5c4-4160-4d49-9a42-6ce70ccf9286",
                                PhoneNumberConfirmed = false,
                                TwoFactorEnabled = false,
                                LockoutEnabled = false,
                                AccessFailedCount = 0
                            },
                            new User
                            {
                                Id = "8222f166-68df-4397-ad33-89d00f86a3f5",
                                FirstName = "Vesemir",
                                LastName = "Z Kaer Morhen",
                                UserName = "Vesemir",
                                NormalizedUserName = "VESEMIR",
                                Email = "vesemir.wiedzmin@wyzima.com",
                                NormalizedEmail = "VESEMIR.WIEDZMIN@WYZIMA.COM",
                                Age = 55,
                                Localization = "Kaer Morhen",
                                EmailConfirmed = false,
                                PasswordHash = "AQAAAAEAACcQAAAAEAna/KiSG45Ep6aAtbgDHRuClHQNrChsuH7XsMVxT4024rV7Jn1DJYQvwGF4OPhMhA==", // Password = Wyzima1@
                                SecurityStamp = "SZRAE53IC2JCJXOAV6ZDMUYZLMYRQGYP",
                                ConcurrencyStamp = "8a74aa2c-ac89-4e39-9aeb-ae6798022819",
                                PhoneNumberConfirmed = false,
                                TwoFactorEnabled = false,
                                LockoutEnabled = false,
                                AccessFailedCount = 0
                            },
                            new User
                            {
                                Id = "518ae485-ef25-4aee-bbec-f7f1bfff51b1",
                                FirstName = "Ciri",
                                LastName = "Riannon",
                                UserName = "Ciri",
                                NormalizedUserName = "CIRI",
                                Email = "ciri.riannon@wyzima.com",
                                NormalizedEmail = "CIRI.RIANNON@WYZIMA.COM",
                                Age = 18,
                                Localization = "Skellige",
                                EmailConfirmed = false,
                                PasswordHash = "AQAAAAEAACcQAAAAEAFFwvCsYD7YQxF2jl/4lH57aajPNUKJM9x8DDgrRNfzDVp+cJKocrVP7aYUmo/pHg==", // Password = Wyzima1@
                                SecurityStamp = "KB5A6ZWWP23BZ44LD5TRA7665TJM2T2M",
                                ConcurrencyStamp = "d479a8f5-c1ca-46dc-ac4c-28ae86784926",
                                PhoneNumberConfirmed = false,
                                TwoFactorEnabled = false,
                                LockoutEnabled = false,
                                AccessFailedCount = 0
                            },
                            new User
                            {
                                Id = "3826d32d-8dc1-46ae-b703-cd7653700ca3",
                                FirstName = "Jaskier",
                                LastName = "Pankratz ",
                                UserName = "Jaskier",
                                NormalizedUserName = "JASKIER",
                                Email = "jaskier.pankratz @wyzima.com",
                                NormalizedEmail = "JASKIER.PANKRATZ@WYZIMA.COM",
                                Age = 23,
                                Localization = "Biały Sad",
                                EmailConfirmed = false,
                                PasswordHash = "AQAAAAEAACcQAAAAEOUrdwmSXaJMUkYqqn+xvUiblSexCmFZtI8lFeAaOce6T7tIWzbh+fp3OCWPbu5ytw==", // Password = Wyzima1@
                                SecurityStamp = "EH7OIW2GA2OQ3JMG5F3JK2LZU6CJII5P",
                                ConcurrencyStamp = "1f23ac2a-9f91-484b-94c7-488975b3da51",
                                PhoneNumberConfirmed = false,
                                TwoFactorEnabled = false,
                                LockoutEnabled = false,
                                AccessFailedCount = 0
                            },
                            new User
                            {
                                Id = "805a3c1e-9bf8-4caf-8530-174e71d44637",
                                FirstName = "Triss",
                                LastName = "Merigold",
                                UserName = "Triss",
                                NormalizedUserName = "TRISS",
                                Email = "triss.merigold@wyzima.com",
                                NormalizedEmail = "TRISS.MERIGOLD@WYZIMA.COM",
                                Age = 24,
                                Localization = "Mirthe",
                                EmailConfirmed = false,
                                PasswordHash = "AQAAAAEAACcQAAAAEAVMKBC0kOSWtCQIEZultSQWfHHpyLUcU23bPxS4K2a+6tcoVjclCOM51LQ8pAIHeQ==", // Password = Wyzima1@
                                SecurityStamp = "5DGS7YSJVXIZCKDJNHOPDHNI6TDRWBYJ",
                                ConcurrencyStamp = "c4eadd6b-18dc-496e-84d5-6990807ed7c4",
                                PhoneNumberConfirmed = false,
                                TwoFactorEnabled = false,
                                LockoutEnabled = false,
                                AccessFailedCount = 0
                            },
                            new User
                            {
                                Id = "5a082b37-3f47-423a-ba4b-00add48d25be",
                                FirstName = "Fringilla",
                                LastName = "Vigo",
                                UserName = "Fringilla",
                                NormalizedUserName = "FRINGILLA",
                                Email = "fringilla.vigo@wyzima.com",
                                NormalizedEmail = "FRINGILLA.VIGO@WYZIMA.COM",
                                Age = 28,
                                Localization = "Nilfgaard",
                                EmailConfirmed = false,
                                PasswordHash = "AQAAAAEAACcQAAAAEMFLouO262jg4AmLR8ELwlN8cia551nade2Q9RWP93z14pH6hYAHbKZM/zdn/q8vMA==", // Password = Wyzima1@
                                SecurityStamp = "6RJ4XFMGS3FEUQ3YCEZRR4M5WMHCPUVN",
                                ConcurrencyStamp = "31c8196b-31b5-4bf7-97bb-e717017c070a",
                                PhoneNumberConfirmed = false,
                                TwoFactorEnabled = false,
                                LockoutEnabled = false,
                                AccessFailedCount = 0
                            },
                            new User
                            {
                                Id = "f4b049d4-d1ca-4bc4-bcb7-79c4f2b5f8d0",
                                FirstName = "Lambert",
                                LastName = "Krasnolud",
                                UserName = "Lambert",
                                NormalizedUserName = "LAMBERT",
                                Email = "lambert.krasnolud@wyzima.com",
                                NormalizedEmail = "LAMBERT.KRASNOLUD@WYZIMA.COM",
                                Age = 25,
                                Localization = "Lasy Wyzimy",
                                EmailConfirmed = false,
                                PasswordHash = "AQAAAAEAACcQAAAAEH/8/aSqmbzgWbgxaZfRI53FOOWaOTWywQsU8d3GbFRLoVsV5EHpXCdvhinyssM9ew==", // Password = Wyzima1@
                                SecurityStamp = "P2CIDP5J5G7YXGKRQU4XE6GBSLYCOJKB",
                                ConcurrencyStamp = "373d6f5d-286a-404e-a467-cb2c6644a2e4",
                                PhoneNumberConfirmed = false,
                                TwoFactorEnabled = false,
                                LockoutEnabled = false,
                                AccessFailedCount = 0
                            },
                        });

                        
                    }

                    context.SaveChanges();

                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Connection ON;");

                    if (!context.Set<Connection>().Any())
                    {
                        context.Set<Connection>().AddRange(
                            new Connection
                            {
                                ConnectionId = 1,
                                UserId1 = "900ecda1-f34c-4fc0-8282-d9871f514e5f",
                                UserId2 = "1950ebbc-a093-422b-af5f-22521e88f45f",
                                Confirmed = true
                            },
                            new Connection
                            {
                                ConnectionId = 2,
                                UserId1 = "900ecda1-f34c-4fc0-8282-d9871f514e5f",
                                UserId2 = "805a3c1e-9bf8-4caf-8530-174e71d44637",
                                Confirmed = true
                            },
                            new Connection
                            {
                                ConnectionId = 3,
                                UserId1 = "900ecda1-f34c-4fc0-8282-d9871f514e5f",
                                UserId2 = "518ae485-ef25-4aee-bbec-f7f1bfff51b1",
                                Confirmed = true
                            },
                            new Connection
                            {
                                ConnectionId = 4,
                                UserId1 = "1950ebbc-a093-422b-af5f-22521e88f45f",
                                UserId2 = "3826d32d-8dc1-46ae-b703-cd7653700ca3",
                                Confirmed = true
                            },
                            new Connection
                            {
                                ConnectionId = 5,
                                UserId1 = "5a082b37-3f47-423a-ba4b-00add48d25be",
                                UserId2 = "8222f166-68df-4397-ad33-89d00f86a3f5",
                                Confirmed = true
                            },
                            new Connection
                            {
                                ConnectionId = 6,
                                UserId1 = "f4b049d4-d1ca-4bc4-bcb7-79c4f2b5f8d0",
                                UserId2 = "5a082b37-3f47-423a-ba4b-00add48d25be",
                                Confirmed = true
                            },
                            new Connection
                            {
                                ConnectionId = 7,
                                UserId1 = "518ae485-ef25-4aee-bbec-f7f1bfff51b1",
                                UserId2 = "3826d32d-8dc1-46ae-b703-cd7653700ca3",
                                Confirmed = true
                            },
                            new Connection
                            {
                                ConnectionId = 8,
                                UserId1 = "805a3c1e-9bf8-4caf-8530-174e71d44637",
                                UserId2 = "f4b049d4-d1ca-4bc4-bcb7-79c4f2b5f8d0",
                                Confirmed = true
                            }
                        );
                    }

                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Connection OFF;");

                    transaction.Commit();
                }
            }
        }
    }
}

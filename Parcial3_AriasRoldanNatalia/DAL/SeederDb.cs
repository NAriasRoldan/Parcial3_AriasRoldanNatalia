using Parcial3_AriasRoldanNatalia.DAL.Entities;
using Parcial3_AriasRoldanNatalia.Enums;
using Parcial3_AriasRoldanNatalia.Helpers;
using Parcial3_AriasRoldanNatalia.Servicies;
using System;
using System.Net.Sockets;

namespace Parcial3_AriasRoldanNatalia.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;
        private readonly IUserHelper _userHelper;

        public SeederDb(DataBaseContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateServices();
            await PopulateRolesAsync();
            await PopulateUserAsync("Natalia", "Arias", "natalia_arias_admin@yopmail.com", "3002323232", "102030", UserType.Admin);
            await PopulateUserAsync("Natalia", "Roldan", "natalia_roldan_user@yopmail.com", "4005656656","405060", UserType.Client);
            await _context.SaveChangesAsync();
        }

        private async Task PopulateServices()
        {
            if (!_context.Servicies.Any())
            {
                _context.Servicies.Add(new Entities.Services
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Name = "Lavada Simple",
                    Price = 25000,
                });
                _context.Servicies.Add(new Entities.Services
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Name = "Lavada + Polishada",
                    Price = 50000,
                });
                _context.Servicies.Add(new Entities.Services
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Name = "Lavada + Aspirada de Cojinería",
                    Price = 30000,
                });
                _context.Servicies.Add(new Entities.Services
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Name = "Lavada full",
                    Price = 65000,
                });
                _context.Servicies.Add(new Entities.Services
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Name = "Lavada en seco del Motor",
                    Price = 80000,
                });
                _context.Servicies.Add(new Entities.Services
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Name = "Lavada chasis",
                    Price = 90000,
                });
            }
        }

        private async Task PopulateRolesAsync()
        {
            await _userHelper.AddRoleAsync(UserType.Admin.ToString());
            await _userHelper.AddRoleAsync(UserType.Client.ToString());
        }

        private async Task PopulateUserAsync(string firstName, string lastName, string email, string phone, string document, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }
    }
}

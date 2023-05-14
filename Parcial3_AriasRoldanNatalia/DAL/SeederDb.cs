using System;
using System.Net.Sockets;

namespace Parcial3_AriasRoldanNatalia.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;


        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateServices();
            await _context.SaveChangesAsync();
        }

        private async Task PopulateServices()
        {
            if (!_context.Servicies.Any())
             _context.Servicies.Add(new Entities.Services
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Name = "Lavada Simplre",
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
}

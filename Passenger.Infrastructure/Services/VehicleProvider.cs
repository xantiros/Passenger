﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class VehicleProvider : IVehicleProvider
    {
        private readonly IMemoryCache _cache;
        private readonly static string CacheKey = "vehicles"; //klucz do cachowania

        //źródło danych, normalnie siedzi w bazie
        private static readonly IDictionary<string, IEnumerable<VehicleDetails>> availibleVehicles =
            new Dictionary<string, IEnumerable<VehicleDetails>>
            {
                ["Audi"] = new List<VehicleDetails>
                {
                    new VehicleDetails("RS8", 2),
                    new VehicleDetails("A4", 4)
                },
                ["BMW"] = new List<VehicleDetails>
                {
                    new VehicleDetails("M3", 2),
                    new VehicleDetails("E36", 4)
                },
                ["VW"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Passat", 5),
                    new VehicleDetails("Golf", 5)
                }
            };

        public VehicleProvider(IMemoryCache cache) //cache
        {
            _cache = cache;
        }

        public async Task<IEnumerable<VehicleDto>> BrowseAsync()
        {
            var vehicles = _cache.Get<IEnumerable<VehicleDto>>(CacheKey); //pobieram pojazdy z cache
            if (vehicles == null)
            {
                vehicles = await GetAllAsync(); //jeśli w cachu nic nie ma to pobieramy pojazdy;
                _cache.Set(CacheKey, vehicles);
                //Console.WriteLine("Getting vehicles from db.");
                System.Diagnostics.Debug.WriteLine("Getting vehicles from db.");
            }
            else
            {
                //Console.WriteLine("Getting vehicles from cache.");
                System.Diagnostics.Debug.WriteLine("Getting vehicles from cache.");
            }
            return vehicles;
        }

        public async Task<VehicleDto> GetAsync(string brand, string name)
        {
            if(!availibleVehicles.ContainsKey(brand))
            {
                throw new Exception($"Vehicle brand: '{brand} is not available.'");
            }
            var vehicles = availibleVehicles[brand];
            var vehicle = vehicles.SingleOrDefault(x => x.Name == name);
            if(vehicle == null)
            {
                throw new Exception($"Vehicle: '{name}' for brand '{brand}' is not available.");
            }
            return await Task.FromResult(new VehicleDto
            {
                Brand = brand,
                Name = vehicle.Name,
                Seats = vehicle.Seats
            });
        }

        //transformuje słownik na liste do odczytu
        public async Task<IEnumerable<VehicleDto>> GetAllAsync()
            => await Task.FromResult(availibleVehicles.GroupBy(x => x.Key)
                .SelectMany(g => g.SelectMany(v => v.Value.Select(c => new VehicleDto
                {
                    Brand = v.Key,
                    Name = c.Name,
                    Seats = c.Seats
                }))));

        private class VehicleDetails
        {
            public string Name { get; }
            public int Seats { get; }

            public VehicleDetails(string name, int seats)
            {
                Name = name;
                Seats = seats;
            }
        }
    }
}

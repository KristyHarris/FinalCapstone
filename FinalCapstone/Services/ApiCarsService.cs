using FinalCapstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace FinalCapstone.Services
{
    public class ApiCarsService : ICarsService
    {
        private readonly HttpClient _client;

        public ApiCarsService(HttpClient client)
        {
            _client = client;
        }


        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<Car>>($"cars");
        }


        public async Task<Car> Get(int id)
        {
            return await _client.GetFromJsonAsync<Car>($"cars/{id}");
        }


        public async Task<IEnumerable<Car>> Search(Car car)
        {
           
            var search = await _client.GetFromJsonAsync<IEnumerable<Car>>("cars");
            var results = search.Where(c =>
                                    (c.Make == car.Make || car.Make == null) &&
                                    (c.Model == car.Model || car.Model == null) &&
                                    (c.Year == car.Year || car.Year == null) &&
                                    (c.Color == car.Color || car.Color == null)).ToList();

            return results;
        }


        public async Task Create(Car car)
        {
            await _client.PostAsJsonAsync("cars", car);
        }

        public async Task Edit(int id, Car car)
        {
            await _client.PutAsJsonAsync($"cars/{id}", car);
        }

        public async Task Delete(int id)
        {
            await _client.DeleteAsync($"cars/{id}");
        }

    }
}

using CigarShop_maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CigarShop_maui.Services
{
    public class CigarServices
    {
        HttpClient httpClient;
        public CigarServices()
        {
            this.httpClient = new HttpClient();
        }

        List<CigarModel> cigarmodel;
        public async Task<List<CigarModel>> GetCigars()
        {
            if (cigarmodel?.Count > 0)
                return cigarmodel;

            // Online
            //var response = await httpClient.GetAsync("https://www.somelinkehere/cigardata.json");
            //if (response.IsSuccessStatusCode)
            //{
            //    cigarmodel = await response.Content.ReadFromJsonAsync<List<CigarModel>>();
            //}

            // Offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("cigardata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            cigarmodel = JsonSerializer.Deserialize<List<CigarModel>>(contents);

            return cigarmodel;

        }
    }
}

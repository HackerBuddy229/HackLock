using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using HackLock.Shared.CommunicationModels.Requests;
using System.Text.Json;

namespace HackLock.Client.Services
{
    public class UnlockService
    {
        private readonly HttpClient _httpClient;

        public UnlockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Unlock(string userName, string password)
        {
            var request = new AuthenticationRequest
            {
                Password = password,
                UserName = userName
            };
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = 
                await _httpClient.PostAsync(new Uri("https://localhost:5001/api/Interaction/unlock"), content);

            return result.IsSuccessStatusCode;
        }
    }
}

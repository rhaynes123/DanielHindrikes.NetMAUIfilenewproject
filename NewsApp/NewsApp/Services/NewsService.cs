﻿using System;
using System.Text.Json;
using NewsApp.Models;

namespace NewsApp.Services
{
	public class NewsService: INewsService
	{
        private const string _dataUrl = "https://cgmobiledev8947.blob.core.windows.net/livecode/f1.json";
        private HttpClient _httpClient;
        public NewsService()
		{
            _httpClient = new HttpClient();
		}
        
        public async Task<List<NewsItem>> Get()
        {
            var response = await _httpClient.GetAsync(_dataUrl);

            if(response.StatusCode == System.Net.HttpStatusCode.NotModified)
            {

            }
            else if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<List<NewsItem>>(json, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return result;
            }

            return new List<NewsItem>();
        }
    }
}


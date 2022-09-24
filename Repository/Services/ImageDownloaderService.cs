using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    internal static class ImageDownloaderService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task Download(string url)
        {
            if(url.Length == 0) return;

            var uri = new Uri(url);
            var response = await _httpClient.GetByteArrayAsync(uri);
            var path = @"C:\Users\Diego\source\repos\HarryPotterApi\Repository\Data\Images\";
            var fileName = url.Split("/")[^1];

            using (var file = new FileStream(Path.Join(path, fileName), FileMode.Create))
            {
                foreach (var b in response)
                {
                    file.WriteByte(b);
                }
            } 
        }
    }
}

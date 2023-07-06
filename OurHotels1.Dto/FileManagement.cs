using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto
{
    public static class FileManagement
    {
        public class FileDetails
        {
            public IFormFile File { get; set; }
            public string Url { get; set; }
        }

        public static async Task<IEnumerable<FileDetails>> SaveFiles(List<FileDetails> files, string rootPath)
        {
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.File.FileName);
                string fileName = Guid.NewGuid() + "_" + extension;
                string serverFolder = Path.Combine(rootPath + $"\\wwwroot\\assets\\img\\rooms", fileName);
                var fileStream = new FileStream(serverFolder, FileMode.Create);
                await file.File.CopyToAsync(fileStream);
                await fileStream.DisposeAsync();
                file.Url = serverFolder;
            }
            return files;
        }
        public static void DeleteFiles(IEnumerable<string> urls)
        {
            foreach (string url in urls)
                File.Delete(url);
        }
    }
}
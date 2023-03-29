using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Net.Http.Headers;
using BlazorApp6.Shared;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace BlazorApp6.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public UploadController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost]
        public async Task Post([FromBody] ImageFile[] files)
        {
            foreach (var file in files)
            {
                string f = @"G:\NIS\BlazorApp6\BlazorApp6\Client\wwwroot\uploads\";
                var buf = Convert.FromBase64String(file.base64data);
                await System.IO.File.WriteAllBytesAsync(f  + file.fileName, buf);
            }
        }
    }
}

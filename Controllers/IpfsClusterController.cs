using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IPFS_Cluster_Upload_API.Data.Interfaces;

namespace IPFS_Cluster_Upload_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IpfsClusterController : ControllerBase
    {
        private readonly IIpfsClusterApiService _service;

        public IpfsClusterController(IIpfsClusterApiService service)
        {
            _service = service;
        }

        [HttpPost("single-file")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            // validate the file, scan virus, save to a file storage
            if (file.Length > 0)
            {
                var result = await _service.UploadFile(file);

                return Ok(result);
            }
            return BadRequest();
        }
    }
}
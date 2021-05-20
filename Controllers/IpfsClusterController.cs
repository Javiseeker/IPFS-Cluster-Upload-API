using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace IPFS_Cluster_Upload_API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IpfsClusterController : ControllerBase
  {
    public IpfsClusterController(IIpfsClusterRepository Parameters)
    {
        //investigar el errror en esta aprte. no me coge bien la interfaz.
    }

    [HttpPost("single-file")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
      // validate the file, scan virus, save to a file storage
        var result = await 
        return Ok();
    }
  }
}
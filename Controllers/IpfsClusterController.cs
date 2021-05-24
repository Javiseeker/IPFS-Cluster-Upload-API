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

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            // validate the file, scan virus, save to a file storage
            if (file != null && file.Length > 0)
            {
                var result = await _service.UploadFileToIpfsCluster(file);

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("DownloadFile/{cid}")]
        public async Task<IActionResult> DownloadFileAsync(string cid)
        {
            // validate the file, scan virus, save to a file storage
            if (cid != null && cid.Length > 0)
            {
                var result = await _service.DownloadFileFromIpfsClusterByCid(cid);

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("IpfsClusterPeerInformation")]
        public async Task<IActionResult> ObtainIpfsClusterPeerInformation()
        {
            var result = await _service.ObtainIpfsClusterPeerInformation();

            return Ok(result);
        }

        [HttpGet("IpfsClusterVersion")]
        public async Task<IActionResult> ObtainIpfsClusterVersion()
        {
            var result = await _service.ObtainIpfsClusterVersion();

            return Ok(result);
        }

        [HttpGet("IpfsClusterPeers")]
        public async Task<IActionResult> ObtainIpfsClusterPeers()
        {
            var result = await _service.ObtainIpfsClusterPeers();

            return Ok(result);
        }

        [HttpDelete("IpfsClusterPeers/{cid}")]
        public async Task<IActionResult> RemoveIpfsClusterPeer(string cid)
        {
            if (cid != null && cid.Length > 0)
            {
                var result = await _service.RemoveIpfsClusterPeer(cid);

                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("IpfsClusterPinsAllocations")]
        public async Task<IActionResult> ObtainIpfsClusterPinsAllocations()
        {
            var result = await _service.ObtainIpfsClusterPinsAllocations();

            return Ok(result);
        }

        [HttpGet("IpfsClusterPinsAllocations/{cid}")]
        public async Task<IActionResult> ObtainIpfsClusterPinAllocationByCid(string cid)
        {
            if (cid != null && cid.Length > 0)
            {
                var result = await _service.ObtainIpfsClusterPinAllocationByCid(cid);

                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("IpfsClusterPins")]
        public async Task<IActionResult> ObtainIpfsClusterPins()
        {
            var result = await _service.ObtainIpfsClusterPins();

            return Ok(result);
        }

        [HttpGet("IpfsClusterPins/{cid}")]
        public async Task<IActionResult> ObtainIpfsClusterPinByCid(string cid)
        {
            if (cid != null && cid.Length > 0)
            {
                var result = await _service.ObtainIpfsClusterPinByCid(cid);

                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("IpfsClusterPins/{cid}")]
        public async Task<IActionResult> PinIpfsClusterCid(string cid)
        {
            //I dont know what to send inthe body of this request. I could send it via the body... do it right.
            if (cid != null && cid.Length > 0)
            {
                var result = await _service.PinIpfsClusterCid(cid);

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("IpfsClusterPins/{cid}")]
        public async Task<IActionResult> UnpinIpfsClusterCid(string cid)
        {
            if (cid != null && cid.Length > 0)
            {
                var result = await _service.UnpinIpfsClusterCid(cid);

                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("IpfsClusterMonitorMetricsActions")]
        public async Task<IActionResult> ObtainAvailableMonitorMetrics()
        {
            var result = await _service.ObtainAvailableMonitorMetrics();

            return Ok(result);
        }

        [HttpGet("IpfsClusterMonitorMetrics/{metric}")]
        public async Task<IActionResult> ObtainMonitorMetric(string metric)
        {
            if (metric != null && metric.Length > 0)
            {
                var result = await _service.ObtainMonitorMetric(metric);

                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("IpfsClusterMonitorMetrics")]
        public async Task<IActionResult> ObtainAllMonitorMetrics()
        {
            var result = await _service.ObtainAllMonitorMetrics();

            return Ok(result);
        }


    }
}
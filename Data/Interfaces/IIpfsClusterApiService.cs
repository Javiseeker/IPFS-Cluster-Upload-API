using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using IPFS_Cluster_Upload_API.Models;

namespace IPFS_Cluster_Upload_API.Data.Interfaces
{
  public interface IIpfsClusterApiService
  {
    Task<IpfsClusterResponse> UploadFile(IFormFile file);

    Task<IpfsClusterResponse> DownloadFile(string cid);
  }
}
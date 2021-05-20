using System.Net.Http;
using System;
using IPFS_Cluster_Upload_API.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using IPFS_Cluster_Upload_API.Models;

namespace IPFS_Cluster_Upload_API.Data.Services
{
  public class IpfsClusterApiService : IIpfsClusterApiService
  {
    private static readonly HttpClient ipfsClusterClient;
    private static readonly HttpClient ipfsClient;

    static IpfsClusterApiService()
    {
      ipfsClusterClient = new HttpClient()
      {
        BaseAddress = new Uri("http://localhost:9094/")
      };

      ipfsClient = new HttpClient()
      {
        BaseAddress = new Uri("http://localhost:8080/")
      };
    }

    public async Task<IpfsClusterResponse> UploadFile(IFormFile file)
    {
      //need to check the size of the file to know which client to use to upload.
      var url = "add";
      return null;
    }

    public async Task<IpfsClusterResponse> DownloadFile(string cid)
    {
      //este metodo es el unico encargado de obtener lo que se necesite con el cid.
      return null;
    }
    public async Task<IpfsClusterResponse> PinObject(string cid){
      //una vez hago upload a solo 1 nodo, me toca pinearlo para que el cluster lo persista en todo lado. para eso es este metodo.
    }
  }
}
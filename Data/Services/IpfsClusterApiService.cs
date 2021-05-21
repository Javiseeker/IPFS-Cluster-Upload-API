using System.Net.Http;
using System.Net.Http.Headers;
using System;
using IPFS_Cluster_Upload_API.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using IPFS_Cluster_Upload_API.Models;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using IPFS_Cluster_Upload_API.Utilities;

namespace IPFS_Cluster_Upload_API.Data.Services
{
    public class IpfsClusterApiService : IIpfsClusterApiService
    {
        private readonly HttpClient _ipfsClusterClient;
        private readonly HttpClient _ipfsClient;

        public IpfsClusterApiService(IHttpClientFactory clientFactory)
        {
            _ipfsClusterClient = clientFactory.CreateClient("ipfscluster");
            _ipfsClient = clientFactory.CreateClient("ipfs");
        }

        public async Task<IpfsClusterResponse> UploadFile(IFormFile file)
        {
            //need to check the size of the file to know which client to use to upload. 5mb or more is considered large file. 
            //var url = file.Length > 5000000? "ipfs/v0/add": "add";
            var url = "add";
            var result = new IpfsClusterResponse();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                using var form = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(memoryStream.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, "file", file.FileName);
                var response = await _ipfsClusterClient.PostAsync(url, form);
                if (response.IsSuccessStatusCode)
                {
                    result = IpfsClusterUtils.ParseIpfsClusterResponse(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            return result;
            //NOTE: this upload will not work if the garbage collection is not disabled while adding files.
        }

        public async Task<IpfsClusterResponse> DownloadFile(string cid)
        {
            //este metodo es el unico encargado de obtener lo que se necesite con el cid.
            return null;
        }
        //public async Task<IpfsClusterResponse> PinObject(string cid)
        //{
        //  //una vez hago upload a solo 1 nodo, me toca pinearlo para que el cluster lo persista en todo lado. para eso es este metodo.
        //}
    }
}
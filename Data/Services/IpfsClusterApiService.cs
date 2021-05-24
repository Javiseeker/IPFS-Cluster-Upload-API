using System.Net.Http;
using System.Net.Http.Headers;
using System;
using IPFS_Cluster_Upload_API.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using IPFS_Cluster_Upload_API.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using IPFS_Cluster_Upload_API.Utilities;
using Newtonsoft.Json;

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

        public async Task<IpfsClusterResponse> UploadFileToIpfsCluster(IFormFile file)
        {
            //need to check the size of the file to know which client to use to upload. 5mb or more is considered large file. 
            //var url = file.Length > 5000000? "ipfs/v0/add": "add";
            var url = "add";
            var result = new IpfsClusterResponse();

            using (var content = new StreamContent(file.OpenReadStream()))
            using (var form = new MultipartFormDataContent())
            {
                content.Headers.ContentLength = file.Length;
                content.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);
                form.Add(content, "file", file.FileName);
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

        public async Task<IpfsClusterResponse> DownloadFileFromIpfsClusterByCid(string cid)
        {
            var url = "ipfs/" + cid;
            var result = new IpfsClusterResponse();
            var response = await _ipfsClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<IpfsClusterResponse>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }

        public async Task<IpfsClusterInformationResponse> ObtainIpfsClusterPeerInformation()
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsClusterVersionResponse> ObtainIpfsClusterVersion()
        {
            throw new NotImplementedException();
        }

        public async Task<List<IpfsClusterInformationResponse>> ObtainIpfsClusterPeers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveIpfsClusterPeer(string IpfsClusterPeerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IpfsClusterResponse>> ObtainIpfsClusterPinsAllocations()
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsClusterResponse> ObtainIpfsClusterPinAllocationByCid(string cid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IpfsClusterResponse>> ObtainIpfsClusterPins()
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsClusterResponse> ObtainIpfsClusterPinByCid(string cid)
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsClusterResponse> PinIpfsClusterCid(string cid)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UnpinIpfsClusterCid(string cid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> ObtainAvailableMonitorMetrics()
        {
            throw new NotImplementedException();
        }

        public async Task<IpfsClusterMetricsResponse> ObtainMonitorMetric(string metric)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IpfsClusterMetricsResponse>> ObtainAllMonitorMetrics()
        {
            throw new NotImplementedException();
        }

    }
}
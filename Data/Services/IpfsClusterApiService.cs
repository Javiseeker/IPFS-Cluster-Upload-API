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
                    return IpfsClusterUtils.ParseIpfsClusterResponse(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            //NOTE: this upload will not work if the garbage collection is not disabled while adding files.
        }

        public async Task<System.IO.Stream> DownloadFileFromIpfsClusterByCid(string cid)
        {
            var url = $"ipfs/{cid}";
            var response = await _ipfsClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var temp = response.Content.Headers.ContentType;
                //need to check whether its a video, phone call or text to see what to do with each.
                return await response.Content.ReadAsStreamAsync();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<IpfsClusterInformationResponse> ObtainIpfsClusterPeerInformation()
        {
            var url = "id";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IpfsClusterInformationResponse>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<IpfsClusterVersionResponse> ObtainIpfsClusterVersion()
        {
            var url = "version";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IpfsClusterVersionResponse>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<List<IpfsClusterInformationResponse>> ObtainIpfsClusterPeers()
        {
            var url = "peers";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<IpfsClusterInformationResponse>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<bool> RemoveIpfsClusterPeer(string ipfsClusterPeerId)
        {
            var url = $"peers/{ipfsClusterPeerId}";
            var response = await _ipfsClusterClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //need to check content.
                return true;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<List<IpfsClusterResponse>> ObtainIpfsClusterPinsAllocations()
        {
            var url = "allocations";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return IpfsClusterUtils.ParseListOfIpfsClusterResponse(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<IpfsClusterResponse> ObtainIpfsClusterPinAllocationByCid(string cid)
        {
            var url = $"allocations/{cid}";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return IpfsClusterUtils.ParseIpfsClusterResponse(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<List<IpfsClusterResponse>> ObtainIpfsClusterPins()
        {
            var url = "pins";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return IpfsClusterUtils.ParseListOfIpfsClusterResponse(await response.Content.ReadAsStringAsync());
                
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<IpfsClusterResponse> ObtainIpfsClusterPinByCid(string cid)
        {
            var url = $"pins/{cid}";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return IpfsClusterUtils.ParseIpfsClusterResponse(await response.Content.ReadAsStringAsync()); ;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<IpfsClusterResponse> PinIpfsClusterCid(string cid)
        {
            var url = $"pins/{cid}";
            //need to know which data to send in the post method.
            //var response = await _ipfsClusterClient.PostAsync(url);
            //if (response.IsSuccessStatusCode)
            //{
            //    return IpfsClusterUtils.ParseIpfsClusterResponse(await response.Content.ReadAsStringAsync());;
            //}
            //else
            //{
            //    throw new HttpRequestException(response.ReasonPhrase);
            //}
            return new IpfsClusterResponse();
        }

        public async Task<bool> UnpinIpfsClusterCid(string cid)
        {
            var url = $"pins/{cid}";
            var response = await _ipfsClusterClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //need to check content.
                return true;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<List<string>> ObtainAvailableMonitorMetrics()
        {
            var url = "monitor/metrics";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<List<IpfsClusterMetricsResponse>> ObtainMonitorMetric(string metric)
        {
            var url = $"monitor/metrics/{metric}";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<IpfsClusterMetricsResponse>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<List<IpfsClusterMetricsResponse>> ObtainAllMonitorMetrics()
        {
            var url = "health/alerts";
            var response = await _ipfsClusterClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<IpfsClusterMetricsResponse>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

    }
}
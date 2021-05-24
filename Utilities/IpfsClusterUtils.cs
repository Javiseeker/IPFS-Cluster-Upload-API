using IPFS_Cluster_Upload_API.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IPFS_Cluster_Upload_API.Utilities
{
    public static class IpfsClusterUtils
    {
        public static IpfsClusterResponse ParseIpfsClusterResponse(string stringResponse)
        {
            var result = new IpfsClusterResponse();

            dynamic responseJsonObject = JObject.Parse(stringResponse);
            result.Id = responseJsonObject?.cid["/"];
            result.Name = responseJsonObject?.name;
            result.Size = responseJsonObject?.size;
            if (responseJsonObject?.peer_map != null)
            {
                //need to test this part. its not using the same json library.
                //dynamic peerMapJsonObject = JsonSerializer.Deserialize<Dictionary<string, IpfsClusterPeerMap>>(responseJsonObject?.peer_map);
            }
            return result;
        }
    }
}

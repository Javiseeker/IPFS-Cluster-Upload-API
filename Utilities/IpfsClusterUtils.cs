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
        public static IpfsClusterResponse ParseIpfsClusterResponse(object objectResponse)
        {
            //meterle un try and catch aqui

            var result = new IpfsClusterResponse();
            dynamic responseJsonObject =
                objectResponse.GetType().Equals(typeof(string)) ? JObject.Parse((string)objectResponse) :
                objectResponse;

            result.Id = responseJsonObject?.cid["/"];
            result.Name = responseJsonObject?.name;
            result.Size = responseJsonObject?.size;
            result.ReplicationFactorMin = responseJsonObject?.replication_factor_min;
            result.ReplicationFactorMax = responseJsonObject?.replication_factor_max;
            result.Mode = responseJsonObject?.mode;
            result.ShardSize = responseJsonObject?.shard_size;
            result.UserAllocations = responseJsonObject?.user_allocations;
            result.ExpireAt = responseJsonObject?.expire_at;
            result.Metadata = responseJsonObject?.metadata;
            result.PinUpdate = responseJsonObject?.pin_update;
            result.Type = responseJsonObject?.type;
            result.Allocations = responseJsonObject?.allocations;
            result.MaxDepth = responseJsonObject?.max_depth;
            result.Reference = responseJsonObject?.reference;
            //if(responseJsonObject?.peer_map != null)
            //{ //this oen is being used for pins operations.
            //    result.PeerMap.Peername = responseJsonObject?.peer_map.First["peername"];
            //    result.PeerMap.Status = responseJsonObject?.peer_map["status"];
            //    result.PeerMap.Timestamp = responseJsonObject?.peer_map["timestamp"];
            //    result.PeerMap.Error = responseJsonObject?.peer_map["error"];
            //}


            return result;
        }

        public static List<IpfsClusterResponse> ParseListOfIpfsClusterResponse(string stringResponseList)
        {
            var result = new List<IpfsClusterResponse>();
            var jsonList = JsonConvert.DeserializeObject<List<JObject>>(stringResponseList);
            foreach (JObject json in jsonList)
            {
                result.Add(ParseIpfsClusterResponse(json));
            }

            return result;

        }
    }
}

#nullable enable

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Serialization;

namespace IPFS_Cluster_Upload_API.Models
{
    public class IpfsClusterResponse
    {
        public string Id { get; set; } = String.Empty;

        public string? Name { get; set; }
        
        public IpfsClusterPeerMap? PeerMap { get; set; }

        public Int32? Size { get; set; }
    }
}
#nullable enable

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Serialization;

namespace IPFS_Cluster_Upload_API.Dtos
{
    public class IpfsClusterResponse
    {
        public string Id { get; set; } = String.Empty;

        public string? Name { get; set; }

        public IpfsClusterPeerMap? PeerMap { get; set; }

        public Int32? Size { get; set; }
    }

    public class IpfsClusterPeerMap
    {
        public string? Id { get; set; }
        public string? Peername { get; set; }
        public string? Status { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? Error { get; set; }
    }
}
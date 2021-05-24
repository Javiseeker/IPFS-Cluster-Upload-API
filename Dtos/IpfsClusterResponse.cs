#nullable enable

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IPFS_Cluster_Upload_API.Dtos
{
    public class IpfsClusterBasicResponse
    {
        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;
    }
    public class IpfsClusterPinsResponse: IpfsClusterBasicResponse
    {
        public IpfsClusterPeerMap? PeerMap { get; set; }
    }

    public class IpfsClusterResponse : IpfsClusterBasicResponse
    {
        //this class will hold all possible fields FOR NOW.
        public Int32? Size { get; set; }
        public IpfsClusterPeerMap? PeerMap { get; set; }
        public Int16? ReplicationFactorMin { get; set; }
        public Int16? ReplicationFactorMax { get; set; }
        public string? Mode { get; set; }
        public Int32? ShardSize { get; set; }
        public object? UserAllocations { get; set; }  //need to verify this one
        public DateTime? ExpireAt { get; set; }
        public object? Metadata { get; set; } //need to verify this one
        public object? PinUpdate { get; set; } //need to verify this one
        public Int16? Type { get; set; }
        public JArray? Allocations { get; set; } //need to verify this one
        public Int16? MaxDepth { get; set; }
        public object? Reference { get; set; } //need to verify this one
    }
    public class IpfsClusterAllocationsResponse: IpfsClusterBasicResponse
    {
        public Int16? ReplicationFactorMin { get; set; }
        public Int16? ReplicationFactorMax { get; set; }
        public string? Mode { get; set; }
        public Int32? ShardSize { get; set; }
        public object? UserAllocations { get; set; }  //need to verify this one
        public DateTime? ExpireAt { get; set; }
        public object? Metadata { get; set; } //need to verify this one
        public object? PinUpdate { get; set; } //need to verify this one
        public Int16? Type { get; set; }
        public JArray? Allocations { get; set; } //need to verify this one
        public Int16? MaxDepth { get; set; }
        public object? Reference { get; set; } //need to verify this one
    }


    public class IpfsClusterPeerMap
    {
        //public string? Id { get; set; } Need to search how to assign this value.
        public string? Peername { get; set; }
        public string? Status { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? Error { get; set; }
    }
}
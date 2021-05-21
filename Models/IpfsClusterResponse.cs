#nullable enable

using System;

namespace IPFS_Cluster_Upload_API.Models{
  public class IpfsClusterResponse {
    
    [System.Runtime.Serialization.DataMember(Name = "/")]
    public string Cid {get;set;} = String.Empty;
    public string? Name {get;set;}
    //[System.Runtime.Serialization.DataMember(Name = "peer_map")]
    //public IpfsClusterPeerMap? PeerMap {get;set;}

    public Int32? Size {get;set;}
  }
}
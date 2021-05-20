#nullable enable

using System;
using Newtonsoft.Json;
using System.Dynamic;

namespace IPFS_Cluster_Upload_API.Models
{
  public class IpfsClusterPeerMap
  {
    public dynamic? PeerMap { get; set; }
    public string? Peername = String.Empty;
    public string? Status = String.Empty;
    public DateTime? Timestamp = null;
    public string? Error = String.Empty;

    public IpfsClusterPeerMap()
    {
      if (PeerMap != null)
      {
        PeerMap = JsonConvert.DeserializeObject<ExpandoObject>(PeerMap, new Newtonsoft.Json.Converters.ExpandoObjectConverter());
        Peername = PeerMap.peername;
        Status = PeerMap.status;
        Timestamp = PeerMap.timestamp;
        Error = PeerMap.error;
      }
    }
  }

}

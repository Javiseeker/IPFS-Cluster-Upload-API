#nullable enable

using System;
using Newtonsoft.Json;
using System.Dynamic;

namespace IPFS_Cluster_Upload_API.Models
{
  public class IpfsClusterPeerMap
  {
    public string? Id { get; set; } = String.Empty;
    public string? Peername { get; set; } = String.Empty;
    public string? Status { get; set; } = String.Empty;
    public DateTime? Timestamp { get; set; } = null;
    public string? Error { get; set; } = String.Empty;
  }

}

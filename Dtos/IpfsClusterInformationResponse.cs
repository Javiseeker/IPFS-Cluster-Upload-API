using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPFS_Cluster_Upload_API.Dtos
{
    public class IpfsClusterVersionResponse
    {
        public string Version { get; set; }
    }
    public class IpfsInformation
    {
        public string Id { get; set; }
        public List<string> Addresses { get; set; }
        public string Error { get; set; }
    }
    public class IpfsClusterInformationResponse: IpfsClusterVersionResponse
    {
        public string Id { get; set; }
        public List<string> Addresses { get; set; }
        public List<string> ClusterPeers { get; set; }
        public List<string> ClusterPeersAddresses { get; set; }
        public string Commit { get; set; }
        public string RpcProtocolVersion { get; set; }
        public string Error { get; set; }
        public IpfsInformation Ipfs { get; set; }
        public string PeerName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPFS_Cluster_Upload_API.Dtos
{
    public class IpfsClusterMetricsResponse
    {
        public string Name { get; set; }
        public string Peer { get; set; }
        public string Value { get; set; }
        public long Expire { get; set; }
        public bool Valid { get; set; }
        public long ReceivedAt { get; set; }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using IPFS_Cluster_Upload_API.Dtos;

namespace IPFS_Cluster_Upload_API.Data.Interfaces
{
    public interface IIpfsClusterApiService
    {

        //Contains all actions available to manipulate an IPFS Cluster and it's IPFS functions.
        //This is all working on latest release version -> IPFSCLUSTER: 0.13.3 IPFS: 0.8.0

        //IPFS Cluster Information and operations.
        Task<IpfsClusterInformationResponse> ObtainIpfsClusterPeerInformation();
        Task<IpfsClusterVersionResponse> ObtainIpfsClusterVersion();
        Task<List<IpfsClusterInformationResponse>> ObtainIpfsClusterPeers();

        Task<bool> RemoveIpfsClusterPeer(string ipfsClusterPeerId);

        //IPFS Cluster content management. I still need to go through the ones available from cluster. Like DownloadFileFromIpfsClusterByCid

        Task<IpfsClusterResponse> UploadFileToIpfsCluster(IFormFile file);
        Task<System.IO.Stream> DownloadFileFromIpfsClusterByCid(string cid);
        Task<List<IpfsClusterResponse>> ObtainIpfsClusterPinsAllocations();
        Task<IpfsClusterResponse> ObtainIpfsClusterPinAllocationByCid(string cid);
        Task<List<IpfsClusterResponse>> ObtainIpfsClusterPins();
        //Task<IpfsClusterResponse> SyncIpfsClusterLocalStatusFromIPFS();
        Task<IpfsClusterResponse> ObtainIpfsClusterPinByCid(string cid);
        Task<IpfsClusterResponse> PinIpfsClusterCid(string cid);
        Task<bool> UnpinIpfsClusterCid(string cid);
        //Task<IpfsClusterResponse> PinIpfsClusterCidUsingIPFSPath(string IpfsPath);
        //Task<IpfsClusterResponse> SyncCid(string cid);
        //Task<IpfsClusterResponse> RecoverCid(string cid);
        //Task<IpfsClusterResponse> RecoverAllPinsInIpfsCluster();

        //Monitor and health metrics of the IPFS Cluster.
        Task<List<string>> ObtainAvailableMonitorMetrics();
        Task<List<IpfsClusterMetricsResponse>> ObtainMonitorMetric(string metric);
        Task<List<IpfsClusterMetricsResponse>> ObtainAllMonitorMetrics();
        //Task<IpfsClusterGraphMetricsResponse> ObtainMonitorMetricsGraph();
        //Task<IpfsClusterMetricsResponse> PerformGcToIpfsNodes(); This one might be GarbageCollection. Cleaning trash?
        
    }
}
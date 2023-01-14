using System;
using ShapesXr.Import.Core;
using UnityEditor;
using UnityEngine;

namespace ShapesXr
{
    public static class ResourceDownloader
    {
        private const float MinDownloadSpeedMbps = 1;

#if SHAPES_XR_DEV
        private const string ServerURL = "https://api-dev.shapes.app/";
#else
        private const string ServerURL = "https://api.shapes.app/";
#endif

        public static void DownloadAllResources(ISpaceDescriptor spaceDescriptor)
        {
            foreach (var kvp in spaceDescriptor.ObjectPresets)
            {
                if (!(kvp.Value is ResourcePreset preset))
                {
                    continue;
                }

                var objectId = kvp.Key;
                var resourceId = spaceDescriptor.PropertyHub.GetValue<Guid>(objectId, Properties.RESOURCE_GUID);

                if (spaceDescriptor.Resources.ContainsKey(resourceId))
                {
                    continue;
                }
                
                var resourceResponse = ResourceDownloaderHelper.DownloadResource(ServerURL, spaceDescriptor, resourceId, preset.ResourceType);

                if (resourceResponse == null)
                {
                    Debug.LogWarning($"Resource with id {resourceId} not found on server. Skipping object import");
                    continue;
                }
                
                var resource = new Resource(preset.ResourceType, resourceId, resourceResponse);
                spaceDescriptor.Resources.Add(resourceId, resource);
            }

            if (spaceDescriptor.Resources.IsNullOrEmpty())
            {
                return;
            }
            
            AssetDatabase.Refresh();

            foreach (var kvp in spaceDescriptor.Resources)
            {
                var resource = kvp.Value;
                var postProcessor = ResourcePostProcessorFactory.GetPostProcessor(spaceDescriptor, resource);
                postProcessor.PostProcess();
            }
        }
    }
}
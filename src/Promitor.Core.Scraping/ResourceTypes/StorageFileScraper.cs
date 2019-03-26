using System;
using System.Threading.Tasks;
using GuardNet;
using Microsoft.Azure.Management.Monitor.Fluent.Models;
using Microsoft.Extensions.Logging;
using Promitor.Core.Scraping.Configuration.Model;
using Promitor.Core.Scraping.Configuration.Model.Metrics.ResourceTypes;
using Promitor.Core.Telemetry.Interfaces;
using Promitor.Integrations.AzureMonitor;
using Promitor.Integrations.AzureStorage;

namespace Promitor.Core.Scraping.ResourceTypes
{
    public class StorageFileScraper : Scraper<StorageFileMetricDefinition>
    {
        private const string ResourceUriTemplate = "subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Storage/storageAccounts/{2}/fileServices/default";

        public StorageFileScraper(AzureMetadata azureMetadata, MetricDefaults metricDefaults, AzureMonitorClient azureMonitorClient, ILogger logger, IExceptionTracker exceptionTracker)
            : base(azureMetadata, metricDefaults, azureMonitorClient, logger, exceptionTracker)
        {
        }

        protected override async Task<double> ScrapeResourceAsync(StorageFileMetricDefinition metricDefinition, AggregationType aggregationType, TimeSpan aggregationInterval)
        {
            Guard.NotNull(metricDefinition, nameof(metricDefinition));
            Guard.NotNull(metricDefinition.AzureMetricConfiguration, nameof(metricDefinition.AzureMetricConfiguration));
            Guard.NotNullOrEmpty(metricDefinition.AzureMetricConfiguration.MetricName, nameof(metricDefinition.AzureMetricConfiguration.MetricName));

            var resourceUri = string.Format(ResourceUriTemplate, AzureMetadata.SubscriptionId, AzureMetadata.ResourceGroupName, metricDefinition.AccountName);

            //var filter = $"EntityName eq '{metricDefinition.FileShareName}'";
            var filter = "";
            var metricName = metricDefinition.AzureMetricConfiguration.MetricName;
            var foundMetricValue = await AzureMonitorClient.QueryMetricAsync(metricName, aggregationType, aggregationInterval, resourceUri, filter);

            return foundMetricValue;
        }
    }
}
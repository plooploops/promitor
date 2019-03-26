using System;
using System.Collections.Generic;
using System.Linq;
using Promitor.Core.Scraping.Configuration.Model.Metrics.ResourceTypes;
using Promitor.Integrations.AzureStorage;
using Promitor.Scraper.Host.Validation.MetricDefinitions.Interfaces;

namespace Promitor.Scraper.Host.Validation.MetricDefinitions.ResourceTypes
{
    public class StorageFileMetricValidator : IMetricValidator<StorageFileMetricDefinition>
    {
        // supported metrics
        private readonly ISet<string> _validMetricNames = new HashSet<string>(new[]
        {
            AzureStorageConstants.File.Metrics.FileCapacity,
            AzureStorageConstants.File.Metrics.FileCount,
            AzureStorageConstants.File.Metrics.FileShareCount,
        });

        public List<string> Validate(StorageFileMetricDefinition metricDefinition)
        {
            var errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(metricDefinition.AccountName))
            {
                errorMessages.Add(item: "No Azure Storage Account Name is configured");
            }

            if (string.IsNullOrWhiteSpace(metricDefinition.FileShareName))
            {
                errorMessages.Add(item: "No Azure Storage File Share Name is configured");
            }

            if (string.IsNullOrWhiteSpace(metricDefinition.SasToken))
            {
                errorMessages.Add(item: "No Azure Storage SAS Token is configured");
            }

            if (!_validMetricNames.Any(metricName => metricName.Equals(metricDefinition.AzureMetricConfiguration.MetricName, StringComparison.InvariantCultureIgnoreCase)))
            {
                errorMessages.Add($"Invalid metric name {metricDefinition.AzureMetricConfiguration.MetricName}");
            }

            return errorMessages;
        }
    }
}
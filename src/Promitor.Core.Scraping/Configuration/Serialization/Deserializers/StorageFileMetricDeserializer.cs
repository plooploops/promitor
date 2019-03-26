using Promitor.Core.Scraping.Configuration.Model.Metrics;
using Promitor.Core.Scraping.Configuration.Model.Metrics.ResourceTypes;
using YamlDotNet.RepresentationModel;

namespace Promitor.Core.Scraping.Configuration.Serialization.Deserializers
{
    internal class StorageFileMetricDeserializer : GenericAzureMetricDeserializer
    {
        /// <summary>Deserializes the specified Storage File metric node from the YAML configuration file.</summary>
        /// <param name="metricNode">The metric node containing 'accountName', 'queueName', and 'sasToken' parameters pointing to an instance of a Storage queue</param>
        /// <returns>A new <see cref="MetricDefinition"/> object (strongly typed as a <see cref="StorageFileMetricDefinition"/>) </returns>
        internal override MetricDefinition Deserialize(YamlMappingNode metricNode)
        {
            var metricDefinition = base.DeserializeMetricDefinition<StorageFileMetricDefinition>(metricNode);
            var accountName = metricNode.Children[new YamlScalarNode("accountName")];
            var fileShareName = metricNode.Children[new YamlScalarNode("fileShareName")];
            var sasToken = metricNode.Children[new YamlScalarNode("sasToken")];

            metricDefinition.AccountName = accountName?.ToString();
            metricDefinition.FileShareName = fileShareName?.ToString();
            metricDefinition.SasToken = sasToken?.ToString();

            return metricDefinition;
        }
    }
}

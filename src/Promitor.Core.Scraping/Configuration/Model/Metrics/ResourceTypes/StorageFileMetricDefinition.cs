namespace Promitor.Core.Scraping.Configuration.Model.Metrics.ResourceTypes
{
    public class StorageFileMetricDefinition: MetricDefinition
    {
        public string AccountName { get; set; }
        public string FileShareName { get; set; }
        //public string Namespace { get; set; }
        public string SasToken { get; set; }
        public override ResourceType ResourceType { get; } = ResourceType.StorageFile;
    }
}
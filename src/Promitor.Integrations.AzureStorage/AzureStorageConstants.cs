namespace Promitor.Integrations.AzureStorage
{
    public static class AzureStorageConstants
    {
        public static class Queues
        {
            public static class Metrics
            {
                public const string MessageCount = "messagecount";
                public const string TimeSpentInQueue = "timespentinqueue";
            }
        }

        public static class File
        {
            /// <summary>
            /// https://docs.microsoft.com/en-us/azure/azure-monitor/platform/metrics-supported#microsoftstoragestorageaccountsfileservices
            /// </summary>
            public static class Metrics
            {
                public const string FileCapacity = "fileCapacity";
                public const string FileCount = "fileCount";
                public const string FileShareCount = "fileShareCount";
            }
        }
    }
}
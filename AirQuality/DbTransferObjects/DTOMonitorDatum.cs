namespace AirQuality.DbTransferObjects
{
    public class DTOMonitorDatum
    {
        public string MacId { get; set; } = null!;

        public ulong MeasurementId { get; set; }

        public short MeasurementTypeId { get; set; }

        public double MeasurementValue { get; set; }

        public DateTime Timestamp { get; set; }
    }
}

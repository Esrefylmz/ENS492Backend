namespace AirQuality.DbTransferObjects
{
    public class DTOMeasurementType
    {
        public short MeasurementTypeId { get; set; }

        public string MeasurementType1 { get; set; } = null!;

        public string Unit { get; set; } = null!;

        public string MeasurementKey { get; set; } = null!;

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public int NormalMin { get; set; }

        public int NormalMax { get; set; }

        public byte DisplayOrder { get; set; }
    }
}

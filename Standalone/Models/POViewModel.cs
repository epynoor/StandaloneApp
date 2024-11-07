namespace Standalone.Models
{
    public class POViewModel
    {
        public string? PONo { get; set; }
        public DateTime? PODate { get; set; }
        public string? SupplierName { get; set; }
        public decimal? Charges { get; set; }
        public string? CountryOfOrigin { get; set; }
        public int? ShippingTolerance { get; set; }
        public string? PortofLoading { get; set; }
        public string? PortofDischarge { get; set; }
        public string? ShipmentMode { get; set; }
    }
}

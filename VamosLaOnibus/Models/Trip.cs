using System;

namespace VamosLaOnibus.Models
{
    /// <summary>
    /// Model class
    /// </summary>
    public class Trip
    {
        public string objectId { get; set; }
        public Company Company { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DepartureArrival DepartureDate { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public double Price { get; set; }
        public string BusClass { get; set; }
        public DepartureArrival ArrivalDate { get; set; }
    }
}

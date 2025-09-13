using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entites
{
    public  class Car
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public Brand? Brand { get; set; }
        public string? CarModel { get; set; }
        public string? CarCoverImageUrl { get; set; }
        public string? CarBigImageUrl { get; set; }
        public int CarKilometer { get; set; }
        public string? CarTransmission { get; set; }
        public byte CarSeats { get; set; }
        public byte CarLuggage { get; set; }
        public string? CarFuel { get; set; }

        public List<CarFeature>? CarFeatures { get; set; }

        public List<CarDescription>? CarDescriptions { get; set; }
        public List<CarPricing>? CarPricings { get; set; }

    }
}

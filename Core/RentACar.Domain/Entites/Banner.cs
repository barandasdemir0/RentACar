﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entites
{
    public  class Banner
    {
        public int BannerID { get; set; }
        public string? BannerTitle { get; set; }
        public string? BannerDescription { get; set; }
        public string? BannerVideoDescription { get; set; }
        public string? BannerVideoUrl { get; set; }
        public string? BannerImageUrl { get; set; }
    }
}

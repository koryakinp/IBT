using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBT.Models
{
    public class Abu
    {
        public int Model { get; set; }
        public int Capacity { get; set; }
        public Size Size { get; set; }
        public string DefaultPower { get; set; }
        public string FanPower { get; set; }
        public string Humidity { get; set; }
        public string Air { get; set; }
        public string Bio { get; set; }
        public int Load { get; set; }
        public string PowerConsumption1 { get; set; }
        public string PowerConsumption2 { get; set; }
        public string PowerConsumption3 { get; set; }
        public int WaterConsumprion1 { get; set; }
        public int WaterConsumption2 { get; set; }
        public int VentilatorEngine { get; set; }
        public int VentilatorRPM { get; set; }
        public string Ventilator { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Size
    {
        public readonly int Width;
        public readonly int Height;
        public readonly int Length;

        public Size(int l, int w, int h)
        {
            Width = w;
            Height = h;
            Length = l;
        }
    }
}

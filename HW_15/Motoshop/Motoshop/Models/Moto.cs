using Motoshop.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Motoshop.Models
{
    public class Moto
    {
        [GuidCustom]
        public Guid Id { get; set; }
        public int Odometer { get; set; }
        public string Model { get; set; }
        public string ImagePreview { get; set; }
    }
}

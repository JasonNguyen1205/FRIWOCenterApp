using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FRIWOCenter.Shared.Models
{
   
    public class UnitDTO
    {
  
        public Guid ID { get; set; } = new Guid();
        public bool IsTested { get; set; }
        public bool Result { get; set; }
        public string Data { get; set; }

    }

}

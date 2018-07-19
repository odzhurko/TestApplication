using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestApp.Library.DataBase
{
    public class Fabric
    {
        [Required]
        public int FabricId { get; set; }
        [Required]
        public string FabricCode{ get; set; }
        [Required]
        public string FabricName { get; set; }

        [JsonIgnore]
        public List<Identifier> Identifiers { get; set; }
    }
}
    
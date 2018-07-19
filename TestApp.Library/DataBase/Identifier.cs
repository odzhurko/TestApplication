using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestApp.Library.DataBase
{
    public class Identifier
    {
        [Required]
        public int IdentifierId { get; set; }
        [Required]
        public int IdentifierNumber { get; set; }
        [Required]
        public DateTime CreateDateTime { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int FabricId { get; set; }
        public Fabric Fabric{ get; set; }
    }
}

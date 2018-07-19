using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Library.DataBase
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryCode { get; set; }
        [Required]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public List<Identifier> Identifiers { get; set; }
    }
}

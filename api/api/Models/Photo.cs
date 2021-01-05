using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public int publicId { get; set; }
        public string url { get; set; }
        public bool isMain { get; set; }
    }
}

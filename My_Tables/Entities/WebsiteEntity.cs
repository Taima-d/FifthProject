using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
    public class WebsiteEntity
    {
        [Key]
        public int WebsiteEntityId { get; set; }
        public string Name { get; set; }
        public byte[] WebsiteImage { get; set; }
    }
}

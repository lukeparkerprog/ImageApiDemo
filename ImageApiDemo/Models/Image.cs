using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageApiDemo.Models
{
    public class Image
    {
		public int ImageId { get; set; }
		public byte[] Data { get; set; }
		public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}

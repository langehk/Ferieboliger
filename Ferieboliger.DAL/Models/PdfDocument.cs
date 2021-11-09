using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.DAL.Models
{
    public class PdfDocument
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }


    public class PdfFileInformation
    {
        public byte[] bytes { get; set; }
        public string Name { get; set; }
    }
}

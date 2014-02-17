using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDBComparer
{
    /// <summary>
    /// Represent MS Acces table info
    /// </summary>
    class MDBTable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MDBTableColumn> Rows { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDBComparer
{

    /// <summary>
    /// Contains MS Access data types
    /// </summary>
    public enum ValueType
    {
        Undefined,
        Int,
        Currency,
        DateTime,
        Boolean,
        OLEobject,
        String
    }
        
    /// <summary>
    /// Represents Access data column general information
    /// </summary>
    class MDBTableColumn
    {
        public string Table {get; set;}
        public string Name {get; set; }
        public ValueType Type {get; set; }
        public bool Nullable {get; set; }
        public string Default {get; set; }

        /// <summary>
        /// Converts column to its string representation
        /// </summary>
        /// <returns>Formatted column data</returns>
        public override string ToString()
        { 
            StringBuilder column = new StringBuilder();
                        
            string type = Type == ValueType.Undefined ? String.Empty : Type.ToString();

            column.Append((Table??String.Empty).PadRight(30), 0, 29);
            column.Append((Name??String.Empty).PadRight(30), 0, 29);
            column.Append(type.PadRight(20), 0, 19);
            column.Append((Default??String.Empty).PadRight(15), 0, 14);

            return column.ToString();
        }

        /// <summary>
        /// Compares two MDB columns
        /// </summary>
        /// <param name="a">MDBTableColumn instance</param>
        /// <param name="b">MDBTableColumn instance</param>
        /// <returns></returns>
        public static bool operator ==(MDBTableColumn a, MDBTableColumn b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            if (a.ToString().Equals(b.ToString()))
            {
                return true;
            }
            else return false;
        }

        public static bool operator !=(MDBTableColumn a, MDBTableColumn b)
        {
            return !(a == b);
        }
    }
}

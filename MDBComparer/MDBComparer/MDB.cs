using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDBComparer
{
    /// <summary>
    /// Represents database info
    /// </summary>
    class MDB
    {
        public string DataBaseName { get; set; }
        public string FilePath { get; set; }
        public List<MDBTable> Tables {get; set;}
        public bool DataLoaded = false;

        #region constructors
        public MDB()
        {
        }

        public MDB(string filePath, string DBname)
        {
            DataBaseName = DBname;
            FilePath = filePath;
            Load();
        }

        #endregion

        /// <summary>
        /// Loads MS Access file, don't forget initialize FilePath property
        /// </summary>
        public void Load()
        { 
            DataTable userTables = null;
            try
            {
                // Microsoft Access provider factory
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");


                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath;    

                    connection.Open();

                    // get only user tables, not system tables
                    userTables = connection.GetSchema("Tables", new[] { null, null, null, "Table" });

                    //get table names and descriptions from schema
                    var tables = from rows in userTables.AsEnumerable()
                                 select new { Table = rows.Field<string>("TABLE_NAME"),
                                              Description = rows.Field<string>("DESCRIPTION")
                                 };
                    //filling MDBtable list
                    Tables = new List<MDBTable>();
                    foreach (var table in tables.ToList())
                    {
                        Tables.Add(new MDBTable() { Name = table.Table, 
                                                    Description = table.Description??String.Empty
                                                                                                   });
                    }
    
                    //filling row list in each table
                    foreach (var table in Tables)
                    {   
                        //get columns info for current table
                        var tableSchema = connection.GetSchema("Columns", new[] { null, null, table.Name, null });
                                               
                        var columns = from rows in tableSchema.AsEnumerable()
                                      orderby rows.Field<Int64>("ORDINAL_POSITION") descending
                                      select new
                                      {
                                          Table = rows.Field<string>("TABLE_NAME"),
                                          Name = rows.Field<string>("COLUMN_NAME"),
                                          Type = rows.Field<int>("DATA_TYPE"),
                                          Nullable = rows.Field<bool>("IS_NULLABLE") 
                                      };

                        table.Rows = new List<MDBTableColumn>();
                        //fill column info
                        foreach (var col in columns.ToList())
                        {
                            ValueType type = ValueType.Undefined;

                            //get column value type
                            switch (col.Type)
                            {
                                case 3:
                                    type = ValueType.Int;
                                    break;
                                case 6:
                                    type = ValueType.Currency;
                                    break;
                                case 7:
                                    type = ValueType.DateTime;
                                    break;
                                case 11:
                                    type = ValueType.Boolean;
                                    break;
                                case 128:
                                    type = ValueType.OLEobject;
                                    break;
                                case 130:
                                    type = ValueType.String;
                                    break;
                            }

                            table.Rows.Add(new MDBTableColumn() { Table = col.Table, Name = col.Name, Type = type, Nullable = col.Nullable });                            
                        }
                    }                    
                }
                DataLoaded = true;
            }
            catch (Exception err)
            {
                DataLoaded = false;
            }
        }
    }
}

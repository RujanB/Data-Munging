using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataMunging
{
    public class DataReader
    {
        public DataTable GetData(string filePath)
        {
            DataSet dataSet = new DataSet();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
              
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream, new ExcelReaderConfiguration() { AutodetectSeparators = new char[] { ' '} }))
                {
                   
                    dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                                                       
                        }
                    });
                }
            }
            return dataSet.Tables[0];
        }
    }
}

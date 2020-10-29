using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ManuAndOrigin_BUS: CommonBUS
    {
        public void InsertManu(string name)
        {
            string sql = string.Format("INSERT INTO Manufacturer(ManufacturerID, ManufacturerName) VALUES (newid(), N'{0}')", name);
            new DataAccess().ExecuteNonQuery(sql);
        }

        public void InsertOrigin(string name)
        {
            string sql = string.Format("INSERT INTO Origin(OriginID, OriginName) VALUES (newid(), N'{0}')", name);
            new DataAccess().ExecuteNonQuery(sql);
        }
    }
}

using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BUS
{
    public class Contact_BUS : CommonBUS
    {
        DataAccess da = new DataAccess();
        public static List<Contact> getAllContact()
        {
            DataAccess da = new DataAccess();
            return da.GetEntities<Contact>();
        }
        public void UpdateContact(string ten, string diachi, string diachikho, string hotline, string email, string website)
        {

            string sql = "update Contact set ContactName=N'" + ten + "',Addressh=N'" + diachi + "',WarehouseAddress=N'" + diachikho + "',Hotline=N'" + hotline + "',Email='" + email + "',Website=N'" + website + "' where id=1";
            da.ExecuteNonQuery(sql);
        }

    }
}

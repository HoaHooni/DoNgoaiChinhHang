using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CommonBUS
    {
        public static T GetEntityByID<T>(Guid id){
            List<T> lst = new DataAccess().GetEntities<T>();
            T entity = Activator.CreateInstance<T>();
            string entityName = entity.GetType().Name;
            string keyName = string.Empty;
            //
            Type keyType = new KeyAttribute().GetType();
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                if (prop.GetCustomAttributes(keyType, false).Length > 0)
                {
                    keyName = prop.Name;
                    break;
                }
            }
            //
            if (keyName.Equals(string.Empty))
            {
                keyName = entityName + "ID";
            }
            foreach(T item in lst)
            {
                if (item.GetType().GetProperty(keyName).GetValue(item).Equals(id))
                {
                    return item;
                }
            }
            return entity;
        }

        public static List<T> GetListEntityByFieldID<T>(string fieldName, Guid id)
        {
            T entity = Activator.CreateInstance<T>();
            string entityName = entity.GetType().Name;
            string sql = string.Format("SELECT * FROM [dbo].[{0}] WHERE {1} = '{2}'", entityName, fieldName, id);
            return new DataAccess().GetEntitiesBySql<T>(sql);
        }

        public static List<Manufacturer> GetAllManufacturer()
        {
            return new DataAccess().GetEntities<Manufacturer>();
        }

        public static List<Origin> GetAllOrigin()
        {
            return new DataAccess().GetEntities<Origin>();
        }

        public static string GetManufacturerName(Guid manuID, List<DTO.Manufacturer> lstManu)
        {
            foreach (Manufacturer item in lstManu)
            {
                if (item.ManufacturerID.Equals(manuID))
                {
                    return item.ManufacturerName;
                }
            }
            return null;
        }

        public static string GetOriginName(Guid oriID, List<DTO.Origin> lstOrigin)
        {
            foreach (Origin item in lstOrigin)
            {
                if (item.OriginID.Equals(oriID))
                {
                    return item.OriginName;
                }
            }
            return null;
        }



    }
}

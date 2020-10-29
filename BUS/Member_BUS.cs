using Common;
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
    public class Member_BUS : CommonBUS
    {
        public DataAccess da = new DataAccess();
        public bool login(string accName, string pw)
        {
            bool isValid = false;
            List<Member> members = new DataAccess().GetEntities<Member>();
            foreach (Member item in members)
            {
                if (item.MemberName.Trim().ToLower().Equals(accName.ToLower()) && item.Password.Trim().Equals(pw) && item.MemberType == MemberType.Admin)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        public DataTable ShowMember(bool isAdmin)
        {
            string sql = "select MemberID, MemberName, case when MemberType = 0 then N'Người dùng' else N'Quản trị' end as MemberType, Phone, Email, Password FROM Member";

            if (!isAdmin)
            {
                sql = "select MemberID, MemberName, case when MemberType = 0 then N'Người dùng' else N'Quản trị' end as MemberType, Phone, Email, N'******' as Password FROM Member";
            }

            DataTable dt = new DataTable();
            dt = da.GetDataTable(sql);
            return dt;
        }

        public void InsertMember(string ten, string phone, string email, string pass, int type)
        {

            string sql = "Insert into Member values(newid(),N'" + phone + "','" + email + "','" + pass + "'," + type + ",N'" + ten + "')";
            da.ExecuteNonQuery(sql);
        }

        public void deleteMember(string ma)

        {
            string sql = "delete Member where MemberID='" + ma + "'";
            da.ExecuteNonQuery(sql);


        }
        public DataTable searchMember(int tk, bool isAdmin)
        {
            DataAccess da = new DataAccess();
            string sql = "select MemberID, MemberName, case when MemberType = 0 then N'Người dùng' else N'Quản trị' end as MemberType, Phone, Email, Password FROM Member where MemberType=" + tk;

            if (!isAdmin)
            {
                sql = "select MemberID, MemberName, case when MemberType = 0 then N'Người dùng' else N'Quản trị' end as MemberType, Phone, Email, N'******' as Password FROM Member where MemberType="+tk;
            }

            DataTable dt = da.GetDataTable(sql);
            return dt;
        }
        public void updateMember(Guid ma, string ten, string phone, string email, string pass, int type)
        {
            string sql = "update Member set MemberName=N'" + ten + "',Phone=N'" + phone + "',Email=N'" + email + "',Password=N'" + pass + "',MemberType=" + type + " where MemberID='" + ma + "'";
            da.ExecuteNonQuery(sql);
        }

        public bool IsDuplicateUserName(string name)
        {
            List<Member> members = new DataAccess().GetEntities<Member>();
            foreach(Member member in members)
            {
                if (member.MemberName.Trim().ToLower().Equals(name.Trim().ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDuplicateUserName(string oldName, string newName)
        {
            oldName = oldName.Trim().ToLower();
            newName = newName.Trim().ToLower();
            List<Member> members = new DataAccess().GetEntities<Member>();
            foreach (Member member in members)
            {
                if (member.MemberName.Trim().ToLower().Equals(newName) && !member.MemberName.Trim().ToLower().Equals(oldName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

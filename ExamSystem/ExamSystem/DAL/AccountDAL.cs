using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        /// <summary>
        /// 获取单科目成绩
        /// </summary>
        /// <param name="StudentID">学生id</param>
        /// <param name="SubjectID">科目id</param>
        /// <returns></returns>
        public AccountEntity StudentFraction(string StudentID, string SubjectID)
        {
            string sql = "select * from Account where uid=@StudentID and sid=@SubjectID";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("StudentID", StudentID);
            DBHelper.SetParameter("SubjectID", SubjectID);
            DataTable dt = DBHelper.ExecQuery();
            if(dt.Rows.Count==0)
                return null;
            AccountEntity accountEntity = new AccountEntity();
            accountEntity.uid = dt.Rows[0]["uid"].ToString();
            accountEntity.sid = int.Parse(dt.Rows[0]["sid"].ToString());
            accountEntity.Fraction = int.Parse(dt.Rows[0]["Fraction"].ToString());
            accountEntity.finishTime = (DateTime?)dt.Rows[0]["finishTime"];
            return accountEntity;       
        }

        /// <summary>
        /// 删除对应科目成绩
        /// </summary>
        /// <param name="StudentID">学生id</param>
        /// <param name="SubjectID">科目id</param>
        /// <returns></returns>
        public int DeleteStudentFraction(string StudentID, int SubjectID)
        {
            string sql = "delete Account where uid=@uid and sid=@sid";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("uid", StudentID);
            DBHelper.SetParameter("sid", SubjectID);
            return DBHelper.ExecNonQuery();
        }

        /// <summary>
        /// 获取学生各科目成绩
        /// </summary>
        /// <param name="uid">学生ID</param>
        /// <returns></returns>
        public List<AccountEntity> StudentAccount(string uid)
        {
            string sql = "select * from Account where uid=@uid";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("uid", uid);
            DataTable dt = DBHelper.ExecQuery();
            if (dt.Rows.Count == 0)
                return null;
            List<AccountEntity> accountList = new List<AccountEntity>();
            foreach (DataRow item in dt.Rows)
            {
                AccountEntity accountEntity = new AccountEntity();
                accountEntity.uid = item["uid"].ToString();
                accountEntity.sid = int.Parse(item["sid"].ToString());
                accountEntity.Fraction = int.Parse(item["sid"].ToString());
                accountEntity.finishTime = (DateTime?)item["uid"];
                accountList.Add(accountEntity);
            }
            return accountList;
        }
        
        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="entity">成绩对象</param>
        /// <returns></returns>
        public int StudentAccountADD(AccountEntity entity)
        {
            string sql = "insert Account values(@uid,@sid,@Fraction,@finishTime)";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("uid", entity.uid);
            DBHelper.SetParameter("sid", entity.sid);
            DBHelper.SetParameter("Fraction", entity.Fraction);
            DBHelper.SetParameter("finishTime", entity.finishTime);
            return DBHelper.ExecNonQuery();
        }
    }
}

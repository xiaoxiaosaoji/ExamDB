using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBLL
    {
        AccountDAL accountDAL = new AccountDAL();

        /// <summary>
        /// 获取单科目成绩
        /// </summary>
        /// <param name="StudentID">学生id</param>
        /// <param name="SubjectID">科目id</param>
        /// <returns></returns>
        public AccountEntity StudentFraction(string StudentID, string SubjectID)
        {
            return accountDAL.StudentFraction(StudentID, SubjectID);
        }

        /// <summary>
        /// 删除对应科目成绩
        /// </summary>
        /// <param name="StudentID">学生id</param>
        /// <param name="SubjectID">科目id</param>
        /// <returns></returns>
        public int DeleteStudentFraction(string StudentID, int SubjectID)
        {
            return accountDAL.DeleteStudentFraction(StudentID, SubjectID);
        }

        /// <summary>
        /// 获取学生各科目成绩
        /// </summary>
        /// <param name="uid">学生ID</param>
        /// <returns></returns>
        public List<AccountEntity> StudentAccount(string uid)
        {
            return accountDAL.StudentAccount(uid);
        }

        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="entity">成绩对象</param>
        /// <returns></returns>
        public int StudentAccountADD(AccountEntity entity)
        {
            return accountDAL.StudentAccountADD(entity);
        }
    }
}

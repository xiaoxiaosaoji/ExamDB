using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TeacherDAL
    {
        /// <summary>
        /// 获取教师的个人信息
        /// </summary>
        /// <param name="id">教师ID</param>
        /// <returns>返回教师对象</returns>
        public TeacherEntity TeacherDetail(string id)
        {
            string sql = "select * from Teacher where ID=@ID";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("ID", id);
            DataTable dt = DBHelper.ExecQuery();
            if (dt.Rows.Count == 0)
                return null;
            TeacherEntity teacher = new TeacherEntity();
            teacher.ID = dt.Rows[0]["ID"].ToString();
            teacher.Name = dt.Rows[0]["Name"].ToString();
            teacher.Pwd = dt.Rows[0]["Pwd"].ToString();
            teacher.Online = bool.Parse(dt.Rows[0]["Online"].ToString());
            return teacher;
        }

        /// <summary>
        /// 获取教师所带班级
        /// </summary>
        /// <param name="Tid">教师ID</param>
        /// <returns>返回班级数组</returns>
        public int[] TeacherClassList(string Tid)
        {
            string sql = "select distinct Classid from Student where Tid=@Tid ";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("Tid", Tid);
            DataTable dt = DBHelper.ExecQuery();
            if (dt.Rows.Count == 0)
                return null;
            int[] classArr = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                classArr[i] = int.Parse(dt.Rows[i]["Classid"].ToString());
            }
            return classArr;
        }
    }
}

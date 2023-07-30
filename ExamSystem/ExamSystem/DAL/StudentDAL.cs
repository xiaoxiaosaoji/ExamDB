using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDAL
    {
        /// <summary>
        /// 新增学生信息
        /// </summary>
        /// <param name="entity">学生对象</param>
        /// <returns>返回受影响行数</returns>
        public int StudentAdd(StudentEntity entity)
        {
            string sql = "insert Student values(@ID,@Name,@Pwd,@Classid,@Online,@Tid)";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("ID", entity.ID);
            DBHelper.SetParameter("Name", entity.Name);
            DBHelper.SetParameter("Pwd", entity.Pwd);
            DBHelper.SetParameter("Classid", entity.Classid);
            DBHelper.SetParameter("Online", entity.Online);
            DBHelper.SetParameter("Tid", entity.Tid);
            return DBHelper.ExecNonQuery();
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="entity">学生对象</param>
        /// <returns>返回受影响行数</returns>
        public int StudentUpdate(StudentEntity entity)
        {
            string sql = "update Student set ID=@ID,Name=@Name,Pwd=@Pwd,Classid=@Classid,Online=@Online,Tid=@Tid where ID=@ID";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("ID", entity.ID);
            DBHelper.SetParameter("Name", entity.Name);
            DBHelper.SetParameter("Pwd", entity.Pwd);
            DBHelper.SetParameter("Classid", entity.Classid);
            DBHelper.SetParameter("Online", entity.Online);
            DBHelper.SetParameter("Tid", entity.Tid);
            return DBHelper.ExecNonQuery();
        }

        /// <summary>
        /// 获取学生个人信息
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns>返回学生对象</returns>
        public StudentEntity StudentDetail(string id)
        {
            string sql = "select * from Student where ID=@ID";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("ID", id);
            DataTable dt = DBHelper.ExecQuery();
            if (dt.Rows.Count == 0)
                return null;
            StudentEntity student = new StudentEntity();
            student.ID = dt.Rows[0]["ID"].ToString();
            student.Name = dt.Rows[0]["Name"].ToString();
            student.Pwd = dt.Rows[0]["Pwd"].ToString();
            student.Classid = int.Parse(dt.Rows[0]["Classid"].ToString());
            student.Online = bool.Parse(dt.Rows[0]["Online"].ToString());
            return student;
        }

        /// <summary>
        /// 获取所有学生
        /// </summary>
        /// <returns>返回一组学生对象列表</returns>
        public List<StudentEntity> StudentList()
        {
            DataTable dt = new DataTable();
            string sql = "select * from Student";
            DBHelper.PrepareSql(sql);
            dt = DBHelper.ExecQuery();
            List<StudentEntity> list = new List<StudentEntity>();
            foreach (DataRow item in dt.Rows)
            {
                StudentEntity student = new StudentEntity();
                student.ID = item["ID"].ToString();
                student.Name = item["Name"].ToString();
                student.Pwd = item["Pwd"].ToString();
                student.Classid = int.Parse(item["Classid"].ToString());
                student.Online = bool.Parse(item["Online"].ToString());
                student.Tid = item["Tid"].ToString();
                list.Add(student);
            }
            return list;
        }

        /// <summary>
        /// 获取对应班级的学生列表
        /// </summary>
        /// <param name="Classid">班级ID</param>
        /// <returns>返回对应班级的学生列表</returns>
        public List<StudentEntity> StudentClassList(string Classid)
        {
            DataTable dt = new DataTable();
            string sql = "select * from Student where Classid=@Classid";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("Classid", Classid);
            dt = DBHelper.ExecQuery();
            List<StudentEntity> list = new List<StudentEntity>();
            foreach (DataRow item in dt.Rows)
            {
                StudentEntity student = new StudentEntity();
                student.ID = item["ID"].ToString();
                student.Name = item["Name"].ToString();
                student.Pwd = item["Pwd"].ToString();
                student.Classid = int.Parse(item["Classid"].ToString());
                student.Online = bool.Parse(item["Online"].ToString());
                student.Tid = item["Tid"].ToString();
                list.Add(student);
            }
            return list;
        }

        /// <summary>
        /// 获取对应班级的学生列表
        /// </summary>
        /// <param name="Classid">班级ID</param>
        /// <returns>返回对应班级的学生表</returns>
        public DataTable StudentClassListDt(string Classid)
        {
            DataTable dt = new DataTable();
            string sql = "select * from Student where Classid=@Classid";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("Classid", Classid);
            dt = DBHelper.ExecQuery();
            return dt;
        }
    }
}

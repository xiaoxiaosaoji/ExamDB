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
    public class StudentBLL
    {
        StudentDAL studentDAL = new StudentDAL();
        /// <summary>
        /// 新增学生信息
        /// </summary>
        /// <param name="entity">学生对象</param>
        /// <returns>返回受影响行数</returns>
        public int StudentAdd(StudentEntity entity)
        {
            return studentDAL.StudentAdd(entity);
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="entity">学生对象</param>
        /// <returns>返回受影响行数</returns>
        public int StudentUpdate(StudentEntity entity)
        {
            return studentDAL.StudentUpdate(entity);
        }

        /// <summary>
        /// 获取学生个人信息
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns>返回学生对象</returns>
        public StudentEntity StudentDetail(string id)
        {
            return studentDAL.StudentDetail(id);
        }

        /// <summary>
        /// 获取所有学生
        /// </summary>
        /// <returns>返回一组学生对象列表</returns>
        public List<StudentEntity> StudentList()
        {
            return studentDAL.StudentList();
        }

        /// <summary>
        /// 获取对应班级的学生列表
        /// </summary>
        /// <param name="Classid">班级ID</param>
        /// <returns>返回对应班级的学生列表</returns>
        public List<StudentEntity> StudentClassList(string Classid)
        {
            return studentDAL.StudentClassList(Classid);
        }

        /// <summary>
        /// 获取对应班级的学生列表
        /// </summary>
        /// <param name="Classid">班级ID</param>
        /// <returns>返回对应班级的学生表</returns>
        public DataTable StudentClassListDt(string Classid)
        {
            return studentDAL.StudentClassListDt(Classid);
        }
    }
}

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
    public class TeacherBLL
    {
       TeacherDAL teacherDAL = new TeacherDAL();

        /// <summary>
        /// 获取教师的个人信息
        /// </summary>
        /// <param name="id">教师ID</param>
        /// <returns>返回教师对象</returns>
        public TeacherEntity TeacherDetail(string id)
        {
            return teacherDAL.TeacherDetail(id);
        }

        /// <summary>
        /// 获取教师所带班级
        /// </summary>
        /// <param name="Tid">教师ID</param>
        /// <returns>返回班级数组</returns>
        public int[] TeacherClassList(string Tid)
        {
            return teacherDAL.TeacherClassList(Tid);
        }
    }
}

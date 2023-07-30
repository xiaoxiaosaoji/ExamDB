using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SubjectBLL
    {
        SubjectDAL dal = new SubjectDAL();

        /// <summary>
        /// 获取学习阶段
        /// </summary>
        /// <returns></returns>
        public int[] SubjectGradeLevel()
        {
            return dal.SubjectGradeLevel();
        }

        /// <summary>
        /// 获取当前学习阶段对应的课程
        /// </summary>
        /// <param name="GradeLevel">课程阶段id</param>
        /// <returns></returns>
        public List<SubjectEntity> SubjectList(int GradeLevel)
        {
            return dal.SubjectList(GradeLevel);
        }
    }
}

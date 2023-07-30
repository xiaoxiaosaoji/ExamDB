using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SubjectDAL
    {
        /// <summary>
        /// 获取学习阶段
        /// </summary>
        /// <returns></returns>
        public int[] SubjectGradeLevel()
        {
            string sql = "select distinct GradeLevel from Subject";
            DBHelper.PrepareSql(sql);
            DataTable dt = DBHelper.ExecQuery();
            int[] intArr = new int[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                intArr[i] = int.Parse(dr["GradeLevel"].ToString());
                i++;
            }
            return intArr;
        }

        /// <summary>
        /// 获取当前学习阶段对应的课程
        /// </summary>
        /// <param name="GradeLevel">课程阶段id</param>
        /// <returns></returns>
        public List<SubjectEntity> SubjectList(int GradeLevel)
        {
            string sql = "select *  from Subject where GradeLevel=@GradeLevel";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("GradeLevel", GradeLevel);
            DataTable dt = DBHelper.ExecQuery();
            List<SubjectEntity> list = new List<SubjectEntity>();
            foreach (DataRow item in dt.Rows)
            {
                SubjectEntity entity = new SubjectEntity();
                entity.ID = int.Parse(item["ID"].ToString());
                entity.SName = item["SName"].ToString();
                entity.GradeLevel = int.Parse(item["GradeLevel"].ToString());
                list.Add(entity);
            }
            return list;
        }
    }
}

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
    public class TitleListBLL
    {
        TitleListDAL titleListDAL = new TitleListDAL();
        /// <summary>
        /// 添加考试
        /// </summary>
        /// <param name="entity">考试对象</param>
        /// <returns></returns>
        public int TitleListADD(TitleListEntity entity)
        {
            return titleListDAL.TitleListADD(entity);
        }

        /// <summary>
        /// 获取最新一场考试
        /// </summary>
        /// <param name="classid">班级id</param>
        /// <param name="sid">科目id</param>
        /// <returns></returns>
        public TitleListEntity Detail(string classid, string sid)
        {
            return titleListDAL.Detail(classid, sid);
        }
        /// <summary>
        /// 修改考试状态
        /// </summary>
        /// <param name="id">考试id</param>
        /// <returns></returns>
        public int UpdateState(string id)
        {
            return titleListDAL.UpdateState(id);
        }
    }
}

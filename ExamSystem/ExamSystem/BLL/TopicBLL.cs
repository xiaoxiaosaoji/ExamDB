using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TopicBLL
    {
        TopicDAL dal = new TopicDAL();

        /// <summary>
        /// 获取对应科目的题目
        /// </summary>
        /// <param name="Sid">科目ID</param>
        /// <returns>返回题目列表对象</returns>
        public List<TopicEntity> TopocList(int Sid)
        {
            return dal.TopocList(Sid);
        }
        /// <summary>
        /// 修改题目信息
        /// </summary>
        /// <param name="entity">题目对象</param>
        /// <returns>返回受影响行数</returns>
        public int Update(TopicEntity entity)
        {
            return dal.Update(entity);
        }
        /// <summary>
        /// 获取单个题目的信息
        /// </summary>
        /// <param name="id">题目ID</param>
        /// <returns>返回题目对象</returns>
        public TopicEntity Detail(int ID)
        {
            return dal.Detail(ID);
        }
        /// <summary>
        /// 添加题目
        /// </summary>
        /// <param name="entity">题目对象</param>
        /// <returns>返回受影响行数</returns>
        public int TopicADD(TopicEntity entity)
        {
            return dal.TopicADD(entity);
        }
    }
}

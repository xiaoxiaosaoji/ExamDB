using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TopicDAL
    {
        /// <summary>
        /// 获取对应科目的题目
        /// </summary>
        /// <param name="Sid">科目ID</param>
        /// <returns>返回题目列表对象</returns>
        public List<TopicEntity> TopocList(int Sid)
        {
            string sql = "select * from Topic where Sid=@Sid";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("Sid", Sid);
            DataTable dt = DBHelper.ExecQuery();
            List<TopicEntity> list = new List<TopicEntity>();
            foreach (DataRow item in dt.Rows)
            {
                TopicEntity topic = new TopicEntity();
                topic.ID = int.Parse(item["ID"].ToString());
                topic.Title = item["Title"].ToString();
                topic.answerA = item["answerA"].ToString();
                topic.answerB = item["answerB"].ToString();
                topic.answerC = item["answerC"].ToString();
                topic.answerD = item["answerD"].ToString();
                topic.isMore = bool.Parse(item["isMore"].ToString());
                topic.Answer = item["Answer"].ToString();
                topic.Sid = int.Parse(item["Sid"].ToString());
                topic.Grade = int.Parse(item["Grade"].ToString());
                list.Add(topic);
            }
            return list;
        }

        /// <summary>
        /// 修改题目信息
        /// </summary>
        /// <param name="entity">题目对象</param>
        /// <returns>返回受影响行数</returns>
        public int Update(TopicEntity entity)
        {
            string sql = "update Topic set Title=@Title,answerA=@answerA,answerB=@answerB,answerC=@answerC,answerD=@answerD,isMore=@isMore,Answer=@Answer,Sid=@Sid,Grade=@Grade where ID=@ID";
            //string sql = "update Topic set isMore=@isMore where ID=@ID";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("ID", entity.ID);
            DBHelper.SetParameter("Title", entity.Title);
            DBHelper.SetParameter("answerA", entity.answerA);
            DBHelper.SetParameter("answerB", entity.answerB);
            DBHelper.SetParameter("answerC", entity.answerC);
            DBHelper.SetParameter("answerD", entity.answerD);
            DBHelper.SetParameter("isMore", entity.isMore);
            DBHelper.SetParameter("Answer", entity.Answer);
            DBHelper.SetParameter("Sid", entity.Sid);
            DBHelper.SetParameter("Grade", entity.Grade);
            return DBHelper.ExecNonQuery();
        }

        /// <summary>
        /// 获取单个题目的信息
        /// </summary>
        /// <param name="id">题目ID</param>
        /// <returns>返回题目对象</returns>
        public TopicEntity Detail(int id)
        {
            string sql = "select * from Topic where ID=@ID";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("ID", id);
            DataTable dt = DBHelper.ExecQuery();
            if (dt.Rows.Count == 0)
                return null;
            TopicEntity entity = new TopicEntity();
            entity.ID = int.Parse(dt.Rows[0]["ID"].ToString());
            entity.Title = dt.Rows[0]["Title"].ToString();
            entity.answerA = dt.Rows[0]["answerA"].ToString();
            entity.answerB = dt.Rows[0]["answerB"].ToString();
            entity.answerC = dt.Rows[0]["answerC"].ToString();
            entity.answerD = dt.Rows[0]["answerD"].ToString();
            entity.isMore = bool.Parse(dt.Rows[0]["isMore"].ToString());
            entity.Answer = dt.Rows[0]["Answer"].ToString();
            entity.Sid = int.Parse(dt.Rows[0]["Sid"].ToString());
            entity.Grade = int.Parse(dt.Rows[0]["Grade"].ToString());
            return entity;
        }

        /// <summary>
        /// 添加题目
        /// </summary>
        /// <param name="entity">题目对象</param>
        /// <returns>返回受影响行数</returns>
        public int TopicADD(TopicEntity entity)
        {
            string sql = "insert Topic values(@Title,@answerA,@answerB,@answerC,@answerD,@isMore,@Answer,@Sid,@Grade)";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("Title", entity.Title);
            DBHelper.SetParameter("answerA", entity.answerA);
            DBHelper.SetParameter("answerB", entity.answerB);
            DBHelper.SetParameter("answerC", entity.answerC);
            DBHelper.SetParameter("answerD", entity.answerD);
            DBHelper.SetParameter("isMore", entity.isMore);
            DBHelper.SetParameter("Answer", entity.Answer);
            DBHelper.SetParameter("Sid", entity.Sid);
            DBHelper.SetParameter("Grade", entity.Grade);
            return DBHelper.ExecNonQuery();
        }
    }
}

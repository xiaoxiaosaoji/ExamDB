using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TitleListDAL
    {
        /// <summary>
        /// 添加考试
        /// </summary>
        /// <param name="entity">考试对象</param>
        /// <returns></returns>
        public int TitleListADD(TitleListEntity entity)
        {
            string sql = "insert TitleList values(@uid,@sid,@titleList,@state,@classid,@createTime,@subTime)";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("uid", entity.uid);
            DBHelper.SetParameter("sid", entity.sid);
            DBHelper.SetParameter("titleList", entity.titleList);
            DBHelper.SetParameter("state", entity.state);
            DBHelper.SetParameter("classid", entity.classid);
            DBHelper.SetParameter("createTime", entity.createTime);
            DBHelper.SetParameter("subTime", entity.subTime);
            return DBHelper.ExecNonQuery();
        }

        /// <summary>
        /// 获取最新一场考试
        /// </summary>
        /// <param name="classid">班级id</param>
        /// <param name="sid">科目id</param>
        /// <returns></returns>
        public TitleListEntity Detail(string classid, string sid)
        {
            string sql = "select * from TitleList where classid=@classid and sid=@sid";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("classid", classid);
            DBHelper.SetParameter("sid", int.Parse(sid));
            DataTable dt = DBHelper.ExecQuery();
            if (dt.Rows.Count == 0)
                return null;
            TitleListEntity titleListEntity = new TitleListEntity();
            titleListEntity.id = int.Parse(dt.Rows[dt.Rows.Count - 1]["id"].ToString());
            titleListEntity.uid = dt.Rows[dt.Rows.Count - 1]["uid"].ToString();
            titleListEntity.sid = int.Parse(dt.Rows[dt.Rows.Count - 1]["sid"].ToString());
            titleListEntity.titleList = dt.Rows[dt.Rows.Count - 1]["titleList"].ToString();
            titleListEntity.state = int.Parse(dt.Rows[dt.Rows.Count - 1]["state"].ToString());
            titleListEntity.classid = int.Parse(dt.Rows[dt.Rows.Count - 1]["classid"].ToString());
            titleListEntity.createTime = (DateTime?)dt.Rows[dt.Rows.Count - 1]["createTime"];
            titleListEntity.subTime = (DateTime?)dt.Rows[dt.Rows.Count - 1]["subTime"];
            return titleListEntity;
        }
        /// <summary>
        /// 修改考试状态
        /// </summary>
        /// <param name="id">考试id</param>
        /// <returns></returns>
        public int UpdateState(string id)
        {
            string sql = "update TitleList set state=0 where id=@id";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("id", id);
            return DBHelper.ExecNonQuery();
        }
    }
}

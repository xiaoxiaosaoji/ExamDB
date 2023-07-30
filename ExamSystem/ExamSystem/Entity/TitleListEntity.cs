using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TitleListEntity
    {
        /// <summary>
        /// 无    
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string uid { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int sid { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string titleList { get; set; }

        /// <summary>
        /// 考试状态，0:未开考，1:开考    
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int? classid { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? subTime { get; set; }
    }
}

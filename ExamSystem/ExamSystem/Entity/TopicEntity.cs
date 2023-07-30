using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TopicEntity
    {
        /// <summary>
        /// 无    
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string answerA { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string answerB { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string answerC { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string answerD { get; set; }

        /// <summary>
        /// 是否多选    
        /// </summary>
        public bool isMore { get; set; }

        /// <summary>
        /// 正确答案    
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int Sid { get; set; }

        /// <summary>
        /// 题目分数    
        /// </summary>
        public int Grade { get; set; }
    }
}

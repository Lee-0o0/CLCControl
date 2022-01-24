using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLCControls.Model
{
    public class QueryResult
    {
        /// <summary>
        /// 操作结果：true表示成功，false表示失败
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get
            {
                if (PageSize == 0)
                    return 0;
                return (TotalSize / PageSize) + (TotalSize % PageSize == 0 ? 0 : 1);
            }
        }
        /// <summary>
        /// 查询结果
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 实体类型
        /// </summary>
        public Type ElementType { get; set; }
    }
}

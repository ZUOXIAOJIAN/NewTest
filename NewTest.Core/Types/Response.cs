﻿namespace NewTest.Core.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class Response
    {
        /// <summary>
        /// 返回代码. 0-失败，1-成功，其他-具体见方法返回值说明
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public dynamic Data { get; set; }

        public Response()
        {
            Code = 0;
        }
    }
}

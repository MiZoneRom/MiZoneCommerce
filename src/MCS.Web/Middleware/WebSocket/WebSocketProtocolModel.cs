using MCS.Web.Middleware.WebSocket.Command;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MCS.Web.Middleware.WebSocket
{
    public class WebSocketProtocolModel
    {
        public WebSocketProtocolCommandType Cmd { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
        public bool? Success { get; set; }
        public object errorCode { get; set; }

        public object GetValue(string propertyname)
        {
            var socketData = JsonConvert.DeserializeObject<Hashtable>(this.Data.ToString());
            return socketData[propertyname];
        }

        /// <summary>
        /// 获取数据值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public int GetIntValue(string propertyName)
        {
            return Convert.ToInt32(GetValue(propertyName));
        }

        /// <summary>
        /// 获取数据值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public long GetLongValue(string propertyName)
        {
            return Convert.ToInt64(GetValue(propertyName).ToString());
        }

        /// <summary>
        /// 获取数据值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string GetStrValue(string propertyName)
        {
            return GetValue(propertyName).ToString();
        }

        /// <summary>
        /// 获取数据值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public decimal GetDecimalValue(string propertyName)
        {
            return Convert.ToDecimal(GetValue(propertyName).ToString());
        }

    }
}

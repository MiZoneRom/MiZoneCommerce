using MCS.Core;
using MCS.Web.Middleware.WebSocket;
using MCS.Web.Middleware.WebSocket.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket.Logic
{
    [MessageCommand(WebSocketProtocolCommandType.Message)]
    public class MessageLogic : IWebSocketCommand
    {
        public MessageLogic()
        {
        }

        public async void ReceiveModel(WebSocketSession session, WebSocketProtocolModel message)
        {
            //消息目标
            MessageTarget target = message.GetEnumValue<MessageTarget>("target");
            //消息内容
            string msg = message.Msg;
            //发生时间
            DateTime date = DateTime.Now;
            //消息类型
            MessageType type = message.GetEnumValue<MessageType>("type");
            //消息目标
            int targetId = message.GetIntValue("targetId");

            var sendMessageModel = new WebSocketProtocolModel()
            {
                Cmd = WebSocketProtocolCommandType.Message,
                Success = true,
                Msg = msg,
                Data = new
                {
                    Type = type,
                    Date = date,
                    TargetId = 1
                }
            };

            if (target == MessageTarget.Person)
            {

            }
            else if (target == MessageTarget.Community)
            {

            }
            else if (target == MessageTarget.Department)
            {

            }
            else if (target == MessageTarget.Broadcast)
            {
                BroadcastMessage(sendMessageModel);
            }

        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="message"></param>
        private async void BroadcastMessage(WebSocketProtocolModel message)
        {
            await WebSocketSessionPool.Broadcast(message);
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        private enum MessageType
        {
            /// <summary>
            /// 文字
            /// </summary>
            Text = 1,
            /// <summary>
            /// 语音
            /// </summary>
            Voice = 2,
            /// <summary>
            /// 图片
            /// </summary>
            Image = 3
        }

        private enum MessageTarget
        {
            /// <summary>
            /// 个人私聊
            /// </summary>
            Person = 1,
            /// <summary>
            /// 社区
            /// </summary>
            Community = 2,
            /// <summary>
            /// 部门
            /// </summary>
            Department = 3,
            /// <summary>
            /// 广播
            /// </summary>
            Broadcast = 4
        }

    }
}

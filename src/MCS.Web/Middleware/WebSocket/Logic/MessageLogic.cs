using MCS.Core;
using MCS.Core.Helper;
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
            int duration = message.GetIntValue("duration");

            var sendMessageModel = new WebSocketProtocolModel()
            {
                Cmd = WebSocketProtocolCommandType.Message,
                Success = true,
                Msg = msg,
                Data = new
                {
                    Type = type,
                    Date = date,
                    Timestamp = StringHelper.GetTimeStamp(),
                    TargetId = targetId,
                    Target = target,
                    Nick = StringHelper.GetTimeStamp(),
                    Duration = duration,
                    Avatar = "https://thirdwx.qlogo.cn/mmopen/vi_32/Q0j4TwGTfTJmNEmZfcl6SDQkahpeQljK7pR1EKJx3Oia6M7wicL3AFoBYmiafOxNIygVI5rNPPMCgUZMGnKWuZHFQ/132"
                }
            };

            if (target == MessageTarget.Person)
            {
                await BroadcastMessage(sendMessageModel);
            }
            else if (target == MessageTarget.Community)
            {
                await BroadcastMessage(sendMessageModel);
            }
            else if (target == MessageTarget.Department)
            {
                await BroadcastMessage(sendMessageModel);
            }
            else if (target == MessageTarget.Broadcast)
            {
                await BroadcastMessage(sendMessageModel);
            }

        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="message"></param>
        private async Task BroadcastMessage(WebSocketProtocolModel message)
        {
            await WebSocketSessionPool.Broadcast(message);

            //开辟一个新线程用于发送微信消息
            await Task.Factory.StartNew(() => { });
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
            Image = 3,
            /// <summary>
            /// 视频
            /// </summary>
            Video
        }

        /// <summary>
        /// 消息目标
        /// </summary>
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

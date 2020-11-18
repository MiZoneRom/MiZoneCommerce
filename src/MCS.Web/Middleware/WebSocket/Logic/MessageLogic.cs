using MCS.Core;
using MCS.Core.Helper;
using MCS.Web.Middleware.WebSocket;
using MCS.Web.Middleware.WebSocket.Command;
using Senparc.Weixin;
using Senparc.Weixin.Entities.TemplateMessage;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.WxOpen.AdvancedAPIs.Sns;
using Senparc.Weixin.WxOpen.Containers;
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

            string nick = StringHelper.GetTimeStamp();

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
                    Nick = nick,
                    Duration = duration,
                    Avatar = "https://thirdwx.qlogo.cn/mmopen/vi_32/Q0j4TwGTfTJmNEmZfcl6SDQkahpeQljK7pR1EKJx3Oia6M7wicL3AFoBYmiafOxNIygVI5rNPPMCgUZMGnKWuZHFQ/132"
                }
            };

            if (target == MessageTarget.Person)
            {
                await BroadcastMessage(sendMessageModel);

                if ((DateTime.Now - session.LastSendWeiXinOpen).TotalHours > 2)
                {
                    session.LastSendWeiXinOpen = DateTime.Now;
                    //开辟一个新线程用于发送微信消息
                    await Task.Factory.StartNew(() => SendWXMessage(nick, message.Msg, "您有一条新的消息"));
                }
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
        }

        private async void SendWXMessage(string source, string content, string tip)
        {

            //登录
            //var jsonResult = SnsApi.JsCode2Json("appid", "appsecret", "code");
            //if (jsonResult.errcode == ReturnCode.请求成功)
            //{
            //    //Session["WxOpenUser"] = jsonResult;//使用Session保存登陆信息（不推荐）
            //    //使用SessionContainer管理登录信息（推荐）
            //    var unionId = "";
            //    var sessionBag = SessionContainer.UpdateSession(null, jsonResult.openid, jsonResult.session_key, unionId);

            //    //注意：生产环境下SessionKey属于敏感信息，不能进行传输！
            //    return Json(new { success = true, msg = "OK", sessionId = sessionBag.Key, sessionKey = sessionBag.SessionKey });
            //}
            //else
            //{
            //    return Json(new { success = false, msg = jsonResult.errmsg });
            //}

            //获取token
            //await AccessTokenContainer.RegisterAsync("wxf4ce6bf0b56699b3", "eadbda3863b6ac5a1e43713c24a86d1e");
            //string access_token = AccessTokenContainer.GetAccessTokenResult("wxf4ce6bf0b56699b3").access_token;

            var templateMessageData = new TemplateMessageData();
            templateMessageData["thing1"] = new TemplateMessageDataValue(source);
            templateMessageData["thing2"] = new TemplateMessageDataValue(StringHelper.CutString(content, 15));
            templateMessageData["date3"] = new TemplateMessageDataValue(DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"));
            templateMessageData["thing4"] = new TemplateMessageDataValue(tip);

            var page = "page/tabbar/index/index";
            string templateId = "-tJp5MPKiysoDTioBgZo70Qn8cku3yc5jG-RPgbsSaI";
            string openId = "oaDT45YxHE-w7jEZOHt5LniAB5S8";
            string appId = "wxf4ce6bf0b56699b3";

            try
            {
                var result = await Senparc.Weixin.WxOpen.AdvancedAPIs.MessageApi.SendSubscribeAsync(appId, openId, templateId, templateMessageData, page);
                if (result.errcode == ReturnCode.请求成功)
                {
                    Log.Debug("msg Success");
                }
                else
                {
                    Log.Debug(result);
                }
            }
            catch (Exception ex)
            {
                Log.Error("aaaa", ex);
            }

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
            Video = 4
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

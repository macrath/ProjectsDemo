using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2
{
    public class QQOAuth : OAuth2Base
    {
        internal override OAuthServer server
        {
            get
            {
                return OAuthServer.QQ;
            }
        }
        internal override string ImgUrl
        {
            get
            {
                return "<img align='absmiddle' src=\"/skin/system_tech/images/oauth_qq.png\" /> QQ";
            }
        }
        internal override string OAuthUrl
        {
            get
            {
                return "https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}";
            }
        }
        internal override string TokenUrl
        {
            get
            {
                return "https://graph.qq.com/oauth2.0/token";
            }
        }
        internal string OpenIDUrl = "https://graph.qq.com/oauth2.0/me?access_token={0}";
        internal string UserInfoUrl = "https://graph.qq.com/user/get_user_info?access_token={0}&oauth_consumer_key={1}&openid={2}";
        public override bool Authorize()
        {
            if (!string.IsNullOrEmpty(code))
            {
                string result = GetToken("GET");//һ���Է������ݣ�QQ������Token������Ҫһ�������ȡOpenID��//access_token=A5E175586196173434374BD3DBBAA5E8A3&expires_in=7776000
                //�ֽ�result;
                if (!string.IsNullOrEmpty(result))
                {
                    try
                    {
                        token = Tool.QueryString(result, "access_token");
                        if (!string.IsNullOrEmpty(token))
                        {
                            double d = 0;
                            if (double.TryParse(Tool.QueryString(result, "expires_in"), out d))
                            {
                                expiresTime = DateTime.Now.AddSeconds(d);
                            }
                            //��ȡOpenID
                            result = wc.DownloadString(string.Format(OpenIDUrl, token));
                            if (!string.IsNullOrEmpty(result)) //���أ�callback( {"client_id":"YOUR_APPID","openid":"YOUR_OPENID"} ); 
                            {
                                openID = Tool.GetJosnValue(result, "openid");
                            }
                            if (!string.IsNullOrEmpty(openID))
                            {
                                //��ȡQQ�˺ź�ͷ��
                                result = wc.DownloadString(string.Format(UserInfoUrl, token, AppKey, openID));
                                if (!string.IsNullOrEmpty(result)) //���أ�callback( {"client_id":"YOUR_APPID","openid":"YOUR_OPENID"} ); 
                                {
                                    nickName = Tool.GetJosnValue(result, "nickname");
                                    headUrl = Tool.GetJosnValue(result, "figureurl");
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            CYQ.Data.Log.WriteLogToTxt("QQOAuth.Authorize():" + result);
                        }
                    }
                    catch (Exception err)
                    {
                        CYQ.Data.Log.WriteLogToTxt(err);
                    }
                }
            }
            return false;
        }
    }
}

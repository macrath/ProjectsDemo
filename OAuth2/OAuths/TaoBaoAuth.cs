using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2
{
    class TaoBaoAuth : OAuth2Base
    {
        internal override OAuthServer server
        {
            get
            {
                return OAuthServer.TaoBao;
            }
        }
        internal override string ImgUrl
        {
            get
            {
                return "<img align='absmiddle' src=\"/skin/system_tech/images/oauth_taobao.png\" /> �Ա�";
            }
        }
        internal override string OAuthUrl
        {
            get
            {
                return "https://oauth.taobao.com/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}";
            }
        }
        internal override string TokenUrl
        {
            get
            {
                return "https://oauth.taobao.com/token";
            }
        }
        public override bool Authorize()
        {
            if (!string.IsNullOrEmpty(code))
            {
                string result = GetToken("POST");//һ���Է������ݡ�
                //�ֽ�result;
                if (!string.IsNullOrEmpty(result))
                {
                    try
                    {
                        token = Tool.GetJosnValue(result, "access_token");
                        if (!string.IsNullOrEmpty(token))
                        {
                            double d = 0;
                            if (double.TryParse(Tool.GetJosnValue(result, "expires_in"), out d))
                            {
                                expiresTime = DateTime.Now.AddSeconds(d);
                            }
                            //��ȡOpenID
                            openID = Tool.GetJosnValue(result, "taobao_user_id");
                            nickName = Tool.GetJosnValue(result, "taobao_user_nick");
                            return true;

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

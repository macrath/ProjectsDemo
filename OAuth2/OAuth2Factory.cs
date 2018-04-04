using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace OAuth2
{
    /// <summary>
    /// ��Ȩ������
    /// </summary>
    public class OAuth2Factory
    {
        /// <summary>
        /// ��ȡ��ǰ����Ȩ���͡�
        /// </summary>
        public static OAuth2Base Current
        {
            get
            {
                if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
                {
                    string url = System.Web.HttpContext.Current.Request.Url.Query;
                    if (url.IndexOf("state=") > -1)
                    {
                        string code = Tool.QueryString(url, "code");
                        string state = Tool.QueryString(url, "state");
                        if (ServerList.ContainsKey(state))
                        {
                            OAuth2Base ob = ServerList[state];
                            ob.code = code;
                            System.Web.HttpContext.Current.Session["OAuth2"] = ob;//������Session��������Ȩ����������á�
                            return ob;
                        }
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// ��ȡ�����õ�ǰSession�浵����Ȩ���͡� (ע���û�ʱ���Խ���ֵ��ΪNull)
        /// </summary>
        public static OAuth2Base SessionOAuth
        {
            get
            {
                if (System.Web.HttpContext.Current.Session != null)
                {
                    object o = System.Web.HttpContext.Current.Session["OAuth2"];
                    if (o != null)
                    {
                        return o as OAuth2Base;
                    }
                }
                return null;
            }
            set
            {
                System.Web.HttpContext.Current.Session["OAuth2"] = value;
            }
        }
        static Dictionary<string, OAuth2Base> _ServerList;
        /// <summary>
        /// ��ȡ���е����ͣ��¿�����OAuth2��Ҫ������ע�����һ�£�
        /// </summary>
        internal static Dictionary<string, OAuth2Base> ServerList
        {
            get
            {
                if (_ServerList == null)
                {
                    _ServerList = new Dictionary<string, OAuth2Base>(StringComparer.OrdinalIgnoreCase);
                    _ServerList.Add(OAuthServer.SinaWeiBo.ToString(), new SinaWeiBoOAuth());//����΢��
                    _ServerList.Add(OAuthServer.QQ.ToString(), new QQOAuth());//QQ΢��
                    _ServerList.Add(OAuthServer.TaoBao.ToString(), new TaoBaoAuth());//�Ա�
                }
                return _ServerList;
            }
        }
    }
}

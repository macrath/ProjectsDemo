using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2
{
    public class UI
    {
        public static string GetHtml()
        {
            string link = "<a href=\"{0}\" target=\"_blank\">{1}</a> ";
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string,OAuth2Base> ob in OAuth2Factory.ServerList)
            {
                if (!string.IsNullOrEmpty(ob.Value.AppKey))
                {
                    sb.AppendFormat(link, string.Format(ob.Value.OAuthUrl, ob.Value.AppKey,System.Web.HttpUtility.UrlEncode(ob.Value.CallbackUrl), ob.Key), ob.Value.ImgUrl);
                }
            }
            return sb.ToString();
        }
    }

}

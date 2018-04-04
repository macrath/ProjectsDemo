using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2
{
    public class OAuth2Account : CYQ.Data.Orm.OrmBase
    {
        public OAuth2Account()
        {
            base.SetInit(this, "OAuth2Account", "Txt Path={0}App_Data");
        }
        private int _ID;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        private string _OAuthServer;
        /// <summary>
        /// ��Ȩ�ķ�������
        /// </summary>
        public string OAuthServer
        {
            get
            {
                return _OAuthServer;
            }
            set
            {
                _OAuthServer = value;
            }
        }
        private string _Token;
        /// <summary>
        /// �����Token
        /// </summary>
        public string Token
        {
            get
            {
                return _Token;
            }
            set
            {
                _Token = value;
            }
        }
        private string _OpenID;
        /// <summary>
        /// �����Ӧ��ID
        /// </summary>
        public string OpenID
        {
            get
            {
                return _OpenID;
            }
            set
            {
                _OpenID = value;
            }
        }
        private string _BindAccount;

        private DateTime _ExpireTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime ExpireTime
        {
            get
            {
                return _ExpireTime;
            }
            set
            {
                _ExpireTime = value;
            }
        }

        private string _NickName;
        /// <summary>
        /// ���صĵ������ǳ�
        /// </summary>
        public string NickName
        {
            get
            {
                return _NickName;
            }
            set
            {
                _NickName = value;
            }
        }
        private string _HeadUrl;
        /// <summary>
        /// ���صĵ������˺Ŷ�Ӧ��ͷ���ַ��
        /// </summary>
        public string HeadUrl
        {
            get
            {
                return _HeadUrl;
            }
            set
            {
                _HeadUrl = value;
            }
        }


        /// <summary>
        /// �󶨵��˺�
        /// </summary>
        public string BindAccount
        {
            get
            {
                return _BindAccount;
            }
            set
            {
                _BindAccount = value;
            }
        }
    }
}

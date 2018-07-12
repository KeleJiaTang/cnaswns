/// <summary>
///唯一更新网站: http://www.cckan.net
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;

namespace CRD.Common
{
    #region AppException
    [global::System.Serializable]
    public class AppException : Exception
    {
        private object[] _args;
        private ArrayList _invalidData;

        public object[] Args
        {
            get { return _args; }
        }

        public ArrayList InvalidData
        {
            get { return _invalidData; }
        }

        public AppException()
        {
            this.InitializeInvalidData(null);
        }

        public AppException(string message)
            : base(message)
        {
            this.InitializeInvalidData(null);
        }

        public AppException(string message, object[] args)
            : base(message)
        {
            this._args = args;
            this.InitializeInvalidData(null);
        }

        public AppException(string message, Exception inner)
            : base(message, inner)
        {
            this.InitializeInvalidData(null);
        }

        public AppException(string message, object[] args, Exception inner)
            : base(message, inner)
        {
            this._args = args;
            this.InitializeInvalidData(null);
        }

        public AppException(object invalidData, string message)
            : base(message)
        {
            this.InitializeInvalidData(invalidData);
        }

        public AppException(object invalidData, string message, object[] args)
            : base(message)
        {
            this._args = args;
            this.InitializeInvalidData(invalidData);
        }

        public AppException(object invalidData, string message, Exception inner)
            : base(message, inner)
        {
            this.InitializeInvalidData(invalidData);
        }

        public AppException(object invalidData, string message, object[] args, Exception inner)
            : base(message, inner)
        {
            this._args = args;
            this.InitializeInvalidData(invalidData);
        }

        private void InitializeInvalidData(object invalidData)
        {
            this._invalidData = new ArrayList();

            if (invalidData != null)
            {
                if (invalidData is ICollection)
                {
                    this._invalidData.AddRange((ICollection)invalidData);
                }
                else
                {
                    this._invalidData.Add(invalidData);
                }
            }
        }

#if !CF
        protected AppException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _args = info.GetValue("_args", typeof(object[])) as object[];
            _invalidData = info.GetValue("_invalidData", typeof(ArrayList)) as ArrayList;
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter)]
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_args", _args, typeof(object[]));
            info.AddValue("_invalidData", _invalidData, typeof(ArrayList));
            base.GetObjectData(info, context);
        }
#else
        protected GeneralException(SerializationInfo info, StreamingContext context)
        {
        }
#endif

        public override string ToString()
        {
            if (_args != null)
            {
                return string.Format(Message, _args);
            }
            else
            {
                return base.ToString();
            }
        }
    }
    #endregion
}

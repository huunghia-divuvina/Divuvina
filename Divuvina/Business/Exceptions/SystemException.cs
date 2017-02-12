using System;

namespace Divuvina.Business.Exceptions
{
    public class SystemException : BaseRuntimeException
    {
        public SystemException()
            : base()
        {
        }

        public SystemException(String message)
            : base(message)
        {

        }
    }
}
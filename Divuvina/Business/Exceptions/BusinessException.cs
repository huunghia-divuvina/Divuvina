using System;

namespace Divuvina.Business.Exceptions
{
    public class BusinessException : BaseRuntimeException
    {

        public BusinessException()
            : base()
        {
        }


        public BusinessException(String message)
            : base(message)
        {

        }

        public BusinessException(String message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
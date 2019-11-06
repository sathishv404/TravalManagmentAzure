using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API.Infrastructure.Exceptions
{
    public class AuthenticationDomainException:Exception
    {
        public AuthenticationDomainException()
        { }

        public AuthenticationDomainException(string message)
            : base(message)
        { }

        public AuthenticationDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

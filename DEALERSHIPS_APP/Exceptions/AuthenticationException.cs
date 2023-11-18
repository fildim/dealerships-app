﻿using System.Runtime.Serialization;

namespace DEALERSHIPS_APP.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException() { }

        public AuthenticationException(string? message) : base(message)
        {
        }

        public AuthenticationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
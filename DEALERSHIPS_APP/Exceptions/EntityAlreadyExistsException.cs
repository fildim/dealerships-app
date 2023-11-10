﻿using System.Runtime.Serialization;

namespace DEALERSHIPS_APP.Exceptions
{
	public class EntityAlreadyExistsException : Exception
	{
		public EntityAlreadyExistsException() { }

		public EntityAlreadyExistsException(string? message) : base(message) { }

		public EntityAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) { }

		protected EntityAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}

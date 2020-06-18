using System;
namespace MCS.Core
{
	public class MCSIOException : MCSException
	{
		public MCSIOException()
		{
		}
		public MCSIOException(string message) : base(message)
		{
		}
        public MCSIOException(string message, Exception inner)
            : base(message, inner)
		{
		}
	}
}

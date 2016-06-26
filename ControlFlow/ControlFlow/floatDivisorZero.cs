using System;
using System.Runtime.Serialization;

namespace ControlFlowException
{
    [Serializable]
    internal class floatDivisorZero : Exception
    {
        public floatDivisorZero()
        {
        }

        public floatDivisorZero(string message) : base(message)
        {
        }

        public floatDivisorZero(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected floatDivisorZero(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
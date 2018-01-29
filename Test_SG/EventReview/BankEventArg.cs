using System;

namespace EventReview
{
    public class BankEventArg: EventArgs
    {
        public string Message { get; set; }

        public BankEventArg(string message)
        {
            Message = message;

        }
    }
}
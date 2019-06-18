using System.Collections.Generic;
using VinilSales.Domain.CoreContext.Interfaces;

namespace VinilSales.Application.CoreContext
{
    public class ValidationMessage : IValidationMessage
    {
        private List<string> _messages;
        public List<string> Messages
        {
            get
            {
                if (_messages == null)
                    _messages = new List<string>();

                return _messages;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Messages.Count == 0;
            }
        }

        public void Add(string message)
        {
            Messages.Add(message);
        }

        public void AddRange(List<string> messages)
        {
            Messages.AddRange(messages);
        }
    }
}

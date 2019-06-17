using System.Collections.Generic;
using VinilSales.Domain.CoreContext.Interfaces;

namespace VinilSales.Application.CoreContext
{
    public class ValidationMessage : IValidationMessage
    {
        public List<string> Messages { get; }
        public bool IsEmpty
        {
            get
            {
                return Messages.Count == 0;
            }
        }

        public ValidationMessage()
        {
            Messages = new List<string>();
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

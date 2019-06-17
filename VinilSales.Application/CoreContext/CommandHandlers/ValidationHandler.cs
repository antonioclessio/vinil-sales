using System.Collections.Generic;
using VinilSales.Application.CoreContext.Interfaces;

namespace VinilSales.Application.CoreContext.CommandHandlers
{
    public class ValidationHandler : IValidationHandler
    {
        public List<string> Messages { get; }
        public bool IsEmpty
        {
            get
            {
                return Messages.Count == 0;
            }
        }

        public ValidationHandler()
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

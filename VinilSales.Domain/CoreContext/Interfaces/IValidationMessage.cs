using System.Collections.Generic;

namespace VinilSales.Domain.CoreContext.Interfaces
{
    public interface IValidationMessage
    {
        bool IsEmpty { get; }
        List<string> Messages { get; }
        void Add(string message);
        void AddRange(List<string> messages);
    }
}

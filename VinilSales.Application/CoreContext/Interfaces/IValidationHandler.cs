using System.Collections.Generic;

namespace VinilSales.Application.CoreContext.Interfaces
{
    public interface IValidationHandler
    {
        bool IsEmpty { get; }
        List<string> Messages { get; }
        void Add(string message);
        void AddRange(List<string> messages);
    }
}

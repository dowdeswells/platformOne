using System.Collections.Generic;

namespace leases.api.Application
{
    public interface IValuesRepository
    {
        IEnumerable<string> GetAll();
    }

    public class ValuesRepository : IValuesRepository
    {
        public IEnumerable<string> GetAll()
        {
            return new[]
            {
                "Value1", "Value2"
            };
        }
    }
}
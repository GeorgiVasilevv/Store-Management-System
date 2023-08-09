
using AutoMapper;

namespace StoreManagementSystem.Core.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}

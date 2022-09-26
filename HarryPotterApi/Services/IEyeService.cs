using Api.Models.Data;

namespace Api.Services
{
    public interface IEyeService
    {
        Task<IEnumerable<Eye>> GetAll();
    }
}

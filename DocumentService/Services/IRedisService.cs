using System.Threading.Tasks;

namespace DocumentService.Services
{
    public interface IRedisService
    {
        Task<T> GetAsync<T>(string key);
        Task<bool> AddAsync<T>(string key, T value);    
    }
}
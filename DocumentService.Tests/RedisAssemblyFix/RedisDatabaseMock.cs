using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Models;

namespace DocumentService.Tests.RedisAssemblyFix
{
    public class RedisDatabaseMock : IRedisDatabase
    {
        public RedisDatabaseMock()
        {
            
        }

        
        //Implemented:
        private readonly Dictionary<string, object> _fastImpl = new();

        public async Task<T> GetAsync<T>(string key, CommandFlags flag = CommandFlags.None)
        {
            return (T)_fastImpl[key];
        }

        public async Task<bool> AddAsync<T>(string key, T value, When when = When.Always, CommandFlags flag = CommandFlags.None, HashSet<string> tags = null)
        {
            //throw new NotImplementedException();
            _fastImpl[key] = value;
            return true;
        }
        
        //Not implemented:
        

        public Task<bool> ExistsAsync(string key, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string key, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<long> RemoveAllAsync(IEnumerable<string> keys, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key, DateTimeOffset expiresAt, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key, TimeSpan expiresIn, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReplaceAsync<T>(string key, T value, When when = When.Always, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync<T>(string key, T value, DateTimeOffset expiresAt, When when = When.Always, CommandFlags flag = CommandFlags.None,
            HashSet<string> tags = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReplaceAsync<T>(string key, T value, DateTimeOffset expiresAt, When when = When.Always, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync<T>(string key, T value, TimeSpan expiresIn, When when = When.Always, CommandFlags flag = CommandFlags.None,
            HashSet<string> tags = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReplaceAsync<T>(string key, T value, TimeSpan expiresIn, When when = When.Always, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys, DateTimeOffset expiresAt)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAllAsync<T>(IList<Tuple<string, T>> items, DateTimeOffset expiresAt, When when = When.Always, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAllAsync<T>(IList<Tuple<string, T>> items, When when = When.Always, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAllAsync<T>(IList<Tuple<string, T>> items, TimeSpan expiresIn, When when = When.Always, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAddAsync<T>(string key, T item, CommandFlags flag = CommandFlags.None) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> SetPopAsync<T>(string key, CommandFlags flag = CommandFlags.None) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SetPopAsync<T>(string key, long count, CommandFlags flag = CommandFlags.None) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetContainsAsync<T>(string key, T item, CommandFlags flag = CommandFlags.None) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<long> SetAddAllAsync<T>(string key, CommandFlags flag = CommandFlags.None, params T[] items) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetRemoveAsync<T>(string key, T item, CommandFlags flag = CommandFlags.None) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<long> SetRemoveAllAsync<T>(string key, CommandFlags flag = CommandFlags.None, params T[] items) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<string[]> SetMemberAsync(string memberName, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SetMembersAsync<T>(string key, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> SearchKeysAsync(string pattern)
        {
            throw new NotImplementedException();
        }

        public Task FlushDbAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(SaveType saveType, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, string>> GetInfoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<InfoDetail>> GetInfoCategorizedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateExpiryAsync(string key, DateTimeOffset expiresAt, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateExpiryAsync(string key, TimeSpan expiresIn, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, bool>> UpdateExpiryAllAsync(string[] keys, DateTimeOffset expiresAt, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, bool>> UpdateExpiryAllAsync(string[] keys, TimeSpan expiresIn, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HashDeleteAsync(string hashKey, string key, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<long> HashDeleteAsync(string hashKey, IEnumerable<string> keys, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HashExistsAsync(string hashKey, string key, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<T> HashGetAsync<T>(string hashKey, string key, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, T>> HashGetAsync<T>(string hashKey, IList<string> keys, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, T>> HashGetAllAsync<T>(string hashKey, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<long> HashIncerementByAsync(string hashKey, string key, long value, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<double> HashIncerementByAsync(string hashKey, string key, double value, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> HashKeysAsync(string hashKey, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<long> HashLengthAsync(string hashKey, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HashSetAsync<T>(string hashKey, string key, T value, bool nx = false, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task HashSetAsync<T>(string hashKey, IDictionary<string, T> values, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> HashValuesAsync<T>(string hashKey, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, T> HashScan<T>(string hashKey, string pattern, int pageSize = 10, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<long> ListAddToLeftAsync<T>(string key, T item, When when = When.Always, CommandFlags flag = CommandFlags.None) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<long> ListAddToLeftAsync<T>(string key, T[] items, CommandFlags flag = CommandFlags.None) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> ListGetFromRightAsync<T>(string key, CommandFlags flag = CommandFlags.None) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<long> PublishAsync<T>(RedisChannel channel, T message, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task SubscribeAsync<T>(RedisChannel channel, Func<T, Task> handler, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task UnsubscribeAsync<T>(RedisChannel channel, Func<T, Task> handler, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task UnsubscribeAllAsync(CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SortedSetAddAsync<T>(string key, T value, double score, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SortedSetRemoveAsync<T>(string key, T value, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SortedSetRangeByScoreAsync<T>(string key, double start = double.NegativeInfinity, double stop = double.PositiveInfinity, Exclude exclude = Exclude.None,
            Order order = Order.Ascending, long skip = 0, long take = -1, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<double> SortedSetAddIncrementAsync<T>(string key, T value, double score, CommandFlags flag = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByTagAsync<T>(string tag, CommandFlags commandFlags = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task<long> RemoveByTagAsync(string tag, CommandFlags flags = CommandFlags.None)
        {
            throw new NotImplementedException();
        }

        public IDatabase Database { get; }
        public ISerializer Serializer { get; }
    }
}
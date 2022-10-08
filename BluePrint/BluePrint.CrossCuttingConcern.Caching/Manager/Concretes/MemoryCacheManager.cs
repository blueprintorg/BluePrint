using BluePrint.CrossCuttingConcern.Caching.Manager.Behaviors;
using BluePrint.DependencyInjection.Container.Providers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BluePrint.CrossCuttingConcern.Caching.Manager.Concretes
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache cache;

        public MemoryCacheManager()
        {
            this.cache = ServiceLocator.ServiceProvider.GetService<IMemoryCache>();
        }
        public T Get<T>(string key)
        {
            return this.cache.Get<T>(key);
        }

        public object Get(string key)
        {
            return this.cache.Get(key);
        }

        public void Add(string key, object data, int duration)
        {
            this.cache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            return this.cache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            this.cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(this.cache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                this.cache.Remove(key);
            }
        }
    }
}

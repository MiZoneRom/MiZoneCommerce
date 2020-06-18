using MCS.Core;
using System;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace MCS.Strategy
{
    public class AspNetCoreCache : ICache
    {
        private static MemoryCache cache;
        static object cacheLocker = new object();

        public AspNetCoreCache()
        {
            cache = new MemoryCache(new MemoryCacheOptions());
        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public T Get<T>(string key)
        {
            return (T)cache.Get(key);
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        public void Insert(string key, object value)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value);
            }
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public void Insert(string key, object value, int cacheTime)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(new TimeSpan(cacheTime)));
            }
        }


        public void Insert(string key, object value, DateTime cacheTime)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(cacheTime - DateTime.Now));
            }
        }

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        public void Remove(string key)
        {
            cache.Remove(key);
        }

        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        public void Clear()
        {
            var l = GetCacheKeys();
            foreach (var s in l)
            {
                Remove(s);
            }
        }

        public void Send(string key, object data)
        {
            return;
        }

        public void Recieve<T>(string key, Core.Cache.DoSub dosub)
        {
            return;
        }

        public void RegisterSubscribe<T>(string key, Core.Cache.DoSub dosub)
        {
            return;
        }

        public void UnRegisterSubscrib(string key)
        {
            return;
        }

        public bool Exists(string key)
        {
            if (cache.Get(key) != null)
                return true;
            else
                return false;
        }

        public void Insert<T>(string key, T value)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value);
            }
        }

        public void Insert<T>(string key, T value, int cacheTime)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(new TimeSpan(cacheTime)));
            }
        }

        public void Insert<T>(string key, T value, DateTime cacheTime)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(cacheTime - DateTime.Now));
            }
        }

        public bool SetNX(string key, string value)
        {
            throw new NotImplementedException();
        }

        public bool SetNX(string key, string value, int cacheTime)
        {
            throw new NotImplementedException();
        }

        public ICacheLocker GetCacheLocker(string key)
        {
            throw new NotImplementedException();
        }

        const int DEFAULT_TMEOUT = 600;//默认超时时间（单位秒）

        private int _timeout = DEFAULT_TMEOUT;

        /// <summary>
        /// 缓存过期时间
        /// </summary>
        /// <value></value>
        public int TimeOut
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value > 0 ? value : DEFAULT_TMEOUT;
            }
        }

        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCacheKeys()
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var entries = cache.GetType().GetField("_entries", flags).GetValue(cache);
            var cacheItems = entries as IDictionary;
            var keys = new List<string>();
            if (cacheItems == null) return keys;
            foreach (DictionaryEntry cacheItem in cacheItems)
            {
                keys.Add(cacheItem.Key.ToString());
            }
            return keys;
        }

    }
}

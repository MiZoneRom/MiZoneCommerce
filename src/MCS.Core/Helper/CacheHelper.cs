using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Core.Helper
{
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Web;


    /// <summary>
    /// 自定义缓存帮助类
    /// </summary>
    public static class CacheHelper
    {
        private static MemoryCache cache;
        static object cacheLocker = new object();

        static CacheHelper()
        {
            cache = new MemoryCache(new MemoryCacheOptions());
        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public static object Get(string key)
        {
            return cache.Get(key);
        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            T result = (T)cache.Get(key);
            return result;
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        public static void Insert(string key, object value)
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
        /// <param name="cacheTime">缓存过期时间(秒)</param>
        public static void Insert(string key, object value, int cacheTime)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(new TimeSpan(cacheTime)));
            }
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public static void Insert(string key, object value, DateTime cacheTime)
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
        public static void Remove(string key)
        {
            cache.Remove(key);
        }

        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        public static void Clear()
        {
            var l = GetCacheKeys();
            foreach (var s in l)
            {
                Remove(s);
            }
        }

        /// <summary>
        /// 缓存是否存在
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if (cache.Get(key) != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        public static void Insert<T>(string key, T value)
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
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="cacheTime">缓存过期时间(秒)</param>
        public static void Insert<T>(string key, T value, int cacheTime)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(new TimeSpan(cacheTime)));
            }
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public static void Insert<T>(string key, T value, DateTime cacheTime)
        {
            lock (cacheLocker)
            {
                if (cache.Get(key) != null)
                    cache.Remove(key);
                cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(cacheTime - DateTime.Now));
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

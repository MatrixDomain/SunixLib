using UnityEngine;
using Sunix.Lib.Models;


namespace Sunix.Lib.Components
{
    public class AssetBundleCache
    {
        //单例对象;
        private static AssetBundleCache self;

        //资源缓存池;
        protected HashList<AssetBundle> pool = new HashList<AssetBundle>();

        /// <summary>
        /// 获取单例;
        /// </summary>
        public static AssetBundleCache instance
        {
            get
            {
                if (self == null)
                    self = new AssetBundleCache();
                return self;
            }
        }

        /// <summary>
        /// 存储资源;
        /// </summary>
        /// <param name="key"></param>
        /// <param name="asset"></param>
        public void saveAsset(string key,AssetBundle asset)
        {
            pool.addElement(key, asset);
        }

        /// <summary>
        /// 获取资源;
        /// </summary>
        /// <returns></returns>
        public AssetBundle getAsset(string key)
        {
            return pool.getElementByKey(key);
        }
    }
}

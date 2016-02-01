using UnityEngine;

//************************************************************************************
//* 命名空间:Sunix.Lib.Components
//* 版本号:V1.0.0.0;
//* 创建人:Sunix(孙伟航);
//* QQ:1569423066;
//* 电子邮箱:1569423066@qq.com
//* 创建时间:2016-01-29;
//* 描述:加载器管理器;
//*************************************************************************************
namespace Sunix.Lib.Components
{
    public class LoaderManager
    {

        //单例对象;
        protected static LoaderManager self;
        //实例创建id;
        protected int instanceCreate = 0;

        /// <summary>
        /// 获取加载管理器单例;
        /// </summary>
        public static LoaderManager instance {
            get {
                if (self == null)
                    self = new LoaderManager();
                return self;
            }
        }

        /// <summary>
        /// 创建加载器;
        /// </summary>
        public Loader createLoader(string name = null)
        {
            GameObject container = new GameObject();
            if (name == null)
                name = createUniqueName();
            container.name = name;
            Loader loader = container.AddComponent<Loader>();
            return loader;
        }

        /// <summary>
        /// 创建唯一名称;
        /// </summary>
        /// <returns></returns>
        public string createUniqueName()
        {
            return "SunixLoader-" + instanceCreate++;
        }

    }
}

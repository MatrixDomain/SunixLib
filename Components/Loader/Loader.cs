using UnityEngine;
using System.Collections;
using Sunix.Lib.Models;


//************************************************************************************
//* 命名空间:Sunix.Lib.Components
//* 版本号:V1.0.0.0;
//* 创建人:Sunix(孙伟航);
//* QQ:1569423066;
//* 电子邮箱:1569423066@qq.com
//* 创建时间:2016-01-26;
//* 描述:功能强大的资源加载器，可以加载任意类型的资源。通过协程提高性能;
//* TODO将资源进行存储、类型处理;
//*************************************************************************************
namespace Sunix.Lib.Components
{
    public class Loader : MonoBehaviour
    {
        //待加载列表;
        public HashList<LoaderData> list = new HashList<LoaderData>();
        //待加载资源总数;
        public float itemTotal = 0;
        //已加载资源数;
        public float itemLoaded = 0;
        //待加载资源总字节大小;
        public float bytesTotal = 0;
        //已加载资源字节大小;
        public float bytesLoaded = 0;
        //加载完成;
        public OnCompleteHandler onCompleteHandler;
        //加载进度;
        public OnProgressHandler onProgressHandler;
        //加载异常;
        public OnErrorHandler onErrorHandler;
        //www加载对象;
        protected WWW www;
        //计时器函数主键;
        protected object timerHandleKey;

        //加载完成委托函数;
        public delegate void OnCompleteHandler(string key);
        //加载进度委托函数;
        public delegate void OnProgressHandler();
        //加载异常委托函数;
        public delegate void OnErrorHandler();

        /// <summary>
        /// 添加待加载对象;
        /// </summary>
        /// <param name="url">资源路径</param>
        /// <param name="key">主键值</param>
        /// <param name="weight">资源大小</param>
        /// <param name="type">资源类型</param>
        public void add(string url, string key = null, float bytes = 0, string type = null)
        {
            LoaderData data = new LoaderData();
            data.url = url;
            data.bytes = bytes != 0 ? bytes : 1;
            data.key = key != null ? key : url;
            data.type = type != null ? type : getType();
            list.addElement(data.key, data);
            itemTotal++;  //总待加载资源数增加;
        }

        /// <summary>
        /// 启动加载;
        /// </summary>
        public void start()
        {
            if (list.count > 0)
                StartCoroutine(run(list.pop()));  //启动协程进行加载;
            else
                throw new System.Exception("There is no item to load!");

        }

        /// <summary>
        /// 已加载资源的百分比;
        /// </summary>
        public float precentLoaded
        {
            get
            {
                return itemLoaded / itemTotal;
            }
        }

        /// <summary>
        /// 已加载资源的字节百分比;
        /// </summary>
        public float bytesPrecent
        {
            get
            {
                return bytesLoaded / bytesTotal;
            }
        }


        /// <summary>
        /// 执行加载;
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IEnumerator run(LoaderData data)
        {
            www = new WWW(data.url);
            timerHandleKey = Timer.instance.doFrameLoop(1, onProgress);
            yield return www;
            onComplete(data);  //执行加载完成函数;
        }


        /// <summary>
        /// 获取待加载资源类型;
        /// </summary>
        /// <returns></returns>
        protected string getType()
        {
            return "";
        }

        /// <summary>
        /// 加载完成;
        /// </summary>
        protected void onComplete(LoaderData data)
        {
            Debug.Log("Complete:" + www.bytesDownloaded);

            Timer.instance.clearTimer(timerHandleKey);  //停止计时器函数;
            AssetBundle bundle = www.assetBundle; //TODO 将assetBunle进行存储;

            itemLoaded++;   //已加载资源个数增加;
            bytesLoaded += data.bytes;   //已加载资源字节数增加;

            if (itemLoaded >= itemTotal)
            {
                if (onCompleteHandler != null)
                    onCompleteHandler(data.key);   //执行外部加载完成回调函数;
            }
            else
                StartCoroutine(run(list.pop()));  //启动协程进行加载;
        }

        /// <summary>
        /// 加载进度事件;
        /// </summary>
        /// <param name="timerData"></param>
        protected void onProgress(TimerData timerData)
        {
            Debug.Log("Progress:" + www.bytesDownloaded);
            if (www.error != null)
            {
                Timer.instance.clearTimer(timerHandleKey);  //停止计时器函数;
                onError(timerData); //执行异常处理函数;
            }
            else
            {
                if (onProgressHandler != null)
                    onProgressHandler();
            }
        }

        /// <summary>
        /// 异常处理;
        /// </summary>
        /// <param name="timerData"></param>
        protected void onError(TimerData timerData)
        {
            Debug.Log("Error:" + www.error);
            if (onErrorHandler != null)
                onErrorHandler();
        }
    }


    /// <summary>
    /// 待加载对象;
    /// </summary>
    public class LoaderData
    {
        public string key;
        public string url;
        public float bytes;
        public string type;
    }
}

using UnityEngine;
using System.Collections;

namespace Sunix.Lib.Interfaces.Observer
{
    /// <summary>
    /// 观察者模式主题接口;
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// 增加观察者;
        /// </summary>
        void addObserver(IObserver observer);

        /// <summary>
        /// 移除观察者;
        /// </summary>
        void removeObserver(IObserver observer);

        /// <summary>
        /// 通知观察者;
        /// </summary>
        void change(object[] param = null);

    }
}

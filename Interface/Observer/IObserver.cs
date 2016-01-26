using UnityEngine;
using System.Collections;


namespace Sunix.Lib.Interfaces
{
    /// <summary>
    /// 观察者模式，观察者接口;
    /// </summary>
    public interface IObserver
    {
        void update(object[] param);
    }
}

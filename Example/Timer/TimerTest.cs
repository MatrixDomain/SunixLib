using UnityEngine;
using Sunix.Lib.Components;

public class TimerTest : MonoBehaviour {


    void Start()
    {
        doOnceByFixSecond();
        doLoopByFixSecond();
        doOnceByFixFrame();
        doLoopByFixFrame();
    }



    /// <summary>
    /// 按照固定间隔的秒数执行一次;
    /// </summary>
    public void doOnceByFixSecond()
    {
        Timer.instance.doOnce(0.05f, printNum, "doOnceByFixSecond-0.05");
    }

    /// <summary>
    /// 按照固定间隔的秒数循环执行;
    /// </summary>
    public void doLoopByFixSecond()
    {
        Timer.instance.doLoop(1f, countNum, 1);
    }

    /// <summary>
    /// 按照固定间隔的帧数执行一次;
    /// </summary>
    public void doOnceByFixFrame()
    {
        Timer.instance.doFrameOnce(1, printNum, "doOnceByFixFrame-1");
    }

    /// <summary>
    /// 按照固定间隔的帧数循环执行;
    /// </summary>
    public void doLoopByFixFrame()
    {
        Timer.instance.doFrameLoop(4, countNum, 4);
    }


    /// <summary>
    /// 回调函数
    /// </summary>
    /// <param name="value">计时器回调数据</param>
    protected void printNum(TimerData value)
    {
        //打印参数;
        Debug.Log(value.args);
    }

    /// <summary>
    /// 计算数值;
    /// </summary>
    /// <param name="value"></param>
    protected void countNum(TimerData value)
    {
        int result = 20 * (int)value.args;
        Debug.Log("do loop result:" + result);

    }
}

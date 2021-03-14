using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADtest;

namespace ADtest
{
    /// <summary>
    /// Recorder基类，规定用于记录数据的对象的交互方式
    /// </summary>
    public class BaseRecorder : MonoBehaviour
    {
        /// <summary>
        /// 用于数据记录的虚方法，传入json数组，由每一种Recorder重写各自的逻辑来实现数据记录
        /// </summary>
        /// <param name="data"></param>
        public virtual void dataRecord(JSONObject data){}
    }
}


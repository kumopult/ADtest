using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADtest;

namespace ADtest
{
    public class SelectRecorder : BaseRecorder
    //所有记录器不直接继承MonoBehaviour，而是继承BaseRecorder类
    {
        private string value;

        private void OnEnable() {
            value = "对象被唤醒时会触发这个OnEnable周期，建议监视器中需要初始化操作都在这处理";
        }

        public void setValue(string v){
            value = v;
        }

        public override void dataRecord(JSONObject data){
            print("写入数据：" + value);
            data.AddField("test value", value);
        }
    }
}
    

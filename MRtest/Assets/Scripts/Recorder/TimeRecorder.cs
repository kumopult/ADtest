using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADtest;

namespace ADtest
{
    public class TimeRecorder : BaseRecorder
    {
        float recordTime;
        // 用一个json数组记录分段的时间
        JSONObject times;

        void OnEnable()
        {
            times = new JSONObject(JSONObject.Type.ARRAY);
            recordTime = 0;
        }

        // Update is called once per frame
        void Update()
        {
            recordTime += Time.deltaTime;
        }

        /// <summary>
        /// 用于阶段性计时，比如在某个关卡中有三步操作，那就可以在每一步操作完成时调用这个
        /// </summary>
        public void TimeRecord(){
            times.Add(recordTime);
            recordTime = 0;
        }

        public override void dataRecord(JSONObject data){
            if(times.Count > 0){
                // 如果记录了多段时间，就把时间数组给整个塞进去
                print("记录通关时间：" + times);
                data["levelClearTime"].Add(times);
            }else{
                print("记录通关时间：" + recordTime);
                data["levelClearTime"].Add(recordTime);
            }
        }

    }
}
    

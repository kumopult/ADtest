using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADtest;

namespace ADtest
{
    public class TimeRecorder : BaseRecorder
    {
        float recordTime;

        void OnEnable()
        {
            recordTime = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            recordTime += Time.deltaTime;
        }

        public override void dataRecord(JSONObject data){
            Debug.Log("记录通关时间：" + recordTime);
            data["levelClearTime"].Add(recordTime);
            recordTime = 0f;
        }

    }
}
    

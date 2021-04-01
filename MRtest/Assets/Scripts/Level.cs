using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADtest;

namespace ADtest
{
    public class Level : MonoBehaviour
    {
        // 关卡对象就俩功能，首先是用一个List记录该关卡中要使用的Recorder
        public List<BaseRecorder> recorders;

        // 然后是关卡完成时调用这个函数，把数据记录下来，然后喊GameController切到下一关
        public void levelClear(){
            foreach(BaseRecorder recorder in recorders){
                recorder.dataRecord(GameController.Instance.data);
            }
            GameController.Instance.NextLevel();
            // 一个关卡结束后要不要把自己给关掉？这个还不太确定。
            this.gameObject.SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.UI;
using ADtest;

/// <summary>
/// 监听目标物体被拿起后松开手的事件
/// 如果松开时在自身的一定范围内就会触发自身的事件
/// </summary>
namespace ADtest
{
    public class ObjectDistanceTrigger : MonoBehaviour
    {
        public Transform triggerObject;
        public float triggerDistance;

        // UnityEvent可以在Inspector面板中可视化编辑该事件被Invoke时触发哪些函数，很方便
        public UnityEvent OnDistanceTrigger;

        // MRTK中用于让物体变得可以抓取的那个ObjectManipulator组件，它上面有一系列的触发事件，比如开始/结束抓取
        // 通过AddListener来添加监听，就可以随着事件而调用这里的触发函数，检测距离来触发事件
        private void OnEnable() {
            triggerObject.gameObject.GetComponent<ObjectManipulator>().OnManipulationEnded.AddListener(DistanceTrigger);
        }

        private void OnDisable() {
            triggerObject.gameObject.GetComponent<ObjectManipulator>().OnManipulationEnded.RemoveListener(DistanceTrigger);
        }

        public void DistanceTrigger(ManipulationEventData m){
            if(Vector3.Distance(this.transform.position, triggerObject.position) < triggerDistance){
                OnDistanceTrigger.Invoke();
            }
        }
    }

    [CustomEditor(typeof(ObjectDistanceTrigger))]
    public class ObjectDistanceTriggerEditor : Editor
    {
        // 绘制可视化的GUI，方便编辑
        private void OnSceneGUI() {
            var t = target as ObjectDistanceTrigger;
            Handles.DrawWireDisc(t.transform.position, t.transform.up, t.triggerDistance);
            Handles.DrawWireDisc(t.transform.position, t.transform.right, t.triggerDistance);
            Handles.DrawWireDisc(t.transform.position, t.transform.forward, t.triggerDistance);
            if(t.triggerObject){
                Handles.DrawLine(t.transform.position, t.triggerObject.position);
            }
        }
    }
}

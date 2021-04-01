using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using ADtest;

namespace ADtest
{
    public class GameController : MonoBehaviour
    {
        // 借鉴了半个单例模式，在任何ADtest命名空间下的脚本都可以用GameController.Instance来直接访问本对象
        public static GameController Instance{get; private set;}
        public List<Level> levels;
        public int currentLevel;
        public JSONObject data;

        void Start()
        {
            Instance = this;

            // 加载json模板
            TextAsset template = Resources.Load("template") as TextAsset;
            data = new JSONObject(template.text);

            // 初始化关卡
            foreach(Level l in levels){
                l.gameObject.SetActive(false);
            }
            currentLevel = 0;
            NextLevel();
        }


        public void NextLevel(){
            // 切换至下一关卡，具体来说就是把关卡列表中下一个对象激活
            if(currentLevel < levels.Count){
                levels[currentLevel].gameObject.SetActive(true);
                currentLevel += 1;
            }else{
                Save();
            }
        }

        void Save(){
            // 顾名思义就是把记录的json数组保持成文件了
            string savetext = data.ToString();
            string filename = System.DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
            string savepath = Application.persistentDataPath + "/" + filename + ".json";
            File.Create(savepath).Dispose();
            StreamWriter writer = new StreamWriter(savepath);
            writer.Write(savetext);
            writer.Close();
            writer.Dispose();

            print("结果已保存");
            print(data.ToString());
        }
    }
}

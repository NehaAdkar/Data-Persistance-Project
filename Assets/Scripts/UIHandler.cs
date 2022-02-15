using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{
    
    public TextMeshProUGUI NameText;
    public static UIHandler Instance;
        private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        Instance=this;
        DontDestroyOnLoad(gameObject);
        LoadScoreData();
    }


    public void ClickStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

     [System.Serializable]
class SaveData
{
    public TextMeshProUGUI NameText;
}

    public void SaveScoreData()
    {
        SaveData data=new SaveData();
        data.NameText=NameText;

        string json=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath+ "/savefile1.json",json);
    }

    public void LoadScoreData()
    {
        string path=Application.persistentDataPath+ "/savefile1.json";
        if(File.Exists(path))
        {
            string json=File.ReadAllText(path);
            SaveData data=JsonUtility.FromJson<SaveData>(json);

            NameText=data.NameText;
        }
    }

 
}

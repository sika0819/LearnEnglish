using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Sika.JsonObject;
using Newtonsoft.Json;
using System.Collections.Generic;
public class ReadJson : MonoBehaviour
{
    [SerializeField]
    Sika.JsonObject.ProductInfo jsonFile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ReadJsonFile("data.json"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator ReadJsonFile(string fileName){
        string filePath = Utils.GetFilePath();
        Debug.Log(filePath+"/"+fileName);
        UnityWebRequest www = UnityWebRequest.Get(filePath+"/"+fileName);
        yield return www.SendWebRequest();
      
        if(www.result != UnityWebRequest.Result.Success){
            Debug.LogError(www.error);
        }else{
            string text = www.downloadHandler.text;
            text = text.TrimStart('[');
            text = text.TrimEnd(']');
            jsonFile = DeSerialize<ProductInfo>(text);
            ActivityInfo activity = jsonFile.Activity;
            GameManager.Instance.GetGameLogic().InitGame(activity);
        }
    }
    public static string Serialize<T>(T t)
    {
        return JsonConvert.SerializeObject(t);
    }
 
    public static T DeSerialize <T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}

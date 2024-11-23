using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;
public class HttpDownloadHelper : MonoBehaviour
{
    public  IEnumerator DownloadFromUrl(string url){
        string suffix = Utils.GetFileSuffix(url);
        string fileName = Utils.GetFileName(url);
        fileName = fileName+suffix; 
        string filePath = Application.streamingAssetsPath;
            //using different filePath on different platform
#if UNITY_ANDROID
        filePath = "jar:file://" + Application.dataPath + "!/assets";
#elif UNITY_IOS
        filePath = Application.dataPath + "/Raw";
#endif 

#if UNITY_EDITOR
        filePath = Application.streamingAssetsPath;
#endif
        fileName = filePath+"/"+fileName;

        if(File.Exists(fileName)){//本地已有同名资源
            Debug.LogFormat("{0} is exists do not need download!",fileName);
            yield return null;
        }else{
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
        
            if(www.result != UnityWebRequest.Result.Success){
                Debug.LogError(www.error);
            }else{
                byte[] results=www.downloadHandler.data;
                Debug.LogFormat("{0} is downloaded success from {1}!",fileName,url);
                SaveBinaryFile(fileName,suffix,results);
            }
        }
       
    }
    //save image or audio in android file
    public bool SaveBinaryFile(string fileName,string suffix,byte[] bytes){
        try{
            File.WriteAllBytes(fileName, bytes);
            return true;
        }catch(Exception ex){
            Debug.LogError(ex);
            return false;
        }
    }
}

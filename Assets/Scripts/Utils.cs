using UnityEngine;

public class Utils 
{
    public static string GetFileSuffix(string fileName){
        return fileName.Substring(fileName.LastIndexOf("."));
    }
    public static string GetFileName(string url){
        string temp = url.Substring(0,url.LastIndexOf("/"));
        return temp.Substring(temp.LastIndexOf("/")).Replace("/","");
    }
    public static string GetFilePath(){
        string filePath = "file://"+Application.streamingAssetsPath;
            //using different filePath on different platform
#if UNITY_ANDROID
        filePath = "jar:file://" + Application.dataPath + "!/assets";
#elif UNITY_IOS
        filePath = "file://"+Application.dataPath + "/Raw";
#endif 

#if UNITY_EDITOR
        filePath = "file://"+ Application.streamingAssetsPath;
#endif
        return filePath;
    }
}

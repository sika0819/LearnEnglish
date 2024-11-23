using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
public class FileLoader : MonoBehaviour
{
    public IEnumerator LoadTexture(string url,Image img){
        string fileName = Utils.GetFileName(url)+ Utils.GetFileSuffix(url);
        fileName = Utils.GetFilePath()+"/"+fileName;
        Debug.Log(fileName);
        UnityWebRequest wr = new UnityWebRequest(url);
        DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
        wr.downloadHandler = texDl;
        yield return wr.SendWebRequest();
        if (wr.result == UnityWebRequest.Result.Success) {
            Texture2D t = texDl.texture;
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height),
                Vector2.zero, 1f);
            img.sprite = s;
            img.enabled = true;
        }
    }
}

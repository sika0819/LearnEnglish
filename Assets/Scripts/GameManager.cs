using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    HttpDownloadHelper httpDownloader;
    GameLogic gameLogic;
    FileLoader fileLoader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        httpDownloader = GetComponent<HttpDownloadHelper>();
        gameLogic =  GetComponent<GameLogic>();
        fileLoader = GetComponent<FileLoader>();
        //StartCoroutine(httpDownloader.DownloadFromUrl("https://s3.cn-north-1.amazonaws.com.cn/storyblok-cdn.ef.com.cn/f/261/9fdea340db/hfj6-010-tower.png"));
    }

    public HttpDownloadHelper GetDownloader(){
        return httpDownloader;
    }
    public GameLogic GetGameLogic(){
        return gameLogic;
    }
    public FileLoader GetFileLoader(){
         return fileLoader;
    }
}

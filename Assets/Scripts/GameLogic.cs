using UnityEngine;
using Sika.JsonObject;
using System.Collections.Generic;
using System;
using System.Collections;
[Serializable]
public class GameLogic : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject itemBg;
    public GameObject itemPrefab;
    [SerializeField]
    ActivityInfo activityInfo;
    public RectTransform panel;
    public int row;
    public int col;
    public int gameIndex;//当前课程
    int clickTimes = 0;
    SelectId preSelected = null;
    public List<int> answer = new List<int>();
    public List<int> rightAnswer = new List<int>();
    public int errorTime;
    
    public void InitGame(ActivityInfo info){
        activityInfo = info;
        List<StimulusItem> stimulus = info.Stimulus;
        for(int i=0;i<stimulus.Count;i++){
            Sika.JsonObject.Audio audio = stimulus[i].Body.item.audio;
            StartCoroutine(GameManager.Instance.GetDownloader().DownloadFromUrl(audio.url));
        }
        List<QuestionsItem> question = info.Questions;
   
        for(int i=0;i<question.Count;i++){
            List<OptionsItem> options = question[i].Body.options;
            for(int j =0;j<options.Count;j++){
                Sika.JsonObject.Image image = options[j].image;
                StartCoroutine(GameManager.Instance.GetDownloader().DownloadFromUrl(image.url));
            }    
        }
        GenerateUI(gameIndex);
    }
    List<Clickable> clickList = new List<Clickable>();
    public void GenerateUI(int index){
    
        if(index>=0 && index< activityInfo.Questions.Count)
        { 
            QuestionsItem question =activityInfo.Questions[index];
            Debug.Log(answer.Count);
            List<TagsItem> tagsList= question.Body.tags;
            List<GameObject> goList = new List<GameObject>();
            Debug.Log(tagsList.Count);
            if(tagsList.Count>0){
                row = tagsList[0].rows;
                col =tagsList[0].cols;
                for(int i =0;i<row;i++){
                    for(int j=0;j<col;j++){
                       GameObject bgGo = GameObject.Instantiate(itemBg,panel.transform);
                       bgGo.SetActive(true);
                       goList.Add(bgGo);
                    //    GameObject.Instantiate(itemPrefab,bgGo.transform);
                    }
                }
            }
            List<OptionsItem> options = question.Body.options;
            List<List<int>> answersList = question.Body.answers;
            if(answersList.Count>0){
                rightAnswer = answersList[0];
            }
            for(int j =0;j<options.Count;j++){
                OptionsItem optionsItem = options[j];
                Sika.JsonObject.Image image = optionsItem.image;
                GameObject go = GameObject.Instantiate(itemPrefab,goList[j].transform);
                go.name = ""+j;
                UnityEngine.UI.Image goImage = go.transform.Find("itemSprite").GetComponent<UnityEngine.UI.Image>();
                goImage.enabled = false;
                string fileName = Utils.GetFileName(image.url);
                Texture2D t = Resources.Load<Texture2D>("res/"+fileName);
                Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height),Vector2.zero, 1f);
                goImage.sprite = s;
                goImage.enabled = true;
                Clickable clickable = go.GetComponentInChildren<Clickable>();
                clickable.onClickAction += OnClick;
                clickable.selectId.imageIndex = j;
                clickable.selectId.row = optionsItem.rowIndex;
                clickable.selectId.col = optionsItem.colIndex;
                clickList.Add(clickable);
                //StartCoroutine(GameManager.Instance.GetFileLoader().LoadTexture(image.url,goImage));
            }
        }
    }

    void OnClick(GameObject go){
        clickTimes++;
        Clickable clickable = go.GetComponentInChildren<Clickable>();
        Check(clickable);
    }
    void Check(Clickable clickable){
        SelectId selectId = clickable.SelectItem();
        answer.Add(selectId.imageIndex);
        if(preSelected!=null){
            if(Mathf.Abs(selectId.row - preSelected.row)>1
            ||Mathf.Abs(selectId.col - preSelected.col)>1){
                DelectedAll();
            }
        }
        preSelected = selectId;
        bool isConrrect = CheckRightAnswer(clickable);
        if(clickTimes >= rightAnswer.Count){
            clickTimes = 0;
            if(!isConrrect){
                DelectedAll();
            }else{
                Debug.Log("Game Success!");
            }
        }
    }
    public bool CheckRightAnswer(Clickable clickable){
        bool isConrrect = true;
        if(rightAnswer.Count < answer.Count){
            isConrrect = false;
            DelectedAll();
            return isConrrect;
        }
        for(int i=0;i<answer.Count;i++){
            if(answer[i] != rightAnswer[i]){
               isConrrect = false;
               DelectedAll();
            }
        }
        return isConrrect;
    }
    public void DelectedAll(){
        clickTimes = 0;
        for(int i =0;i<clickList.Count;i++){
            clickList[i].DeSelected();
        }
        preSelected = null;
        answer.Clear();
        errorTime++;
        if(errorTime > 2){
            ShowRightAnswer();
            errorTime = 0;
        }
    }
    public void ShowRightAnswer(){
        for(int i =0;i< rightAnswer.Count;i++){
            for(int j =0;j< clickList.Count;j++){
                if(clickList[j].selectId.imageIndex == rightAnswer[i]){
                    clickList[j].SelectItem();
                }
            }
        }
    }
}

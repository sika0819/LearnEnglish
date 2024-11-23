using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Collections;
[Serializable]
public class SelectId{
  public int imageIndex;
  public int row;
  public int col;
}
public class Clickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    Image image;
    public Material outlineMat;
    public Image selected;
    Shadow shadow;
     [SerializeField]
    public SelectId selectId;
    public Action<GameObject> onClickAction;
    void Awake(){
        image = GetComponent<Image>();
        shadow = GetComponent<Shadow>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick:" + eventData.ToString());
        onClickAction(gameObject);
    }
 
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown:" + eventData.ToString());
        shadow.enabled = false;
        image.material = outlineMat;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp:" + eventData.ToString());
        shadow.enabled = true;
        image.material = null;
    }
    public SelectId SelectItem(){
      
        selected.enabled = true;
        selected.material.SetFloat("_DissolveThreshold",0);
        return selectId;
    }
    float timer = 0;
    bool startAnim = false;
    void Update(){
        if(startAnim){
            timer += Time.deltaTime;
            if(timer>1){
                startAnim = false;
                timer = 1;
            }
            float percent = timer/1;
            selected.material.SetFloat("_DissolveThreshold",percent);
        }
    }
    public IEnumerator DoDissolveAnim(){
        yield return new WaitForSeconds(1);
        selected.enabled = false;
       
    }
    public void DeSelected(){
        timer = 0;
        startAnim = true;
        StartCoroutine(DoDissolveAnim());
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public RoundCount roundCounter;
    public int numBaskets=4;
    public float basketBottomY=-14f;
    public float basketSpacingY=2f;
    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        GameObject roundGO = GameObject.Find("RoundCount");
        roundCounter=roundGO.GetComponent<RoundCount>();
        roundCounter.currentRound+=1;

        basketList= new List<GameObject>();
        for(int i=0;i<numBaskets;++i){
            GameObject tBasketGO=Instantiate<GameObject>(basketPrefab);
            Vector3 pos=Vector3.zero;
            pos.y=basketBottomY+(basketSpacingY*i);
            tBasketGO.transform.position=pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed(){
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tempGO in appleArray){
            Destroy(tempGO);
        }
        //destroy basket
        int basketIndex = basketList.Count-1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
        roundCounter.currentRound+=1; //updates round counter when box is deleted

        if(basketList.Count==0){
            SceneManager.LoadScene("GameOver_Screen"); //game over
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

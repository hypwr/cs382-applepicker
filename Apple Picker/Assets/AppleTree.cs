using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject evilBranchPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public float evilBranchDropChance = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple",2f);
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        if(Random.value > evilBranchDropChance){
            Invoke("DropApple",appleDropDelay);
        }else{
            Invoke("DropEvilBranch",appleDropDelay);
        }
    }
    void DropEvilBranch(){
        GameObject evilBranch = Instantiate<GameObject>(evilBranchPrefab);
        evilBranch.transform.position = transform.position;
        if(Random.value > evilBranchDropChance){
            Invoke("DropApple",appleDropDelay);
        }else{
            Invoke("DropEvilBranch",appleDropDelay);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //dir change
        if(pos.x<-leftAndRightEdge){
            speed=Mathf.Abs(speed);
        } else if (pos.x>leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        //} else if (Random.value < changeDirChance){
        //    speed *= -1;
        }
    }

    void FixedUpdate(){
        if(Random.value < changeDirChance){
            speed *= -1;
            }
    }
}

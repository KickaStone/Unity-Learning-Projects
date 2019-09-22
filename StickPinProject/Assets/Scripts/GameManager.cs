using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Transform startPoint;
    private Transform spawnPoint;
    private Pin currentPin;

    public GameObject pinPrefab;
	// Use this for initialization
	void Start () {
        startPoint = GameObject.Find("StartPoint").transform;
        spawnPoint = GameObject.Find("SpawnPoint").transform;

        SpawnPin();//调用方法
	    	
	}

    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {   
            currentPin.StartFly();
        }
        
    }
	
    void SpawnPin()//生成针的方法
    {
        currentPin = GameObject.Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();//生成gameobject 注意旋转使用Pin的旋转值
    }



}

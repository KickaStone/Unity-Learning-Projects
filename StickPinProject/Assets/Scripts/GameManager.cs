using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Transform startPoint;
    private Transform spawnPoint;

    public GameObject pinPrefab;
	// Use this for initialization
	void Start () {
        startPoint = GameObject.Find("StartPoint").transform;
        spawnPoint = GameObject.Find("SpawnPoint").transform;

        SpawnPin();//调用方法
	    	
	}
	
    void SpawnPin()//生成针的方法
    {
        GameObject.Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation);//生成gameobject 注意旋转使用Pin的旋转值
    }

}

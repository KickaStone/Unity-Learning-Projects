using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private Transform startPoint;
    private Transform spawnPoint;
    private Pin currentPin;
    private int score = 0;//控制分数
    public Text scoreText;//分数显示框

    private Camera mainCamera;//主摄像机

    private bool isGameOver = false;//确保GameOver只会被调用一次
    public GameObject pinPrefab;
    public float speed = 3;//颜色变化速度

	// Use this for initialization
	void Start () {
        //获取startPoint和spawnPoint的位置
        startPoint = GameObject.Find("StartPoint").transform;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        mainCamera = Camera.main;
        SpawnPin();//生成针
	    	
	}

    private void Update() {
        if(isGameOver) return;
        if(Input.GetMouseButtonDown(0))//鼠标左键点击事件响应
        {   
            score++;//分数增加
            scoreText.text = score.ToString();//分数显示
            currentPin.StartFly();//让针飞行
            SpawnPin();//前一个针开始插的时候，生成新的针
        }
        
    }
	
    void SpawnPin()//生成针的方法
    {
        currentPin = GameObject.Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();//生成gameobject 注意旋转使用Pin的旋转值
    }

    public void GameOver(){

        if(isGameOver)
            return;
        GameObject.Find("Circle").GetComponent<RotateSelf>().enabled = false;//让小球停止旋转
        StartCoroutine(GameOverAnimation());

        isGameOver = true;
    }

    IEnumerator GameOverAnimation()
    {
        while(true)
        {
            //颜色渐变（开始颜色 目标颜色 速度）
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4, speed* Time.deltaTime);
            if(Mathf.Abs(mainCamera.orthographicSize - 4) < 0.01f)
            {
                break;
            }
            yield return 0;
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);//重新加载场景
    }

}

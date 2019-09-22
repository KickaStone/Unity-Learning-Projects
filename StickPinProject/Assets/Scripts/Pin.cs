using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    private float speed = 5;//speed
    private bool isFly = false; //to circle
    private bool isReach = false;//to startPoint
    private Transform startPoint;
	private Transform circle;


    // Use this for initialization
    void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform;
		//circle = GameObject.FindGameObjectWithTag("Circle").transform;
        circle = GameObject.Find("Circle").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFly == false)
        {
            if (isReach == false)
            {//创建后运动到startPoint
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);//运动
                if (Vector3.Distance(transform.position, startPoint.position) < 0.05f)
					isReach = true;//优化
            }


        }
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, circle.position, speed * Time.deltaTime);//运动
		}
    }

	public void StartFly()
	{
		isFly = true;
		isReach = true;

	}
}

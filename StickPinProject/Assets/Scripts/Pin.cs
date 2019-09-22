using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private float speed = 15;//speed
    private bool isFly = false; //to circle
    private bool isReach = false;//to startPoint
    private Transform startPoint;//插针前针的位置
    private Vector3 tragetCirclePos;//针实际插到的位置
    private Transform circle;//Circle的位置


    // Use this for initialization
    void Start()
    {
        //获取startPoint的位置
        startPoint = GameObject.Find("StartPoint").transform;
        //circle = GameObject.FindGameObjectWithTag("Circle").transform;
        circle = GameObject.Find("Circle").transform;
        tragetCirclePos = circle.position;
        tragetCirclePos.y -= 1.45f;//让针插到Circle的边上
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
            //针插到Circle上的运动
            transform.position = Vector3.MoveTowards(transform.position, tragetCirclePos, speed * Time.deltaTime);//运动
            //距离判定 
            if (Vector3.Distance(transform.position, tragetCirclePos) < 0.05f)
            {
                transform.position = tragetCirclePos;//为了对齐所有的针
                transform.parent = circle;//设置变换父对象，让针和Circle一起旋转
                isFly = false;//状态修改
            }
        }
    }

    public void StartFly()//开始飞行
    {
        isFly = true;
        isReach = true;
    }
}

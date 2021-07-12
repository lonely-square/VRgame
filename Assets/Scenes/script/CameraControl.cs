using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //相机移动参数
    public float xOffset = 0;
    public float yOffset = 0;
    public float turnRSpeed = 2;       //水平移动
    public float turnUSpeed = 2;        //上下移动

    public GameObject playerObj;
    public GameObject cameraObj;

    //游戏刚开始时防止拖拽镜头会挪超出预期的角度
    bool isRotate = false;
    public float invokeTime = 2;

    public float cameraAngleLimit = 30;
    public float currentEluerAngle_X;


    //摄像机前进后退的速率
    public float view_value = 20f;
    public float maximum = 100;
    public float minmum = 30;
    //滚轮实现镜头缩进和拉远的范围
    public float sensitivetyMouseWheel = 10f;
    //控制摄像机移动的速率
    public float move_speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //延迟两秒使用镜头拖拽移动
        Invoke("SetIsRotate", invokeTime);
    }

    // Update is called once per frame
    void Update()
    {
        TurnCamera();
        ScrollView();
    }

    void SetIsRotate()
    {
        isRotate = true;
    }

    //相机转动移动逻辑
    void TurnCamera()
    {
        if (isRotate)
        {
            //用鼠标控制相机的转向,后期移植到手机端时将输入变成手指的移动
            xOffset = Input.GetAxis("Mouse X");
            yOffset = Input.GetAxis("Mouse Y");

            //鼠标左键实现相机上下左右拖拽功能
            if (cameraObj != null  && playerObj!=null)
            {
                if (Input.GetMouseButton(0))
                {
                    playerObj.transform.Rotate(0, xOffset * turnRSpeed, 0);
                    cameraObj.transform.Rotate(-yOffset * turnUSpeed, 0, 0);
                }

                //限制上下角度
                //欧拉角获取的角度为0~360
                currentEluerAngle_X = cameraObj.transform.localEulerAngles.x;
                if (currentEluerAngle_X <= 180 && currentEluerAngle_X > cameraAngleLimit) 
                {
                    currentEluerAngle_X = cameraAngleLimit;
                    cameraObj.transform.localEulerAngles = new Vector3(currentEluerAngle_X, cameraObj.transform.localEulerAngles.y, cameraObj.transform.localEulerAngles.z);
                   // playerObj.transform.localEulerAngles = new Vector3(currentEluerAngle_X, playerObj.transform.localEulerAngles.y, cameraObj.transform.localEulerAngles.z);

                }
                if(currentEluerAngle_X > 180 && currentEluerAngle_X < 360 - cameraAngleLimit)
                {
                    currentEluerAngle_X = 360 -  cameraAngleLimit;
                    cameraObj.transform.localEulerAngles = new Vector3(currentEluerAngle_X, cameraObj.transform.localEulerAngles.y, cameraObj.transform.localEulerAngles.z);
                   // playerObj.transform.localEulerAngles = new Vector3(currentEluerAngle_X, playerObj.transform.localEulerAngles.y, playerObj.transform.localEulerAngles.z);
                }

            }

        }
    }

    //滑轮滚动控制视野放大缩小
    void ScrollView()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minmum, maximum);
            Camera.main.fieldOfView = Camera.main.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * view_value;

        }
    }
}


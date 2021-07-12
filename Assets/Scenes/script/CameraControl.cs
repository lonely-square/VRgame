using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //����ƶ�����
    public float xOffset = 0;
    public float yOffset = 0;
    public float turnRSpeed = 2;       //ˮƽ�ƶ�
    public float turnUSpeed = 2;        //�����ƶ�

    public GameObject playerObj;
    public GameObject cameraObj;

    //��Ϸ�տ�ʼʱ��ֹ��ק��ͷ��Ų����Ԥ�ڵĽǶ�
    bool isRotate = false;
    public float invokeTime = 2;

    public float cameraAngleLimit = 30;
    public float currentEluerAngle_X;


    //�����ǰ�����˵�����
    public float view_value = 20f;
    public float maximum = 100;
    public float minmum = 30;
    //����ʵ�־�ͷ��������Զ�ķ�Χ
    public float sensitivetyMouseWheel = 10f;
    //����������ƶ�������
    public float move_speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //�ӳ�����ʹ�þ�ͷ��ק�ƶ�
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

    //���ת���ƶ��߼�
    void TurnCamera()
    {
        if (isRotate)
        {
            //�������������ת��,������ֲ���ֻ���ʱ����������ָ���ƶ�
            xOffset = Input.GetAxis("Mouse X");
            yOffset = Input.GetAxis("Mouse Y");

            //������ʵ���������������ק����
            if (cameraObj != null  && playerObj!=null)
            {
                if (Input.GetMouseButton(0))
                {
                    playerObj.transform.Rotate(0, xOffset * turnRSpeed, 0);
                    cameraObj.transform.Rotate(-yOffset * turnUSpeed, 0, 0);
                }

                //�������½Ƕ�
                //ŷ���ǻ�ȡ�ĽǶ�Ϊ0~360
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

    //���ֹ���������Ұ�Ŵ���С
    void ScrollView()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minmum, maximum);
            Camera.main.fieldOfView = Camera.main.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * view_value;

        }
    }
}


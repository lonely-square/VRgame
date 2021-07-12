using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //���ƵĶ���playercc
    public CharacterController playercc;

    //�ƶ�����
    public Vector3 moveMotion = Vector3.zero;
    public float h_value = 0;
    public float v_value = 0;
    public bool e_value = false;                   //����
    public bool q_value = false;                   //�½�


    //�ٶ� 
    public float fowardSpeed = 1f;          //�ƶ��ٶ�
    public float turnSpeed = 1f;            //ת���ٶ�
    public float upSpeed = 1f;              //�����ٶ�

    //���ﶶ����أ�ʵ�ֵ����������µ��ƶ���
    public bool isZeroGravity;
    public float shakeAmount = 3f;
    float shakeTime = 5f;
    float i;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalk();
        playerShake();
    }
    void PlayerWalk()
    {
        //�Ӽ��̻�ȡ�ƶ������������ң�������ֲ���ƶ���ʱ������joystick�Ĳ���
        h_value = Input.GetAxis("Horizontal");
        v_value = Input.GetAxis("Vertical");

        Vector3 upMov = new Vector3(0, 0, 0);

        if(Input.GetKey(KeyCode.Q))
        {
            upMov = -playercc.transform.up * upSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            upMov = playercc.transform.up * upSpeed * Time.deltaTime;
        }

        Vector3 forwardMov = playercc.transform.forward * v_value * fowardSpeed * Time.deltaTime;
        Vector3 turnMov = playercc.transform.right * h_value * turnSpeed * Time.deltaTime;

        moveMotion = forwardMov + turnMov + upMov;
        playercc.Move(moveMotion);
    }

    void MainShake()
    {
        //playercc.transform.localPosition = new Vector3(playercc.transform.localPosition.x, shakeAmount * Time.deltaTime + playercc.transform.localPosition.y, playercc.transform.localPosition.z);
        playercc.transform.localEulerAngles = new Vector3(shakeAmount * Time.deltaTime + playercc.transform.localEulerAngles.x, playercc.transform.localEulerAngles.y, playercc.transform.localEulerAngles.z);
        shakeAmount *= -1;
    }

    void timeChange()
    {
        i = 0;
    }

    void playerShake()
    {
        if (isZeroGravity)
        {
            if (i > shakeTime)
            {
                MainShake();
                Invoke("timeChange", 1f);
            }
            i += Time.deltaTime;
        }
    }
}

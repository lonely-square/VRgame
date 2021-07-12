using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //控制的对象playercc
    public CharacterController playercc;

    //移动参数
    public Vector3 moveMotion = Vector3.zero;
    public float h_value = 0;
    public float v_value = 0;
    public bool e_value = false;                   //上升
    public bool q_value = false;                   //下降


    //速度 
    public float fowardSpeed = 1f;          //移动速度
    public float turnSpeed = 1f;            //转身速度
    public float upSpeed = 1f;              //上升速度

    //人物抖动相关（实现低重力环境下的移动）
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
        //从键盘获取移动方向：上下左右，后期移植到移动端时更换给joystick的参数
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public Animator left_Ani;
    public Animator right_Ani;
    public Animator down_Ani;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_OpenDoor()
    {
        if (left_Ani == null || right_Ani == null) return;
        left_Ani.SetBool("IsOpen",true);
        right_Ani.SetBool("IsOpen", true);
        down_Ani.SetBool("IsOpen", true);

    }

    public void OnClick_CloseDoor()
    {
        if (left_Ani == null || right_Ani == null) return;
        left_Ani.SetBool("IsOpen", false);
        right_Ani.SetBool("IsOpen", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    public Animator left_Ani;
    public Animator right_Ani;
    public Animator down_Ani;

    public GameObject Camera;

    // Start is called before the first frame update


    void LoadMainScene()
    {
        SceneManager.LoadScene("TianHe/TianHe");
    }

    public void OnClick_OpenDoor()
    {
        if (left_Ani == null || right_Ani == null) return;
        left_Ani.SetBool("IsOpen",true);
        right_Ani.SetBool("IsOpen", true);
        down_Ani.SetBool("IsOpen", true);
        Invoke("LoadMainScene", 2.5f);

    }



    public void OnClick_CloseDoor()
    {
        if (left_Ani == null || right_Ani == null) return;
        left_Ani.SetBool("IsOpen", false);
        right_Ani.SetBool("IsOpen", false);
        down_Ani.SetBool("IsOpen", false);
    }
}

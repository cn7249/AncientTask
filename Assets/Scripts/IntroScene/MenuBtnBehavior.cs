using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtnBehavior : MonoBehaviour
{
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnCickExitBtn()
    {
        
    }
}

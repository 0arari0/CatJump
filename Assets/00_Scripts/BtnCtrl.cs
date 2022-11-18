using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCtrl : MonoBehaviour
{
    bool PauseActive = false;

    public void pauseBtn()
    {
        if(PauseActive==false)
        {
            Time.timeScale = 0;
            PauseActive = true;
        }
    }
    public void ReturnGame()
    {
        if (PauseActive == true)
        {
            Time.timeScale = 1;
            PauseActive = false;
        }
    }
}

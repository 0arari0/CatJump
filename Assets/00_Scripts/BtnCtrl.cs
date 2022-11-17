using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCtrl : MonoBehaviour
{
    bool PauseActive = false;

    public void pauseBtn()
    {
        if(PauseActive)
        {
            Time.timeScale = 1;
            PauseActive = false;
        }
        else
        {
            Time.timeScale = 0;
            PauseActive = true;
        }
    }
}

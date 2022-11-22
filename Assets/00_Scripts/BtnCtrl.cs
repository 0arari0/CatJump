using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnCtrl : MonoBehaviour
{
    bool PauseActive = false;

    public void pauseBtn() //일시정지 시 플레이화면 정지
    {
        if(PauseActive==false)
        {
            Time.timeScale = 0;
            PauseActive = true;
        }
    }
    public void ReturnGame() //일시정지 해제 시 플레이화면 다시 재생
    {
        if (PauseActive == true)
        {
            Time.timeScale = 1;
            PauseActive = false;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(0); //Play씬과 연결
    }
    public void GotoMain()
    {
        SceneManager.LoadScene(1); //Main씬과 연결
    }
    public void GameExit() //게임 종료
    {
        Application.Quit();
    }
}


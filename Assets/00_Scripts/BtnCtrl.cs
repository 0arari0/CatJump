using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnCtrl : MonoBehaviour
{
    bool PauseActive = false;

    public void pauseBtn() //�Ͻ����� �� �÷���ȭ�� ����
    {
        if(PauseActive==false)
        {
            Time.timeScale = 0;
            PauseActive = true;
        }
    }
    public void ReturnGame() //�Ͻ����� ���� �� �÷���ȭ�� �ٽ� ���
    {
        if (PauseActive == true)
        {
            Time.timeScale = 1;
            PauseActive = false;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(0); //Play���� ����
    }
    public void GotoMain()
    {
        SceneManager.LoadScene(1); //Main���� ����
    }
    public void GameExit() //���� ����
    {
        Application.Quit();
    }
}


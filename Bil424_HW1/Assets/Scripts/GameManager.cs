using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    float time;
    float msec;
    float min;
    float sec;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        time = Move.timer;
        msec = (int)((time - (int)time) * 100);
        sec = (int)(time % 60);
        min = (int)(time / 60 % 60);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec,msec);

    }

    public void RestartButton()
    {
        Move.startTimer = false;
        Move.timer = 0;
        SceneManager.LoadScene(0);
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

   
}

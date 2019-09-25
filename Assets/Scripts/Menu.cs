using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public OrderManager OrderManager;
    public Text CountForWin;

    public GameObject WinWindow;
    public Text WinCountText;
    public GameObject LoseWindow;
    public Text LoseCountText;
    public Image ProgressLine;

    void Start()
    {
        OrderManager.OnReady += OnReady;
        OrderManager.OnEnd += OnEnd;
    }

    void OnReady()
    {
        CountForWin.text = OrderManager.CountForWin.ToString();
    }

    void OnEnd()
    {
        if (OrderManager.Score < OrderManager.CountForWin)
        {
            LoseCountText.text = $"{OrderManager.Score} / {OrderManager.CountForWin}";
            ProgressLine.fillAmount = (float)OrderManager.Score / OrderManager.CountForWin;
            LoseWindow.SetActive(true);
        }
        else
        {
            WinCountText.text = $"{OrderManager.CountForWin} / {OrderManager.CountForWin}";
            WinWindow.SetActive(true);
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

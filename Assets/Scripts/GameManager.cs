using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dialog PauseDialog;
    public Dialog WinDialog;
    public Dialog LoseDialog;

    private Dialog _curDialog;
    public Dialog curDialog { get => _curDialog; set => _curDialog = value; }

    public Text levelText;
    public Text scoreText;
    public Text timeText;
    public Text coinText;

    public int level = 0;
    public int score = 0;
    public int time = 0;
    public int coin = 0;


    public List<GameObject> listLevelObj;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StatUpdate();
        listLevelObj[Pref.levelLoading-1].SetActive(true);
    }

    public void PauseBtn()
    {
        if(PauseDialog)
        {
            Time.timeScale = 0f;
            PauseDialog.Show(true);
            curDialog = PauseDialog;
        }
    }
    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        if(curDialog)
        {
            curDialog.Show(false);
        }
    }
    public void QuitBtn()
    {
        ResumeBtn();
        SceneManager.LoadScene("Home");
    }
    public void Win()
    {
        if(WinDialog)
        {
            Time.timeScale = 0;
            WinDialog.Show(true);
            curDialog = WinDialog;
        }
    }
    public void Lose()
    {
        if (LoseDialog)
        {
            Time.timeScale = 0;
            LoseDialog.Show(true);
            curDialog = LoseDialog;
        }
    }
    public void StatUpdate()
    {
        levelText.text = level.ToString();
        scoreText.text = score.ToString();
        timeText.text = time.ToString();
        coinText.text = coin.ToString();
    }
}

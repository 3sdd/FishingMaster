using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float startDelay = 2;
    public Timer timer;

    public AudioSource endAudio;

    public PlayerScore playerScore;
    public Spawner[] spanwers;

    [Space]
    public GameObject startText;
    public GameObject endText;
    public GameObject scorePanel;

    string key = "Score";
    int scoreDataCount = 4;

    public ScorePoint[] scoreDisplay;
    int newIndex = -1;//新しいときの
    public GameObject[] newPops;

    bool playNewGame = false;

    private void Start()
    {
        LoadData();
        timer.OnTimerFinished += () =>
        {
            endAudio.Play();

            SetActive(false);
            endText.SetActive(true);
            StartCoroutine(HideEndText());
        };
        StartCoroutine(StartDelay());
    }

    IEnumerator HideEndText()
    {
        yield return new WaitForSeconds(2);
        endText.SetActive(false);
        ShowScore();
        playNewGame = true;
    }



    void ShowScore()
    {
        LoadData();
        UpdateData();
        SaveData();
        scorePanel.SetActive(true);

        for (int i = 0; i < scoreDataCount; i++)
        {
            scoreDisplay[i].UpdateUI(hightScores[i]);
        }
        if (newIndex != -1)
        {
            newPops[newIndex].SetActive(true);
        }
    }

    List<int> hightScores = new List<int>();
    void LoadData()
    {
        for (int i = 0; i < scoreDataCount; i++)
        {
            var score = PlayerPrefs.GetInt(key + i);
            hightScores.Add(score);
        }
    }

    void UpdateData()
    {
        var ps = playerScore.point;
        for (int i = 0; i < scoreDataCount; i++)
        {
            if (ps > hightScores[i])
            {
                hightScores.Insert(i, ps);
                newIndex = i;
                break;
            }
        }
    }

    void SaveData()
    {
        for (int i = 0; i < scoreDataCount; i++)
        {
            PlayerPrefs.SetInt(key + i, hightScores[i]);
        }
    }

    IEnumerator HideStartText()
    {
        yield return new WaitForSeconds(1);
        startText.SetActive(false);
    }

    IEnumerator StartDelay()
    {
        SetActive(false);
        yield return new WaitForSeconds(startDelay);
        startText.SetActive(true);

        endAudio.Play();
        SetActive(true);

        StartCoroutine(HideStartText());
    }

    bool hasDecreased = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (timer.timeLfet < timer.time / 2 && !hasDecreased)
        {
            foreach (var item in spanwers)
            {
                item.minInterval -= 1;
                item.maxInterval -= 1;
            }
            hasDecreased = true;
        }



        if (playNewGame && Input.anyKeyDown)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }

    public void SetActive(bool isActive)
    {
        playerScore.isActive = isActive;
        timer.isActive = isActive;
        foreach (var item in spanwers)
        {
            item.isActive = isActive;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum GameState { Play, Pause };
public class HUD : MonoBehaviour
{

    static private HUD _instance;

    private GameState state;

    [SerializeField]
    private GameObject MenuWindow;

    [SerializeField]
    private GameObject LooseWindow;

    [SerializeField]
    private Text finalScoresCount;
    [SerializeField]
    private Text highScoreCount;
    [SerializeField]
    private Text dashCountText;

    [SerializeField]
    private Text distanceCountText;

    public GameState State
    {
        get
        {
            return state;
        }

        set
        {
            if (value == GameState.Play)
            {
                Time.timeScale = 1.0f;
                GameController.Instance.myHead.enabled = true;
            }
            else if (value == GameState.Pause)
            {
                Time.timeScale = 0.0f;

            }
            state = value;
        }
    }

    public static HUD Instance
    {
        get
        {
            return _instance;
        }
    }

    public void changeTextDash()
    {
        dashCountText.text = "Dash:" + PlayerController.Instance.DashAvailable.ToString();
    }

    public void changeTextDistance()
    {
        distanceCountText.text = "Score:" + GameController.Instance.myHead.CalculateScore();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        GameController.Instance.myHead.SimulationHead(true);
        State = GameState.Play;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ShowWindow(GameObject window)
    {
        window.GetComponent<Animator>().SetBool("Opened", true);
        State = GameState.Pause;
    }
    public void HideWindow(GameObject window)
    {
        window.GetComponent<Animator>().SetBool("Opened", false);
        State = GameState.Play;
    }
    public void Died()
    {
        MenuAudioController.Instance.StopMusic();
        MenuAudioController.Instance.PlaySound("win", false);

        ShowWindow(LooseWindow);
        finalScoresCount.text = "Your final score is:" + GameController.Instance.myHead.CalculateScore();
    }

    public void SetHighScore()
    {
        if (PlayerPrefs.GetInt("PlayerBestScore") < int.Parse(GameController.Instance.myHead.CalculateScore()))
        {
            PlayerPrefs.SetInt("PlayerBestScore", int.Parse(GameController.Instance.myHead.CalculateScore()));
            highScoreCount.text = "Best Score:" + PlayerPrefs.GetInt("PlayerBestScore").ToString();
        }
    }

    public void ShowHighScore()
    {
        
        highScoreCount.text = "Best Score:" + PlayerPrefs.GetInt("PlayerBestScore").ToString();
    }


        
}


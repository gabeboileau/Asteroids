using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{

    public static GameObject IMG_GameOver;
    public static Text TXT_GameOver;
    public static Text TXT_YourScore;

    
    public static int Score;


    private static Score_Manager m_ScoreManager;

    void Start()
    {
        m_ScoreManager = GetComponent<Score_Manager>();
        IMG_GameOver = transform.Find("IMG_GameOver").gameObject;
        TXT_GameOver = transform.Find("IMG_GameOver").Find("TXT_GameOver").GetComponent<Text>();
        TXT_YourScore = transform.Find("IMG_GameOver").Find("TXT_YourScore").GetComponent<Text>();
    }



    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public static void GameOver()
    {
        Score = m_ScoreManager.GetScore();
        TXT_YourScore.text = "You Scored: " + Score.ToString();
        IMG_GameOver.SetActive(true);
        TXT_GameOver.GetComponent<TXT_GameOVer>().MoveToPos();
        
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score_Manager : MonoBehaviour
{

    public static int score = 0;
    public static Text m_ScoreText;

    void Start()
    {
        m_ScoreText = transform.Find("TXT_Score").GetComponent<Text>();
    }

    public static void AddScore(int aAmount)
    {
        score += aAmount;
        UpdateText();
    }


    private static void UpdateText()
    {
        m_ScoreText.text = "Score: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}

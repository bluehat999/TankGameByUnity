using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    private int score1=0;
    private int score2=0;
    private bool restart = false;
    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;
        Debug.Log("," + score1 + "," + score2);
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            this.initScore();
            restart = false;
            Debug.Log(score1 + "," + score2);
        }
    }
    public void RestartPress()
    {
        this.restart = true;
    }
    public void addScore(int playerNum,int score=1)
    {
        Debug.Log("addScore()"+score+","+score1+","+score2);
        switch (playerNum)
        {
            case 1:
                {
                    this.score1 = this.score1 + score;
                    //textScore1.text = score1.ToString();
                    GameObject.Find("ImageScore/Score1").GetComponent<Text>().text = score1.ToString();
                    break;
                }
            case 2:
                {
                    this.score2 = this.score2 + score;
                    //textScore2.text = score2.ToString();
                    GameObject.Find("ImageScore/Score2").GetComponent<Text>().text = score2.ToString();
                    break;
                }
            default:
                break;
                
        }
    }
    private void initScore()
    {
        this.score1 = 0;
        this.score2 = 0;
        GameObject.Find("ImageScore/Score1").GetComponent<Text>().text = score1.ToString();
        GameObject.Find("ImageScore/Score2").GetComponent<Text>().text = score2.ToString();

    }
}

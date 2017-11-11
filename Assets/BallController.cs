using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    private float visiblePosZ = -6.5f;
    private int collSwitch = 0;
    private int score = 0;
    private int collCount = 0;
    private GameObject gameoverText;
    private GameObject scoreText;
    private GameObject rankText;
    private void Rank()
    {
        if (this.score >= 10000)
        {
            this.rankText.GetComponent<Text>().text = "Rank S";
        }
        else if (this.score >= 2000 && this.score < 10000)
        {
            this.rankText.GetComponent<Text>().text = "Rank A";
        }
        else if (this.score >= 500 && this.score < 2000)
        {
            this.rankText.GetComponent<Text>().text = "Rank B";
        }
        else if (this.score >= 100 && this.score < 500)
        {
            this.rankText.GetComponent<Text>().text = "Rank C";
        }
        else
        {
            this.rankText.GetComponent<Text>().text = "Rank D";
        }
    }
    // Use this for initialization
    void Start () {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
        this.rankText = GameObject.Find("Rank");
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "GameOver";
            Rank();
        }
        if (this.collSwitch == 1&&this.collCount==1)
        {
            this.score += 10;
        }else if (this.collSwitch == 2&&this.collCount==1)
        {
            this.score += 30;
        }else if (this.collSwitch == 3&&this.collCount==1)
        {
            this.score += 50;
        }else if (this.collSwitch == 4&&this.collCount==1)
        {
            this.score += 100;
        }
        this.scoreText.GetComponent<Text>().text = "Score:" + score.ToString();
	}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SmallStarTag"))
        {
            this.collSwitch = 1;
            this.collCount++;
        }else if (other.gameObject.CompareTag("LargeStarTag"))
        {
            this.collSwitch = 2;
            this.collCount++;
        }else if (other.gameObject.CompareTag("SmallCloudTag"))
        {
            this.collSwitch = 3;
            this.collCount++;
        }else if (other.gameObject.CompareTag("LargeCloudTag"))
        {
            this.collSwitch = 4;
            this.collCount++;
        }
        else
        {
            this.collSwitch = 0;
            this.collCount = 0;
        }
    }
   
}

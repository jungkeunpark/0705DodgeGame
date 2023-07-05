using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUi = default;
    public Text timeText = default;
    public Text recordText = default;

    private float surviveTime = default;
    private bool isGameOver = default;

    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == false)
        {
            surviveTime += Time.deltaTime;
            timeText.text = string.Format("Time : {0}",(int)surviveTime);
        }
        //else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");    

            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(bestTime < surviveTime) 
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        
        }

        recordText.text = string.Format("Best Time : {0}", (int)bestTime);
    }
}

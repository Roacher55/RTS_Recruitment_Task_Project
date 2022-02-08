using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject hudCanvas;
    [SerializeField] GameObject toolTipChest;
    Chest chest;
    Doors doors;
    [SerializeField]GameHelper gameHelper;
    [SerializeField] GameObject key;
    [SerializeField] GameObject toolTipKey;
    [SerializeField] GameObject toolTipDoorsnothavekey;
    [SerializeField] GameObject toolTipDoorshavekey;
    [SerializeField] Text textCurrentScore;
    [SerializeField] Text textHighScore;
    [SerializeField] GameObject endGameCanvas;
    [SerializeField] Timer timer;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject keyIcon;
   


    public void ClickButtonStart()
    {
        audioSource.Play();
        menuCanvas.SetActive(false);
        hudCanvas.SetActive(true);
        Time.timeScale = 1;
    }



    public void ClickCancelButton()
    {
        audioSource.Play();
        toolTipChest.SetActive(false);
        toolTipKey.SetActive(false);
        toolTipDoorsnothavekey.SetActive(false);
        toolTipDoorshavekey.SetActive(false);
    }

    public void ClickOpenChest()
    {
        chest = FindObjectOfType<Chest>();

        chest.animator.SetBool("Open", true);
        Instantiate(key, chest.spawnKeyPosition.position, Quaternion.identity);
        ClickCancelButton();
        chest.isOpened = true;
        chest.GetComponent<BoxCollider>().enabled = false;
    }

    public void ClickKey()
    {
        audioSource.Play();
        var key = GameObject.FindObjectOfType<Key>();
        gameHelper.haveKey = true;
        Destroy(key.gameObject);
        keyIcon.SetActive(true);
        ClickCancelButton();
    }

    public void ClickOpenDoor()
    {
        audioSource.Play();
        doors = FindObjectOfType<Doors>();
        doors.animator.SetBool("Open", true);
        doors.GetComponent<BoxCollider>().enabled = false;
        ClickCancelButton();
        keyIcon.SetActive(false);
        StartCoroutine(Wait(2f));
    }

    public void TryAgain()
    {
        audioSource.Play();
        GameHelper.boolTryAgain = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        endGameCanvas.SetActive(true);
        gameHelper.currentScore = timer.timer;
        TimeSpan timeSpan = new TimeSpan(0, 0, (int)gameHelper.currentScore);
        textCurrentScore.text = "Current Score: " + timeSpan.Minutes + ":" + timeSpan.Seconds;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            gameHelper.highScore = PlayerPrefs.GetFloat("HighScore");
            if (gameHelper.highScore > gameHelper.currentScore)
            {
                gameHelper.highScore = gameHelper.currentScore;
                PlayerPrefs.SetFloat("HighScore", gameHelper.highScore);
            }
            timeSpan = new TimeSpan(0, 0, (int)gameHelper.highScore);
            textHighScore.text = "HighScore: " + timeSpan.Minutes + ":" + timeSpan.Seconds;
        }
        else
        {
            gameHelper.highScore = gameHelper.currentScore;
            PlayerPrefs.SetFloat("HighScore", gameHelper.highScore);
            timeSpan = new TimeSpan(0, 0, (int)gameHelper.highScore);
            textHighScore.text = "HighScore: " + timeSpan.Minutes + ":" + timeSpan.Seconds;
        }
        
    }

}

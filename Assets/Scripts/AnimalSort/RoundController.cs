using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public int currentRound = 0;
    public int numberofObjectPlaced = 0;
    public int score = 0;
    public TextMeshProUGUI blueText;
    public TextMeshProUGUI redText;
    public TextMeshProUGUI scorecontainer;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI animalName;
    public TextMeshProUGUI animalInfo;

    public GameObject gameOverPanel;
    public GameObject nextRoundPanel;
    public GameObject animalInfoPanel;
    public AudioSource audioSource;
    public AudioClip audioClipdropBucket;
    public AudioClip clickButtonAudio;



    public GameObject[] animals;

    public string[] blueTextValues =
    {
        "Flying",
        "Insect",
        "Omnivorous",
        "Solo",
        "Lay Egss"

    };
    public string[] redTextValues =
    {
        "Non Flying",
        "Non Insect",
        "Herbivores",
        "Lives in group",
        "Give birth"

    };
    public delegate void nextRound();
    public static event nextRound nextRoundStart;
    void Start()
    {
        nextRoundStart += OnNextRoundStart;
        CallnextRound();
    }
    public void CallnextRound()
    {
        currentRound++;
        numberofObjectPlaced = 0;
        nextRoundStart?.Invoke();
    }
    public void OnNextRoundStart()
    {
        if (currentRound > 5)
        {
            GameOver();
        }
        else
        {
            if (currentRound != 1)
            {
                nextRoundPanel.SetActive(true);
                StartCoroutine(StartPanelActive());
            }
            foreach (GameObject animal in animals)
            {
                animal.GetComponent<Image>().enabled = true;
            }
            blueText.text = blueTextValues[currentRound - 1];
            redText.text = redTextValues[currentRound - 1];
        }

    }
    IEnumerator StartPanelActive()
    {
        yield return new WaitForSeconds(1);
        nextRoundPanel.SetActive(false);
    }
    public void checkObjectsCount()
    {
        Debug.Log("Number of object : " + numberofObjectPlaced);
        if (numberofObjectPlaced >= 18)
        {
            CallnextRound();
        }
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverScore.text = "Your Score :" + score + "/90";
        Debug.Log("Gameover");
    }
    public void CheckTheAnswerForBlueBucket(Animal animal)
    {
        switch (currentRound)
        {
            case 1:
                if (animal.flying)
                {
                    IncreaseScore();
                }
                break;
            case 2:
                if (animal.insect)
                {
                    IncreaseScore();

                }
                break;
            case 3:
                if (animal.Omnivorous)
                {
                    IncreaseScore();

                }
                break;
            case 4:
                if (animal.solo)
                {
                    IncreaseScore();

                }
                break;
            case 5:
                if (animal.layEgss)
                {
                    IncreaseScore();

                }
                break;

        }
    }
    public void CheckTheAnswerForRedBucket(Animal animal)
    {
        switch (currentRound)
        {
            case 1:
                if (!animal.flying)
                {
                    IncreaseScore();
                }
                break;
            case 2:
                if (!animal.insect)
                {
                    IncreaseScore();

                }
                break;
            case 3:
                if (!animal.Omnivorous)
                {
                    IncreaseScore();

                }
                break;
            case 4:
                if (!animal.solo)
                {
                    IncreaseScore();

                }
                break;
            case 5:
                if (!animal.layEgss)
                {
                    IncreaseScore();

                }
                break;

        }

    }
    public void IncreaseScore()
    {
        score++;
        scorecontainer.text = " Score : " + score;
        Debug.Log(score);

    }
    public void DisplayInfo(string animalname)
    {
        animalName.text = animalname;
        animalInfo.text = StaticValues.animalInfo[animalname];
        animalInfoPanel.SetActive(true);
    }
    public void PlaySFX(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);


    }


}

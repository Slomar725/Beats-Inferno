using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    int sceneIndex;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;


    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missedText, rankText, finalScoreText;

    public int Health = 100;
    public GameObject failedScreen;

    public string rankVal;

    public GameObject restartingText;

    public GameObject ResetButton;
    public GameObject HomeButton;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            theMusic.Stop();
            theBS.hasStarted = false;
            
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ResetMap());
            StartCoroutine(ResetPlayer());
        }

        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                if(!restartingText.activeInHierarchy)
                {
                    ResetButton.SetActive(true);
                    HomeButton.SetActive(true);
                }

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missedText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                rankVal = "F";
                if (Health == 0)
                {
                    rankVal = "F";
                }
                else
                {

                    if (percentHit >= 20)
                    {
                        rankVal = "D";
                        if (percentHit >= 65)
                        {
                            rankVal = "C";
                            if (percentHit >= 80)
                            {
                                rankVal = "B";
                                if (percentHit >= 90)
                                {
                                    rankVal = "A";
                                    if (percentHit >= 100)
                                    {
                                        rankVal = "S";
                                    }
                                }
                            }
                        }
                    }
                }
                

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();

            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("hit on time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
        Health -= 50;
        

        if(Health == 0)
        {
            failedScreen.SetActive(true);
            theBS.hasStarted = false;
            theMusic.Stop();
        }
    }
    public IEnumerator ResetMap()
    {
        theBS.hasStarted = false;
        theMusic.Stop();
        yield return new WaitForSeconds(2);
        failedScreen.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }
    public IEnumerator ResetPlayer()
    {
        restartingText.SetActive(true);
        yield return new WaitForSeconds(2);
        restartingText.SetActive(false);
    }


}

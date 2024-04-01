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

    //int sceneIndex;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;


    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;
    public Text HealthText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;
    

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missedText, rankText, finalScoreText;

    public int Health;
    public GameObject failedScreen;
    public GameObject fullComboOhYeah;

    public string rankVal;
    public Text changeRankVal;
    public int comboVal;
    public Text comboText;
    public GameObject comboHolder;


    public GameObject restartingText;
    public GameObject PressAnyKeyStart;

    public GameObject ResetButton;
    public GameObject HomeButton;
    public GameObject NextLevelButton;
    GameObject[] poisonNotes;

    public bool everythingTrue;

    public GameObject actualCharacter;
    public GameObject notDeadYet;
    public GameObject characterDead;
    public GameObject showPanel;
    public GameObject backSquare;
    public GameObject enemyYeah;
    
    public Animator forward;
    public Animator back;

    public GameObject PanelCover;
    public GameObject playerWon;
    public GameObject turnPlayeroff;
    public GameObject turnEnemyOff;

    public GameObject healthOff;
    public GameObject scoreOff;
    public GameObject multiplierOff;

    


    // Start is called before the first frame update
    void Start()
    {
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;

        
        
        Health = 400;
        HealthText.text = "Health: " + Health;
        
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        poisonNotes = GameObject.FindGameObjectsWithTag("Poison");
        int poison = poisonNotes.Length;
        totalNotes = FindObjectsOfType<NoteObject>().Length;
        totalNotes = totalNotes - poison;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) //Infinite health dev cheat
        {
            Health = 10000000;
            HealthText.text = "Health: " + Health;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            theMusic.Stop();
            theBS.hasStarted = false;
            
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            comboHolder.SetActive(false);
            resultsScreen.SetActive(true);
            StartCoroutine(ResetMap());
            StartCoroutine(ResetPlayer());

        }

        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                PressAnyKeyStart.SetActive(false);

                theMusic.Play();
                
            }
        }else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                healthOff.SetActive(false);
                multiplierOff.SetActive(false);
                scoreOff.SetActive(false);
                comboHolder.SetActive(false);
                if(Health > 0)
                { 
                  
                   if(!restartingText.activeInHierarchy)
                   {    
                        turnEnemyOff.SetActive(false);
                        playerWon.SetActive(true);
                        PanelCover.SetActive(true);
                        turnPlayeroff.SetActive(false);
                        Animation.instance.won();
                        StartCoroutine(ResultWait());
                        ResetButton.SetActive(true);
                        HomeButton.SetActive(true);
                        NextLevelButton.SetActive(true);
                   }
                   if(comboVal == totalNotes)
                   {
                        fullComboOhYeah.SetActive(true);
                   }
                }
                else
                {
                    NextLevelButton.SetActive(false);
                    StartCoroutine(Youdead());
                    StartCoroutine(ResultWait());
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
        HealthText.text = "Health: " + Health; 

        missedHits++;
        Health -= 50;
        
        

        if(Health <= 0)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(sceneIndex);
    }
    public IEnumerator ResetPlayer()
    {
        restartingText.SetActive(true);
        yield return new WaitForSeconds(2);
        restartingText.SetActive(false);
    }
    public void checkDead()
    {
        if(Health <= 0)
        {
            failedScreen.SetActive(true);
            theBS.hasStarted = false;
            theMusic.Stop();
        }
    }
    public void changeRank()
    {
         float totalHit = normalHits + goodHits + perfectHits;
         float percentHit = (totalHit / totalNotes) * 100f;
         percentHitText.text = percentHit.ToString("F1") + "%";
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
            changeRankVal.text = rankVal;
    }
    public void Combo()
    {
        comboVal++;
        comboText.text = comboVal.ToString();
    }
    public void ComboEnd()
    {
        comboVal = 0;
        comboText.text = comboVal.ToString();
    }
    public IEnumerator Youdead()
    {
        enemyYeah.SetActive(false);
        actualCharacter.SetActive(false);
        showPanel.SetActive(true);
        notDeadYet.SetActive(true);
        forward.Play("xcs");
        yield return new WaitForSeconds(2);
        backSquare.SetActive(true);
        characterDead.SetActive(true);
        back.Play("back");
        //characterDead.SetActive(true);
    }
    public IEnumerator ResultWait()
    {
        yield return new WaitForSeconds(4);
        resultsScreen.SetActive(true);
        ResetButton.SetActive(true);
        HomeButton.SetActive(true);
    }

}

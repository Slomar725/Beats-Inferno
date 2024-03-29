using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode KeyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();
                //if((Mathf.Abs(transform.position.y) > 0.40) && gameObject.tag != "Poison")
                //{
                    //GameManager.instance.NoteMissed();
                    //GameManager.instance.ComboEnd();
                    //Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                //}
                if((Mathf.Abs(transform.position.y) > 0.25) && gameObject.tag != "Poison")
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    GameManager.instance.Combo();
                }else if((Mathf.Abs(transform.position.y) > 0.05f) && gameObject.tag != "Poison")
                {
                    Debug.Log("GoodHit");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    GameManager.instance.Combo();
                }
                 else if(gameObject.tag != "Poison")
                {
                    Debug.Log("PerfectHit");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    GameManager.instance.Combo();
                }
                else if (gameObject.tag == "Poison")
                {
                    GameManager.instance.Health -= 50;
                    GameManager.instance.HealthText.text = "Health: " + GameManager.instance.Health;
                    Animation.instance.noDamage();
                    GameManager.instance.checkDead();
                    GameManager.instance.ComboEnd();
                }
                
                GameManager.instance.changeRank();
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeSelf )
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;
                if(gameObject.tag != "Poison")
                {
                    GameManager.instance.ComboEnd();
                    Animation.instance.noDamage();
                    GameManager.instance.NoteMissed();
                    Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopNote : MonoBehaviour
{
    public static TopNote instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            LongNoteScript.instance.canBeReleased = true;
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            LongNoteScript.instance.canBeReleased = false;
        }
    }
}

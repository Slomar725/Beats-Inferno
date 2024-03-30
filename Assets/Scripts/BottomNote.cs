using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomNote : MonoBehaviour
{
    public static BottomNote instance;

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
            LongNoteScript.instance.canBePressedTwo = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            LongNoteScript.instance.canBePressedTwo = false;
            
        }
    }
}

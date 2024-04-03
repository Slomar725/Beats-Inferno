using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noSpam : MonoBehaviour
{
    public bool cannotBePressed;
    public static noSpam instance;
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
        if(other.tag == "Untagged")
        {
            cannotBePressed = true;
            
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Untagged")
        {
            NoteObject.instance.canBePressed = false;
            cannotBePressed = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;


    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
       // if(Input.GetKeyDown(UserInput.instance.DInput) || Input.GetKeyDown(UserInput.instance.FInput) || Input.GetKeyDown(UserInput.instance.JInput) || Input.GetKeyDown(UserInput.instance.KInput))
       /// {
            //theSR.sprite = pressedImage;
        //}
       // if (Input.GetKeyUp(UserInput.instance.DInput) || Input.GetKeyUp(UserInput.instance.FInput) || Input.GetKeyUp(UserInput.instance.JInput) || Input.GetKeyUp(UserInput.instance.KInput))
        //{
            //theSR.sprite = defaultImage;
       // }
        

        

        
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }

    }
}

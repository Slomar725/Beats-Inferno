using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteScript : MonoBehaviour
{
    public static LongNoteScript instance;
    public KeyCode KeyCodeToPress;
    public bool canBePressedTwo;
    public bool canBeReleased;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(canBePressedTwo && Input.GetKeyDown(KeyCodeToPress))
        {
            StartCoroutine(WaitForPlayer());
        }
    }

    public IEnumerator WaitForPlayer()
    {
        while(Input.GetKey(KeyCodeToPress))
        {
            yield return null;
        }
        Debug.Log("Button released");
    }
}

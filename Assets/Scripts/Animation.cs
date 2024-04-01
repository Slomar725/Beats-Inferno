using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour

{
    public Animator animator;
    
    public static Animation instance;
    public bool isDamage;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isDamage = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isDamage = false;

        if(Input.anyKeyDown && !isDamage)
        {
            animator.Play("PlayerAnim");
            
        }
    }
    public void won()
    {
        animator.Play("ohYEah");
    }
    public void noDamage()
        {
            isDamage = true;
            animator.Play("takenDamage");
        }
    
}

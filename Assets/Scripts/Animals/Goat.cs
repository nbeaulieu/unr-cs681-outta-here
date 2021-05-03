using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.Play("Eat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

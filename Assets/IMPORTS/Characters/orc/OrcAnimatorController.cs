using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAnimatorController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

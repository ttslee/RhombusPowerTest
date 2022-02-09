using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private Animator animator;
    private void Awake() 
    {
        animator = GetComponent<Animator>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    private void Start() {
        animator.SetTrigger("UFOAnimation");
    }
}

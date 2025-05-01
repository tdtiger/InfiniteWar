using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private Collider hitbox;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            animator.SetTrigger("Punch");
        }
    }

    public void EnableHitBox(){
        Debug.Log("Hitbox enabled");
        hitbox.enabled = true;
    }

    public void DisableHitBox(){
        Debug.Log("Hitbox disabled");
        hitbox.enabled = false;
    }
}
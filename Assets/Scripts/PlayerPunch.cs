using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPunch : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private Collider hitbox;

    [SerializeField]
    private Button button;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        // スマホの場合はボタンを押したら攻撃
        #if UNITY_ANDROID || UNITY_IOS
            if(button.GetComponent<Button>().IsPressed()){
                animator.SetTrigger("Punch");
            }
        // PCの場合はスペースキーを押したら攻撃
        #else
            if(Input.GetKeyDown(KeyCode.Space)){
                animator.SetTrigger("Punch");
            }
        #endif
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunch : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Collider hitbox;

    private float punchInterval = 5f;
    private float punchTimer = 0f;
    private bool isPunching = false;
    private float power = 5f;
    public float Power{
        get{
            return power;
        }
        set{
            power = value;
        }
    }

    private float knockbackForce = 5f;
    public float KnockbackForce{
        get{
            return knockbackForce;
        }
        set{
            knockbackForce = value;
        }
    }

    void Start(){
        animator = GetComponent<Animator>();
        hitbox.enabled = false;
    }

    void Update(){
        punchTimer += Time.deltaTime;
        if (punchTimer >= punchInterval && !isPunching){
            isPunching = true;
            punchTimer = 0f;
            animator.SetTrigger("Punch");
        }
    }

    public void EnableHitbox_E(){
        hitbox.enabled = true;
        Debug.Log("Enemy hitbox enabled");
    }

    public void DisableHitbox_E(){
        hitbox.enabled = false;
        isPunching = false;
        Debug.Log("Enemy hitbox disabled");
    }
}

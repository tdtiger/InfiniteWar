using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    [SerializeField]
    private EnemyPunch enemyPunch;
    [SerializeField]
    private Collider hitbox;

    void Start(){
        hitbox.enabled = false;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Debug.Log("Player hit by enemy punch");

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if(rb != null){
                Vector3 knockbackDirection = (other.transform.position - transform.position).normalized;
                rb.AddForce(knockbackDirection * enemyPunch.Power * enemyPunch.KnockbackForce, ForceMode.Impulse);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    private Collider hitbox;

    void Start(){
        hitbox.enabled = false;
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            Debug.Log("Hit!");

            Rigidbody enemyRb = other.GetComponent<Rigidbody>();
            if(enemyRb != null){
                Vector3 forceDir = (other.transform.position - transform.position).normalized;
                enemyRb.AddForce(forceDir * 20f, ForceMode.Impulse);
            }
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

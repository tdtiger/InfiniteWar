using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            Debug.Log("Hit!");

            Rigidbody enemyRb = other.GetComponent<Rigidbody>();
            if(enemyRb != null){
                Vector3 forceDir = (other.transform.position - transform.position).normalized;
                enemyRb.AddForce(forceDir * 10f, ForceMode.Impulse);
            }
        }
    }
}

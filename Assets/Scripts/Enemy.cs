using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;

    void Start(){
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    void Update(){
        if(this.transform.position.y < -5f){
            Destroy(this.gameObject);
            enemyManager.EnemyCount -= 1;
        }
    }
}

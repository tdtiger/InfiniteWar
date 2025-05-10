using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;

    private Player player;

    // 敵の移動速度(プレイヤーより遅めに設定)
    private float moveSpeed = 3f;

    // ステージの半径
    private float stageRadius = 17f;

    // ステージは死から余裕を持たせる距離
    private float margin = 5f;

    void Start(){
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update(){
        // ステージから落下したら消滅
        if(this.transform.position.y < -3f){
            Destroy(this.gameObject);
            enemyManager.EnemyCount -= 1;
        }

        // プレイヤーがいない場合は何もしない
        if(player == null){
            return;
        }

        // プレイヤーへ向かう正規化ベクトル
        Vector3 toPlayer = (player.transform.position - this.transform.position).normalized;

        float distanceFromCenter = Vector3.Distance(this.transform.position, Vector3.zero);
        if(distanceFromCenter > stageRadius - margin){
            Vector3 moveDirection = (Vector3.zero - this.transform.position).normalized;
            this.transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else{
            this.transform.position += toPlayer * moveSpeed * Time.deltaTime;
            if(toPlayer != Vector3.zero){
            // 敵の向きを移動方向に合わせる
                Quaternion targetRotation = Quaternion.LookRotation(toPlayer);

                Vector3 currentEuler = this.transform.rotation.eulerAngles;
                Vector3 targetEuler = targetRotation.eulerAngles;

                float correctedY = targetEuler.y;

                Quaternion correctedRotation = Quaternion.Euler(currentEuler.x, correctedY, currentEuler.z);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, correctedRotation, Time.deltaTime * 10f);
            }
        }
    }
}

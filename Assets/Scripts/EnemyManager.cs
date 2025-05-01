using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 敵のプレハブ
    [SerializeField]
    private GameObject enemyPrefab;

    // 敵の生成間隔
    [SerializeField]
    private float spawnInterval = 3f;

    // ステージ中心からの距離
    [SerializeField]
    private float spawnRadius = 5f;

    private float timer = 0;

    void Update(){
        timer += Time.deltaTime;
        // 一定時間経過で敵生成
        if(timer >= spawnInterval){
            SpawnEnemy();
            timer = 0;
        }
    }

    private void SpawnEnemy(){
        // 敵を生成する位置をランダムに決定
        Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(randomPos.x, 10f, randomPos.y);

        // 敵を生成
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(90, 0, 180));
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}

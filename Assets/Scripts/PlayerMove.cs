using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーの移動速度
    [SerializeField]
    private float moveSpeed = 5f;

    void Update(){
        // 横方向の入力検出
        float horizontal = Input.GetAxis("Horizontal");
        // 縦方向の入力検出
        float vertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        this.transform.position += movement * moveSpeed * Time.deltaTime;
    }
}

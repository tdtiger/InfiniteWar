using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーの移動速度
    [SerializeField]
    private float moveSpeed = 5f;

    // 移動時の方向管理
    private Vector3 moveDirection;

    void Update(){
        // 横方向の入力検出
        float horizontal = Input.GetAxis("Horizontal");
        // 縦方向の入力検出
        float vertical = Input.GetAxis("Vertical");
        // 方向のベクトル(正規化)
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        if(moveDirection != Vector3.zero){
            // プレイヤーの向きを移動方向に合わせる
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            Vector3 currentEuler = this.transform.rotation.eulerAngles;
            Vector3 targetEuler = targetRotation.eulerAngles;

            float correctedY = targetEuler.y;

            Quaternion correctedRotation = Quaternion.Euler(currentEuler.x, correctedY, currentEuler.z);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, correctedRotation, Time.deltaTime * 10f);
        }

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
        this.transform.position += movement * moveSpeed * Time.deltaTime;
    }
}

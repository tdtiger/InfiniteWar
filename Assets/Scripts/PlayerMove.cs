using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーの移動速度
    private float moveSpeed = 7f;

    // ジョイスティック
    [SerializeField]
    private Joystick joystick;

    // 移動時の方向管理
    private Vector3 moveDirection;

    void Update(){
        // スマホの場合はジョイスティックの値を取得
        #if UNITY_ANDROID || UNITY_IOS
            float horizontal = joystick.Horizontal;
            float vertical = joystick.Vertical;
        // PCの場合はキー入力を取得
        #else
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
        #endif

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

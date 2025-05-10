using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update(){
        // ステージから落下したら消滅
        if(this.transform.position.y < -3f){
            Destroy(this.gameObject);
        }
    }
}

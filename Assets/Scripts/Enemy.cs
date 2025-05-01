using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update(){
        if(this.transform.position.y < -5f)
            Destroy(this.gameObject);
    }
}

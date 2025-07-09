using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPunch : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private Collider hitbox;

    [SerializeField]
    private Button button;

    private float power = 0f;
    public float Power{
        get{
            return power;
        }
        set{
            power = value;
        }
    }
    private float maxPower = 20f;
    private float chargeSpeed = 2f;
    private float knockbackForce = 5f;
    public float KnockbackForce{
        get{
            return knockbackForce;
        }
    }

    private bool isPunching = false;

    [SerializeField]
    private PowerGaugeUI powerGaugeUI;

    void Start(){
        animator = GetComponent<Animator>();
        powerGaugeUI.SetMaxPower(maxPower);    }

    void Update(){
        if (!isPunching){
            Power += chargeSpeed * Time.deltaTime;
            Power = Mathf.Clamp(power, 0f, maxPower);
        }

        powerGaugeUI.SetPower(Power);

        // スマホの場合はボタンを押したら攻撃
#if UNITY_ANDROID || UNITY_IOS
            if(button.GetComponent<Button>().IsPressed()){
                isPunching = true;
                animator.SetTrigger("Punch");
            }
        // PCの場合はスペースキーを押したら攻撃
#else
        if (Input.GetKeyDown(KeyCode.Space)){
            isPunching = true;
            animator.SetTrigger("Punch");
        }
#endif
    }

    public void EnableHitBox(){
        Debug.Log("Hitbox enabled");
        hitbox.enabled = true;
    }

    public void DisableHitBox(){
        Debug.Log("Hitbox disabled");
        hitbox.enabled = false;
        isPunching = false;
        Power = 0f;
    }
}
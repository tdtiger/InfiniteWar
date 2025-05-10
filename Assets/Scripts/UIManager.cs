using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject joystick;

    [SerializeField]
    private GameObject button;

    void Start(){
        // プラットフォームに合わせてUIの表示設定を変更
        #if UNITY_ANDROID || UNITY_IOS
            joystick.SetActive(true);
            button.SetActive(true);
        #else
            joystick.SetActive(false);
            button.SetActive(false);
        #endif
    }
}
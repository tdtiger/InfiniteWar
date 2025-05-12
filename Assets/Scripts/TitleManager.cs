using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI startText;

    [SerializeField]
    private RectTransform rt;

    // 点滅速度
    private float fadeSpeed = 2f;

    private string mobiletext = "Tap to Start";
    private string pcText = "Press any key to start";
    private bool isFadeOut = false;

    void Start(){
        // プラットフォームによってテキスト，その大きさを切り替える
        #if UNITY_ANDROID || UNITY_IOS
            startText.text = mobiletext;
            rt.sizeDelta = new Vector2(200, 50);
        #else
            startText.text = pcText;
            rt.sizeDelta = new Vector2(385, 50);
        #endif
    }

    void Update(){
        // タップまたはキー入力でシーン遷移
        #if UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
                SceneManager.LoadScene("GameScene");
            }
        #else
            if (Input.anyKeyDown){
                SceneManager.LoadScene("GameScene");
            }
        #endif

        // テキストを点滅させる
        Color textColor = startText.color;
        // ?演算子使ってみるよ
        float alphaChange = fadeSpeed * Time.deltaTime * (isFadeOut ? -1 : 1);
        // テキストの透明度を徐々に変化
        textColor.a = Mathf.Clamp01(textColor.a + alphaChange);
        startText.color = textColor;

        // 透明度0で反転
        if(textColor.a <= 0f)
            isFadeOut = false;
        else if(textColor.a >= 1f)
            isFadeOut = true;
    }
}

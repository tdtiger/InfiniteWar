using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerGaugeUI : MonoBehaviour
{
    [SerializeField]
    private Slider powerSlider;
    [SerializeField]
    private Image fillImage;

    private Color lowColor = Color.red;
    private Color midColor = Color.yellow;
    private Color highColor = Color.white;

    float maxPower = 20f;

    public void SetMaxPower(float mp)
    {
        maxPower = mp;
        powerSlider.maxValue = maxPower;
    }

    public void SetPower(float power){
        powerSlider.value = power;
        fillImage.color = GetColorFromRatio(power / maxPower);
    }

    private Color GetColorFromRatio(float ratio){
        if (ratio < 0.5f)
            return Color.Lerp(lowColor, midColor, ratio * 2f);
        else
            return Color.Lerp(midColor, highColor, (ratio - 0.5f) * 2f);
    }
}

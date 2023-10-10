using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }
    public void SetStamina(int stamina)
    {
        slider.value = stamina;
        gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    // Start is called before the first frame update

}

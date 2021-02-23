using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butteryscript : MonoBehaviour
{
    public Slider slider;

    public void SetButtery(float buttery) {

        slider.value = buttery;
    }

    public void SetMaxButtery(int buttery) {
        slider.maxValue = buttery;
        slider.value = buttery;
    }


}

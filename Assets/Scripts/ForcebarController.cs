using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
public class ForcebarController : MonoBehaviour
{

    public Slider slider;

    public void maxForce(int force)
    {
        slider.maxValue = force;
        slider.value = force;
    }

    public void force(int force)
    {
        slider.value = force;
    }


    //void GetCurrentFill()
    //{
    //    float fillAmmount = (float)current / (float)maximo;
    //    image.fillAmount = fillAmmount;
    //}

}

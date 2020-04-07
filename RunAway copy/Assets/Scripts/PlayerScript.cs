using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	float pressure;
    public float MaxPressure = 100f;
    public Slider PressureSlider;
    public GameObject PressureFiller;

    public RawImage Texture;
    public float MaxOpacity;
    public bool HasLinearGrowth;

    [Range(2, 5)]
    public int PowerGrowth = 2;


    public bool isDead;

    void Start()
    {
        PressureSlider.maxValue = MaxPressure;
    }

    
    void Update()
    {
        if(PressureSlider.value <= 0)
        {
            PressureFiller.SetActive(false);
        }
        if(PressureSlider.value > 0)
        {
            PressureFiller.SetActive(true);
        }

        if(!isDead && pressure >= MaxPressure)
        { 
            FindObjectOfType<LevelHandler>().PlayerDie();
            isDead = true;

            Debug.Log("DEATH");
        }


    }

    public void KillPlayer()
    {
        pressure = MaxPressure;
        pressureScreenGrowth();
    }


    public void AddPressure(float distance, float pressureScale)
	{
        pressure += pressureScale;

        pressure = Mathf.Clamp(pressure, 0, MaxPressure);

        Debug.Log(distance);

        PressureSlider.value = pressure;

        pressureScreenGrowth();
	}
    private void pressureScreenGrowth()
    {
        float pValue = 0;
        if (HasLinearGrowth)
        {
            pValue = MaxOpacity * pressure / MaxPressure;

        }
        else
        {
            pValue = MaxOpacity * Mathf.Pow(pressure, PowerGrowth) / Mathf.Pow(MaxPressure, PowerGrowth);
        }

        Color current = Texture.color;
        Texture.color = new Color(current.r, current.g, current.b, pValue);
    }

}

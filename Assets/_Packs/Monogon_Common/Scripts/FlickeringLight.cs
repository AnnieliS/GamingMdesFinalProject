using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    /// <summary>
    /// This script is to create flickering light
    /// </summary>

    private Light FlickerLight;

    [Header("Time")]
    [SerializeField] private bool RandomTime;
    [SerializeField] private float TimeMin;
    [SerializeField] private float Time;
    [SerializeField] private float TimeMax;

    [Header("Intensity")]
    [SerializeField] private bool RandomIntensity;
    [SerializeField] private float IntensityMin;
    [SerializeField] private float Intensity;
    [SerializeField] private float IntensityMax;

    [Header("Range")]
    [SerializeField] private bool RandomRange;
    [SerializeField] private float RangeMin;
    [SerializeField] private float Range;
    [SerializeField] private float RangeMax;

    // Start is called before the first frame update
    void Start()
    {
        FlickerLight = gameObject.GetComponent<Light>();
        StartCoroutine(Flickering());

    }

    // Update is called once per frame
    void Update()
    {
        FlickerLight.intensity = Intensity;
        FlickerLight.range = Range;


    }

    private IEnumerator Flickering() 
    {
        while (true)
        {
            if (RandomTime)
            {
                Time = Random.Range(TimeMin, TimeMax);
            }

            yield return new WaitForSeconds(Time);

            if (RandomIntensity)
            {
                Intensity = Random.Range(IntensityMin, IntensityMax);
            }
            else
            {
                if (Intensity == IntensityMin)
                {
                    Intensity = IntensityMax;
                }
                else
                {
                    Intensity = IntensityMin;
                }
            }

            if (RandomRange)
            {

                Range = Random.Range(RangeMin, RangeMax);
            }
            else
            {
                if (Range == RangeMin)
                {
                    Range = RangeMax;
                }
                else
                {
                    Range = RangeMin;
                }
            }
        }

    }

}

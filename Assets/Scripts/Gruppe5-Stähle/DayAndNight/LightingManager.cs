using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light MainDirectionalLight;
    [SerializeField] private LightingPreset PresetLightScriptableObj;

    //Variables
    private float FactorTime = 240f;
    [SerializeField, Range(0, 240f)] private float TimeOfDay;



    private void Update()
    {

        if (PresetLightScriptableObj == null)
        {
            return;
        }


        if (Application.isPlaying)  //Wenn die Application läuft passiert ...
        {

            TimeOfDay += Time.deltaTime;            //timerDayNight soll im Sekunden Takt hochgezählt werden
            TimeOfDay %= FactorTime;                //Clamp 
            UpdateLighting(TimeOfDay / FactorTime); //Update das Licht
        }
        else
        {
            UpdateLighting(TimeOfDay / FactorTime);
        }
    }

    //Versucht ein Drictional Licht zu finden
    private void UpdateLighting(float timePercent)
    {
        //Setzt das umgebungslicht und den Nebel
        RenderSettings.ambientLight = PresetLightScriptableObj.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = PresetLightScriptableObj.FogColor.Evaluate(timePercent);


        //Wenn das directionale Licht da ist dann wird die Farbe geändert. 
        //Zudem wird das Licht auch Rotiert um einen Schatten dazustellen
        if (MainDirectionalLight != null)
        {
            MainDirectionalLight.color = PresetLightScriptableObj.DirectionalColor.Evaluate(timePercent);
            MainDirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }



    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (MainDirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            MainDirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    MainDirectionalLight = light;
                    return;
                }
            }
        }
    }

}
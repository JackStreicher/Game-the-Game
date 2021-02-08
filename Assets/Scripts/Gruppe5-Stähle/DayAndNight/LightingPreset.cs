using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "ScriptableObjects/Lighting Preset", order = 1)]
public class LightingPreset : ScriptableObject  //Erbt von ScriptableObjects
{
    
    //Gradient um Bestimmung der Farbe von...
    public Gradient AmbientColor;           //... Umgebungsfarbe  
    public Gradient DirectionalColor;       //... Directionales Licht Farbe = Sonne
    public Gradient FogColor;               //... Nebel Farbe 

}

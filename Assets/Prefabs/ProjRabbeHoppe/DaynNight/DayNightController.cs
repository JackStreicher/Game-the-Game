using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public Light Light;
    public int count;
    public bool night = false;
    int yStart = 3500;
    int yEnd = -3500;
    float smooth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count > 10)
        {
            Light.transform.Rotate(new Vector3(0.5f, 0, 0));
            
           //if (Light.intensity > 0.7f)
           //{
           //    night = true;
           //}
           //else if(Light.intensity < 0.1f)
           //{
           //    night = false;
           //}
           //if (night == true)
           //{
           //    
           //    //Light.intensity -= 0.001f;
           //    //Light.transform.position -= new Vector3(100f, 0,0);
           //}
           //else
           //{
           //    //Light.intensity += 0.001f;
           //    //Light.transform.position -= new Vector3(100f, 0, 0);
           //}
           //if(Light.transform.position.x < yEnd)
           //{
           //    //Light.transform.position = new Vector3(yStart, 0, 0);
           //}
            count = 0;
        }
        count++;
    }
}

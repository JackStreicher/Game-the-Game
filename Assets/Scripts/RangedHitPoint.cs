using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedHitPoint : MonoBehaviour
{
    public Camera cam;
    //public Camera camThirdPerson;
    //public Camera camFirstPerson;
    [HideInInspector]
    public Vector3 missleTarget;
    //public float missleRange;
    public GameObject aim;

    private GameObject cameraParent;

    public void Start()
    {
        cameraParent = transform.parent.gameObject;
        missleTarget = aim.transform.position;
        this.transform.position = cam.WorldToScreenPoint(aim.transform.position);
    }


    // Update is called once per frame
    void Update()
    {
        missleTarget = aim.transform.position;       
        ////Shoot a ray through the camera aiming at the Crosshair and get that point in missleRange distance
        //Ray ray = cam.ScreenPointToRay(this.transform.position);
        //
        //Debug.DrawRay(ray.origin, cam.transform.forward + (transform.forward * missleRange), Color.red);
        //
        //missleTarget = cameraParent.transform.rotation * ray.origin + (cam.transform.forward * missleRange);

        //this.transform.position = cam.WorldToScreenPoint(aim.transform.position);

    }




}

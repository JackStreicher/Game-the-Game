using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AnimationController))]
public class Shoot : MonoBehaviour
{
    Animator anim;


    public GameObject projectile;
    public Transform projectileSpawnPos;
    private Vector3 targetPos;
    private AnimationController animContrl;

    int takeAim = Animator.StringToHash("TakeAim");
    int hold = Animator.StringToHash("Hold");
    int fire = Animator.StringToHash("Fire");
    int cancelAttack = Animator.StringToHash("CancelAttack");



    bool isAttackStarted = false;
    bool isHolding = false;

    GameObject projectileRef;


    int cooldownCounter = 0;
    bool canFire = false;

    float drawPower = 5;
    float drawPowerIncrement = 0.75f;
    bool isDrawing = false;

    protected Camera cam;
    protected RangedHitPoint crossHairScript;
    protected GameObject crossHairGO;

    protected float crossHairStartingPos;

    protected float cameraFLMax;
    protected float cameraFLBase;

    public float zoomFactor;

    public void Start()
    {
        anim = transform.GetComponent<Animator>();
        animContrl = transform.GetComponent<AnimationController>();
        targetPos = GameObject.Find("CrossHair").GetComponent<RangedHitPoint>().aim.transform.position;


        cam = GetComponent<PlayerInteraction>().cam;

        crossHairGO = GetComponent<PlayerInteraction>().crossHair;
        crossHairScript = crossHairGO.GetComponent<RangedHitPoint>();

        crossHairStartingPos = crossHairScript.offset.y;


        cameraFLBase = cam.focalLength;
        cameraFLMax = cameraFLBase * zoomFactor;

        Debug.Log(crossHairGO.transform.localScale);
    }

    public void FixedUpdate()
    {
        drawPowerIncrement = projectile.GetComponent<Arrow>().basePower / 60;

        //Cooldown after firing an arrow
        if (!canFire)
        {
            if (cooldownCounter < 30)
            {
                cooldownCounter++;

            }
            else
            {
                cooldownCounter = 0;
                canFire = true;
            }
        }

        if (isDrawing)
        {
            drawPower += drawPowerIncrement;

            drawPower = Mathf.Clamp(drawPower, 20, projectile.GetComponent<Arrow>().basePower);
            //Debug.Log("Current Power " + projectile.GetComponent<Arrow>().basePower);
        }
        else
        {
            drawPower = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (anim.GetCurrentAnimatorClipInfo(1).Length > 0)
        //{
        //    Debug.Log(anim.GetCurrentAnimatorClipInfo(1)[0].clip.name);
        //}

        if (canFire && animContrl.isCombat)
        {



            if (Input.GetMouseButtonDown(0))
            {
                anim.SetLayerWeight(1, 1);
                isAttackStarted = true;
                anim.SetTrigger(takeAim);
                isDrawing = true;

                projectileRef = Instantiate(projectile, projectileSpawnPos);
                projectileRef.GetComponent<Arrow>().parentTrans = projectileSpawnPos;
            }

            if (isAttackStarted)
            {
                //anim.SetLayerWeight(1, 1);
                if (Input.GetMouseButton(0))
                {
                    //anim.ResetTrigger(takeAim);
                    anim.SetTrigger(hold);
                    isHolding = true;

                }
                if (Input.GetMouseButton(3))
                {
                    CancelShooting();
                }
            }

            if (Input.GetMouseButtonUp(0) && (isAttackStarted || isHolding))
            {

                anim.SetTrigger(fire);
                isHolding = false;

                isAttackStarted = false;

                canFire = false;

                projectileRef.GetComponent<Arrow>().SetProjectilePower(drawPower);

                isDrawing = false;
                //Setting the target of the Arrow
                targetPos = GameObject.Find("CrossHair").GetComponent<RangedHitPoint>().missleTarget;

                //Refactor this into a seperate script
                projectileRef.transform.SetParent(null);
                projectileRef.GetComponent<Arrow>().parentTrans = null;
                projectileRef.GetComponent<Arrow>().Fire(targetPos);
                anim.SetTrigger(cancelAttack);

                anim.SetLayerWeight(1, 1);
            }
            if (Input.GetMouseButton(3))
            {
                CancelShooting();
            }
        }

        //if (animContrl.isCombat && isHolding && (Input.GetKey(KeyCode.Escape) || (Input.GetMouseButton(2))))
        //{
        //    CancelShooting();
        //}


        CameraZoom();
    }

    private void CancelShooting()
    {
        anim.SetTrigger(cancelAttack);
        isHolding = false;
        isAttackStarted = false;
        Destroy(projectileRef);
        isDrawing = false;

    }

    public void CameraZoom()
    {

        Debug.Log(animContrl.isCombat);
        if (animContrl.isCombat)
        {
            if (Input.GetMouseButton(1))
            {
                cam.focalLength += 15f * Time.deltaTime;

                crossHairScript.offset -= Vector3.up * 1.5f * Time.deltaTime;
                crossHairGO.transform.localScale -= Vector3.one * 1.5f /15 * Time.deltaTime;

            }
            else
            {
                cam.focalLength -= 40f * Time.deltaTime;

                crossHairScript.offset += Vector3.up * 4f * Time.deltaTime;
                crossHairGO.transform.localScale += Vector3.one * 4f/15 * Time.deltaTime;
            }

            cam.focalLength = Mathf.Clamp(cam.focalLength, cameraFLBase, cameraFLMax);
            crossHairScript.offset.y = Mathf.Clamp(crossHairScript.offset.y, crossHairStartingPos * zoomFactor, crossHairStartingPos);

            crossHairGO.transform.localScale = Vector3.right * Mathf.Clamp(crossHairGO.transform.localScale.x, 0.5f / 5, 1f / 5) +
                Vector3.up * Mathf.Clamp(crossHairGO.transform.localScale.y, 0.5f / 5, 1f / 5) +
                Vector3.forward * Mathf.Clamp(crossHairGO.transform.localScale.z, 0.5f / 5, 1f / 5);
        }
        else
        {
            cam.focalLength = cameraFLBase;
            crossHairScript.offset.y = crossHairStartingPos;
            crossHairGO.transform.localScale = Vector3.one / 5;



        }
    }
}

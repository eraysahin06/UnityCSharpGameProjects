using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public enum tankStates {shooting, hit, moving};
    public tankStates currentState;
    [SerializeField] Transform tankTransform;

    public Animator anim;

    [Header ("Movement")]
    public float moveSpeed;
    public Transform leftTarget, rightTarget;
    bool isRight;

    [Header("Shooting")]
    public GameObject ammo;
    public Transform ammoCenter;
    public float ammoWaitTime;
    float shootCounter;
    [Header("Hit")]
    public float hitTime;
    float hitCounter;

    public GameObject tankCrusherBox;
    private void Start()
    {
        currentState = tankStates.shooting;
    }

    private void Update()
    {
        switch(currentState)
        {
            case tankStates.shooting:
                //when shooting
                shootCounter -= Time.deltaTime;

                if(shootCounter <= 0)
                {
                    shootCounter = ammoWaitTime;
                    var newAmmo = Instantiate(ammo, ammoCenter.position, ammoCenter.rotation);
                    newAmmo.transform.localScale = tankTransform.localScale;
                }    

                break;

                case tankStates.hit:
                //when getting hit

                if(hitCounter > 0)
                {
                    hitCounter -= Time.deltaTime;
                    if(hitCounter <= 0)
                    {
                        currentState = tankStates.moving;
                    }
                }

                break;

            case tankStates.moving:
                //when moving
                if(isRight)
                {
                    tankTransform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if(tankTransform.position.x > rightTarget.position.x)
                    {
                        tankTransform.localScale = Vector3.one;
                       isRight = false;
                        StopMoving();
                    }
                }
                else
                {
                    tankTransform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (tankTransform.position.x < leftTarget.position.x)
                    {
                        tankTransform.localScale = new Vector3(-1, 1, 1);
                        isRight = true;
                        StopMoving();
                    }
                }

                break;

                
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            getHit();
        }
    }

    public void getHit()
    {
        tankCrusherBox.SetActive(true);

        currentState=tankStates.hit;
        
        hitCounter = hitTime;
        
        anim.SetTrigger("Shoot");
    }

    void StopMoving()
    {
        currentState = tankStates.shooting;
        shootCounter = ammoWaitTime;
        anim.SetTrigger("StopMoving");
    }
}

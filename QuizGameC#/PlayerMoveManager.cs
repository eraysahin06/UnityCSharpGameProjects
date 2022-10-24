using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMoveManager : MonoBehaviour
{
    Vector3 whichWay;
    Quaternion turnRotation;
    Animator anim;
    bool isMoving;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    

    public void Move(Vector3 targetPos, float latency = 0.25f)
    {
        if(!isMoving)
        {
            StartCoroutine(MovementRoutine(targetPos, latency));
        }

      
    }
    
    IEnumerator MovementRoutine(Vector3 targetPos, float latency)
    {
        isMoving = true;

        whichWay = new Vector3(targetPos.x - transform.position.x, transform.position.y, targetPos.z - this.transform.position.z);

        turnRotation = Quaternion.LookRotation(whichWay);

        transform.DORotateQuaternion(turnRotation, .2f);

        anim.SetBool("isMove", true);

        yield return new WaitForSeconds(0.2f);

        this.transform.DOMove(targetPos, latency);

        while(Vector3.Distance(targetPos, this.transform.position) > 0.01f)
        {
            yield return null;
        }

        anim.SetBool("isMove", false);

        turnRotation = Quaternion.LookRotation(Vector3.zero);
        transform.DORotateQuaternion(turnRotation, .2f);

        this.transform.position = targetPos;

        isMoving = false;
    }

    public void playerFalseAnswered()
    {
        anim.SetBool("incorrect", true);
    }

    public void PlayerComeBack()
    {
        this.transform.position = Vector3.zero;
        anim.SetBool("incorrect", false);
    }
}

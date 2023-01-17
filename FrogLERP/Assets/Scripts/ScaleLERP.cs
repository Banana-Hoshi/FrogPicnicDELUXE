using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleLERP : MonoBehaviour
{
    //LITTLE NOTE THIS IS NOT SCALE LERP I MISSNAMED THIS ONE, THIS IS IN FACT LERPING AND EASING OF POSITION AND ROTATION 
    Animator animator;
    float currentPos, targetPos;
    [SerializeField] private AnimationCurve curvyBoy;
    [SerializeField] private Vector3 goalPos, startPos, rotationEnd;
    [SerializeField] private float speed = 0.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("leap");
            Invoke("ResetTrigger", 0.2f);
        }

        if (Input.GetMouseButtonDown(0)) targetPos = targetPos == 0 ? 1 : 0;
        currentPos = Mathf.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(startPos, goalPos, curvyBoy.Evaluate(currentPos));
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(rotationEnd), curvyBoy.Evaluate(currentPos));
    }
    void ResetTrigger()
    {
        animator.ResetTrigger("leap");
    }
}

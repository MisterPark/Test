using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public enum AniMotion { Enter, Exit }
    // Start is called before the first frame update
    public UnitStat stats { get; set; }
    //private Rigidbody rigidbody;
    protected virtual void Start()
    {
        stats = GetComponent<UnitStat>();
        //rigidbody = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected bool IsTargetInSight(Vector3 targetPos, float sightAngle = 70f)
    {
        //타겟의 방향 
        Vector3 targetDir = (targetPos - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, targetDir);

        //내적을 이용한 각 계산하기
        // thetha = cos^-1( a dot b / |a||b|)
        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;

        //Debug.Log("타겟과 AI의 각도 : " + theta);
        if (theta <= sightAngle) return true;
        else return false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public virtual void Ani_Jump_Up(AniMotion timing)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // 애니메이션 모션 Jump_Up 시작할 때 호출
                    break;
                }
            case AniMotion.Exit:
                {
                    // 애니메이션 모션 Jump_Up 에서 다른 모션으로 갔을 때 호출
                    break;
                }
        }
    }

    public virtual void Ani_Jump_End(AniMotion timing)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // 애니메이션 모션 Jump_End(착지) 시작할 때 호출
                    break;
                }
            case AniMotion.Exit:
                {
                    // 애니메이션 모션 Jump_End(착지) 에서 다른 모션으로 갔을 때 호출
                    break;
                }
        }
    }

    public virtual void Ani_Run(AniMotion timing)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // 애니메이션 모션 Run 시작할 때 호출
                    break;
                }
            case AniMotion.Exit:
                {
                    // 애니메이션 모션 Run 에서 다른 모션으로 갔을 때 호출
                    break;
                }
        }

    }

}

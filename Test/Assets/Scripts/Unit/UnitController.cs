using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public enum AniMotion { Enter, Update, Exit }
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

    /// <summary>
    /// _otherHost : DamageObject 주인  //
    /// _other : DamageObject  //
    /// _value : 데미지계산후(예정), 체력이 달기 직전의 값
    /// </summary>
    public virtual float Damaged(GameObject _otherHost, GameObject _other, float _value)
    {
        // 데미지 오브젝트가 피해를 입힐 적 오브젝트의 Damaged 를 호출
        // 막기용

        return _value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    /// <summary> 기본 모션 </summary>>
    public virtual void Ani_Idle(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // 애니메이션 모션 Idle 시작할 때 호출
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    // 애니메이션 모션 Idle 에서 다른 모션으로 갔을 때 호출
                    break;
                }
        }
    }
    /// <summary> 걷기 모션 </summary>>
    public virtual void Ani_Walk(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {

                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {

                    break;
                }
        }
    }
    /// <summary> 달리기 모션 </summary>>
    public virtual void Ani_Run(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    
                    break;
                }
        }
    }
    /// <summary> 점프직전모션 </summary>>
    public virtual void Ani_Jump_Up(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // 애니메이션 모션 Jump_Up 시작할 때 호출
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    // 애니메이션 모션 Jump_Up 에서 다른 모션으로 갔을 때 호출
                    break;
                }
        }
    }
    /// <summary> 착지모션 </summary>>
    public virtual void Ani_Jump_End(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // 애니메이션 모션 Jump_End(착지) 시작할 때 호출
                    
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    // 애니메이션 모션 Jump_End(착지) 에서 다른 모션으로 갔을 때 호출
                    break;
                }
        }
    }
    /// <summary> 첫번째 공격 모션 </summary>>
    public virtual void Ani_Attack(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    break;
                }
        }
    }

    public virtual void Ani_Attack_01(AniMotion timing, Animator animator)
    {
        // 첫번째 공격 모션
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    break;
                }
        }
    }
    /// <summary> 두번째 공격 모션 </summary>>
    public virtual void Ani_Attack_02(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    break;
                }
        }
    }
    /// <summary> Block 상태로 들어오고 무기종류에 따라 막기 모션을 결정짓는 중간 단계 (막기 모션은 아님) </summary>>
    public virtual void Ani_Block(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    break;
                }
        }
    }

    public virtual void Ani_Block_02(AniMotion timing, Animator animator)
    {
        // 막고있는 상태
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    break;
                }
        }
    }
    /// <summary> 피격상태로 가기 위한 중간 과정 (무기종류에 따라) </summary>>
    public virtual void Ani_Impact(AniMotion timing, Animator animator)
    {
        //int Impact : -1 노피격상태 // 0 ~ 1 : 피격모션으로 가기위한 중간상태 // 2 : 피격모션(상태)
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    break;
                }
        }
    }
    /// <summary> 피격상태 </summary>>
    public virtual void Ani_Impact_01(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    break;
                }
        }
    }
}

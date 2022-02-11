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
        //Ÿ���� ���� 
        Vector3 targetDir = (targetPos - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, targetDir);

        //������ �̿��� �� ����ϱ�
        // thetha = cos^-1( a dot b / |a||b|)
        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;

        //Debug.Log("Ÿ�ٰ� AI�� ���� : " + theta);
        if (theta <= sightAngle) return true;
        else return false;

    }

    /// <summary>
    /// _otherHost : DamageObject ����  //
    /// _other : DamageObject  //
    /// _value : �����������(����), ü���� �ޱ� ������ ��
    /// </summary>
    public virtual float Damaged(GameObject _otherHost, GameObject _other, float _value)
    {
        // ������ ������Ʈ�� ���ظ� ���� �� ������Ʈ�� Damaged �� ȣ��
        // �����

        return _value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    /// <summary> �⺻ ��� </summary>>
    public virtual void Ani_Idle(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // �ִϸ��̼� ��� Idle ������ �� ȣ��
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    // �ִϸ��̼� ��� Idle ���� �ٸ� ������� ���� �� ȣ��
                    break;
                }
        }
    }
    /// <summary> �ȱ� ��� </summary>>
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
    /// <summary> �޸��� ��� </summary>>
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
    /// <summary> ����������� </summary>>
    public virtual void Ani_Jump_Up(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // �ִϸ��̼� ��� Jump_Up ������ �� ȣ��
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    // �ִϸ��̼� ��� Jump_Up ���� �ٸ� ������� ���� �� ȣ��
                    break;
                }
        }
    }
    /// <summary> ������� </summary>>
    public virtual void Ani_Jump_End(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    // �ִϸ��̼� ��� Jump_End(����) ������ �� ȣ��
                    
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    // �ִϸ��̼� ��� Jump_End(����) ���� �ٸ� ������� ���� �� ȣ��
                    break;
                }
        }
    }
    /// <summary> ù��° ���� ��� </summary>>
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
        // ù��° ���� ���
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
    /// <summary> �ι�° ���� ��� </summary>>
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
    /// <summary> Block ���·� ������ ���������� ���� ���� ����� �������� �߰� �ܰ� (���� ����� �ƴ�) </summary>>
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
        // �����ִ� ����
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
    /// <summary> �ǰݻ��·� ���� ���� �߰� ���� (���������� ����) </summary>>
    public virtual void Ani_Impact(AniMotion timing, Animator animator)
    {
        //int Impact : -1 ���ǰݻ��� // 0 ~ 1 : �ǰݸ������ �������� �߰����� // 2 : �ǰݸ��(����)
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
    /// <summary> �ǰݻ��� </summary>>
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

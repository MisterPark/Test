using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
{
    private Vector3 direction = Vector3.forward;// 캐릭터가 바라보는 방향, 스킬 사용시 사용 
    public Animator animator;
    AnimatorStateInfo aniStateInfo;
    protected override void Start()
    {
        base.Start();
        Physics.gravity = new Vector3(0f, -10f, 0f);
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        aniStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        Block();
        Attack();
        Jump();
        Move();
        Idle();
        Test();
        Calc_Time();
    }

    // Camera 방향으로 Player 방향 변경
    void Forward_readjustment()
    {
        Vector3 forward = transform.position - Camera.main.transform.position;
        forward.y = 0f;
        forward.Normalize();
        transform.LookAt(transform.position + forward);
        direction = transform.forward;
    }

    private void Calc_Time()
    {
        if(stats.invincibilityTime > 0f)
        {
            stats.invincibilityTime -= Time.deltaTime;
        }
    }
    void Jump()
    {
        if (!animator.GetBool("MovePossible"))
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!animator.GetBool("Jump"))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * stats.JumpPower, ForceMode.Impulse);
                animator.SetBool("Jump", true);
            }
        }
        
    }

    void Idle()
    {
        if (!aniStateInfo.IsName("Idle") && animator.GetBool("MovePossible"))
            return;
    }

    void Move()
    {
        if (!animator.GetBool("MovePossible"))
            return;

        Run();
        Vector3 moveDirection = Vector3.zero;
        Vector3 forward = transform.position - Camera.main.transform.position;
        forward.y = 0f;
        forward.Normalize();
        Vector3 right = Vector3.Cross(Vector3.up, forward);

        if (Input.GetKey(KeyCode.W))
        {
            direction += forward;
            moveDirection += forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += -right;
            moveDirection += -right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += -forward;
            moveDirection += -forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += right;
            moveDirection += right;
        }
        // Move
        direction.Normalize();
        moveDirection.Normalize();
        transform.position += stats.MoveSpeed * moveDirection * Time.deltaTime;
        // Rotate
        transform.LookAt(transform.position + direction);

        
        if(moveDirection == Vector3.zero)
            animator.SetBool("Walk", false);
        else
            animator.SetBool("Walk", true);
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && aniStateInfo.IsName("Walk"))
        {
            if (!animator.GetBool("Run"))
            {
                animator.SetBool("Run", true);
                stats.MoveSpeed = stats.RawMoveSpeed * 2f;
            }
        }
    }

    bool Attack()
    {
        // Block : -1 안막음 // 0~1 : 무기종류로 모션구별중 //  2 : 첫번째 공격 // 3 : 두번째 공격
        if (animator.GetInteger("Attack") == -1)
        {
            if (!animator.GetBool("MovePossible"))
                return false;

            if (Input.GetMouseButtonDown(0))
            {
                if (animator.GetBool("MovePossible") && !animator.GetBool("Jump"))
                {
                    //Forward_readjustment();
                    animator.SetInteger("Attack", 0); // 자동으로 MovePossible 도 False (다음 프레임)
                    Vector3 tempPos = gameObject.transform.position + (gameObject.transform.forward * 1.2f);
                    tempPos.y += 0.7f;
                    DamageObjectController.Create_DamageObject(gameObject, UnitStat.Team.Player, tempPos, 1.5f, 1.2f, 15f);
                    return true;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && aniStateInfo.normalizedTime >= 0.4f)
            {
                animator.SetBool("AttackReserve", true);
            }
        }
        return false;
    }

    void Block()
    {
        // Block : -1 안막음 // 0 : 무기종류로 모션구별중 //  1 : 막기 시전모션 // 2 : 막고있음 // 3 : 막기 끝나는 모션 (부자연스러워서 스킵함)
        if (animator.GetInteger("Block") != 2)
        {
            if (!animator.GetBool("MovePossible"))
                return;

            if (Input.GetMouseButtonDown(1))
            {
                if (animator.GetBool("MovePossible") && !animator.GetBool("Jump"))
                {
                    //Forward_readjustment();
                    animator.SetInteger("Block", 0); // 자동으로 MovePossible 도 False (다음 프레임)
                }
            }
        }
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stats.Hp -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            stats.Mp -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            //부활
            if (animator.GetBool("IsDead"))
            {
                animator.SetBool("IsDead", false);
                stats.Hp = stats.MaxHp;      
            }
        }
        //TODO 레그돌, 애니메이션 레이어로 무기종류 등ㄷ으등ㄹ등
    }

    public override void Ani_Run(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    CameraController.Instance.Set_Pov(70f);
                    break;
                }
            case AniMotion.Update:
                {
                    break;
                }
            case AniMotion.Exit:
                {
                    CameraController.Instance.Set_Pov(60f);
                    break;
                }
        }
    }

    public override void Ani_Attack(AniMotion timing, Animator animator)
    {
        // Attack 상태로 들어오고 무기종류에 따라 공격 모션을 결정짓는 중간 단계 (공격 때리는 모션은 아님)
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    animator.SetFloat("AttackSpeed", stats.AttackSpeed);
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
    public override void Ani_Block_02(AniMotion timing, Animator animator)
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
                    if (!Input.GetMouseButton(1))
                    {
                        animator.SetInteger("Block", 3);
                    }
                    break;
                }
            case AniMotion.Exit:
                {
                    break;
                }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            animator.SetBool("Jump", false);
        }
    }

    public override float Damaged(GameObject _otherHost, GameObject _other, float _value)
    {
        if (stats.invincibilityTime > 0f)
            return 0;

        if(animator.GetInteger("Block") == 2)
        {
            if (IsTargetInSight(_otherHost.transform.position))
            {
                _value = 0f;
            }
        }
        if (_value != 0f)
        {
            animator.SetInteger("Impact", 0);
            stats.invincibilityTime = stats.basic_InvincibilityTime;
        }
        return _value;
    }

    public override void Ani_Impact(AniMotion timing, Animator animator)
    {
        switch (timing)
        {
            case AniMotion.Enter:
                {
                    if (stats.Hp <= 0f)
                        animator.SetBool("IsDead", true);
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
    public override void Ani_Death(AniMotion timing, Animator animator)
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

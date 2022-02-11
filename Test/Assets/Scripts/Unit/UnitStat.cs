using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStat : MonoBehaviour
{
    public enum Team { None, Player, Enemy, Natural}
    //public enum State { Idle, Run, Jump }
    //public State state { get; set; }
    [SerializeField] public Team team;
    //public bool JumpCheck;
    [SerializeField] public float MaxHp;
    [SerializeField] public float Hp;
    [SerializeField] public float MaxMp;
    [SerializeField] public float Mp;
    [SerializeField] public float AttackDamage;
    [SerializeField] public float AttackSpeed;

    [SerializeField] public float RawMoveSpeed;
    [HideInInspector] public float MoveSpeed;
    [SerializeField] public float JumpPower;
    [SerializeField] public float basic_InvincibilityTime = 0f;  // 피격당하고 난 뒤 무적시간
    [HideInInspector] public float invincibilityTime = 0f;       // 실시간 돌아가는 무적시간

    private void Start()
    {
        Hp = MaxHp;
        Mp = MaxMp;
        MoveSpeed = RawMoveSpeed;
        AttackSpeed = 1f;
        
    }
}

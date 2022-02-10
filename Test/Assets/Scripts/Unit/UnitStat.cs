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

    private void Start()
    {
        Hp = MaxHp;
        Mp = MaxMp;
        MoveSpeed = RawMoveSpeed;
    }
}

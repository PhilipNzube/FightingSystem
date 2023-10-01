using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class FightSystemManager : MonoBehaviour, ICombatController
{
    [SerializeField] private string attackState;
    private bool isActive;
    private int comboCount = 0;
    private float lastAttackTime;
    public float comboResetTime = 1.5f;
    public FightSystemConfig config;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time - lastAttackTime > comboResetTime && comboCount > 0)
        {
            ResetCombo();
        }
    }


    public void Attack()
    {
        if (comboCount == 0)
        {
            var anim = string.IsNullOrEmpty(config.animationParameter) ? -1 : Animator.StringToHash(config.animationParameter);
            animator.SetTrigger(anim);
        }
        IncrementCombo();
        lastAttackTime = Time.time;
    }

    void IncrementCombo()
    {
        comboCount++;

        if (comboCount > 3)
        {
            ResetCombo(); 
        }
        else
        {
            var anim = string.IsNullOrEmpty(attackState) ? -1 : Animator.StringToHash(attackState);
            animator.SetInteger(anim, comboCount);
        }
    }

    void ResetCombo()
    {
        comboCount = 0;
        var anim = string.IsNullOrEmpty(attackState) ? -1 : Animator.StringToHash(attackState);
        animator.SetInteger(anim, comboCount);
    }
}

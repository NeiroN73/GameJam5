using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : Weapon
{
    public int Damage;

    private void Start()
    {
        playerAnimator.OnEndAnimMop += MAttack;
        CurrentWeaponModel.SetActive(false);
    }
    public override void PlayAnimation()
    {
        playerAnimator.OnAnimMopAttack();
    }

    public void MAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.localPosition + transform.forward, 2);
        foreach (Collider hit in hits)
        {
            
            if (hit.TryGetComponent(out StateAmmunition enemy))
            {
                enemy.Hit(Damage);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition + transform.forward, 2);
    }

}

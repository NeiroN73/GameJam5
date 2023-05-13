using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    private void Start()
    {
        playerAnimator.OnEndAnimHammer += HAttack;
        CurrentWeaponModel.SetActive(false);
    }
    public override void PlayAnimation()
    {
        playerAnimator.OnAnimHammerAttack();
    }

    public void HAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.localPosition + transform.forward, 1);
        foreach (var hit in hits)
        {
            if(hit.TryGetComponent(out DeathOptions enemy) )
            {
                enemy.SacleDead();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition + transform.forward, 1);
    }
}
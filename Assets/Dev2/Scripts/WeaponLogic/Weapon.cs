using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public PlayerAnimator playerAnimator; //later change

    public GameObject CurrentWeaponModel; //change too

    public abstract void PlayAnimation();
}
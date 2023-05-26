using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Humanoid
{
    public void ApplyDamage()
    {
        print("i hited, but i robot");
        CycleSwitcher.Instance.AddDisorderlyConduct();
        Destroy(gameObject);
    }
}

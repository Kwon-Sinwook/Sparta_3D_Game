using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PlayerHp hp;

    private void OnCollisionStay(Collision collision)
    {
        hp.DecreaseHP(0.1f);
    }


}

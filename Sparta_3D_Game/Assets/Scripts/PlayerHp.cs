using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Image HPBar;
    public float curHp;
    public float maxHp = 100;

    private void Start()
    {
        curHp = maxHp;
    }

    private void Update()
    {
        HPBar.fillAmount = GetPercentage();
    }

    private float GetPercentage()
    {
        return curHp / maxHp;
    }

    public void AddHP(float value)
    {
        curHp = curHp + value > maxHp ? maxHp : curHp + value;
    }

    public void DecreaseHP(float value)
    {
        curHp = curHp - value <= 0 ? 0 : curHp - value;
    }

}

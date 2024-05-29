using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractable();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    private float jumpValue = 5f;
    private float speedValue = 4f;


    public string GetInteractable()
    {
        string str = $"{data.ItemName}\n{data.ItemDescription}";
        return str;
    }

    public void OnInteract()
    {
        if (data.ItemName == "Mushroom")
            UseMushroom();

        else UseFlower();
    }

    private void UseMushroom()
    {
        jumpValue = PlayerManager.Instance.Player.controller.jumpForce;
        PlayerManager.Instance.Player.controller.jumpForce = data.value;
    }

    private void UseFlower()
    {
        speedValue = PlayerManager.Instance.Player.controller.moveSpeed;
        PlayerManager.Instance.Player.controller.moveSpeed = data.value;
    }

    private void OnEnable()
    {
        if (data.ItemName == "Mushroom")
            PlayerManager.Instance.Player.controller.jumpForce = jumpValue;

        else PlayerManager.Instance.Player.controller.moveSpeed = speedValue;
    }

}

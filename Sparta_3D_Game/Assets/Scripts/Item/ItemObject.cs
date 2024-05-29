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

        Destroy(gameObject);
    }

    private void UseMushroom()
    {
        PlayerManager.Instance.Player.controller.jumpForce = data.value;
    }

    private void UseFlower()
    {
        PlayerManager.Instance.Player.controller.moveSpeed = data.value;
    }

}

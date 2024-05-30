using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public GameObject testObject;
    public Image itemTime;
    public float tmp;


    public GameObject saveGameObject;
    public bool flag = false;
    public bool onInvoke = false;

    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptText;
    public Camera _camera;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curGameObject)
                {
                    curGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }

        if (flag)
        {
            if (onInvoke)
            {   
                testObject.SetActive(true);
                onInvoke = false;
                Invoke("ReActive", 3.5f);
            }
            tmp -= 28.5f * Time.deltaTime;
            itemTime.fillAmount = tmp / 100f; 
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractable();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();

            saveGameObject = curGameObject;
            curGameObject.SetActive(false);

            flag = true;
            onInvoke = true;

            curGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }

    public void ReActive()
    {
        testObject.SetActive(false);
        tmp = 100f;
        saveGameObject.SetActive(true);
        flag = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        UIManager.instance.craftUi.container = GetComponent<ItemContainer>();
        UIManager.instance.craftUi.onCraftUpdateCallback?.Invoke();

        other.gameObject.GetComponent<Givable>().closest = GetComponent<IGivable>();
        other.gameObject.GetComponent<Givable>().onGivableSetCallback.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (UIManager.instance.craftUi.container.Equals(GetComponent<ItemContainer>()))
        {
            UIManager.instance.craftUi.container = null;
        }

        UIManager.instance.craftUi.onCraftUpdateCallback?.Invoke();

        other.gameObject.GetComponent<Givable>().closest = null;
        other.gameObject.GetComponent<Givable>().onGivableSetCallback?.Invoke();
    }
}

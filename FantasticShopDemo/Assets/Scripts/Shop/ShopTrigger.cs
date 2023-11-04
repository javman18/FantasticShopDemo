using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField]
    private InventoryScreen shopScreen;

    [SerializeField]
    public bool isInTriggerZone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInTriggerZone = true;
            shopScreen.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInTriggerZone = false;
            shopScreen.Hide();
        }
    }
}

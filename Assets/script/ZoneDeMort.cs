using UnityEngine;

public class ZoneDeMort : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.position = SaveData.positionChekpoint;
        }

        if (collision.transform.CompareTag("grenade"))
            Destroy(collision.gameObject);
    }
}

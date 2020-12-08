using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            SaveData.positionChekpoint = transform.position;

            // pour ne pas reprendre le point de controle si on reviens en arriere
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

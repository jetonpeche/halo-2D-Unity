using UnityEngine;

public class SpawnJoueur : MonoBehaviour
{
    private GameObject joueur;
    public static SpawnJoueur instance;

    private void Awake()
    {
        // cherche le GO dans la hiérachie du niveau
        joueur = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {       
        SaveData.positionChekpoint = joueur.transform.position = gameObject.transform.position;
        instance = this;
    }
}

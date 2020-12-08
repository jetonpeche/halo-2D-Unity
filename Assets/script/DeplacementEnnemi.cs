using UnityEngine;

public class DeplacementEnnemi : MonoBehaviour
{
    public int vitesse;
    public Transform[] listPositions;

    private Transform positionDestination;
    private int index;
    private SpriteRenderer sp;
    private GameObject ligneDeVue;

    void Start()
    {
        index = 0;
        positionDestination = listPositions[0];
        sp = GetComponent<SpriteRenderer>();
        // recupere le GO enfant 0
        ligneDeVue = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        // evite d'executer le bloc
        if(vitesse != 0)
        {
            // se deplace jusqu'a la destination
            gameObject.transform.position = Vector3.MoveTowards(transform.position, positionDestination.position, vitesse * Time.deltaTime);

            // change la position suivante quand l'ennemi est presque a la position de destiniation
            if (Vector3.Distance(gameObject.transform.position, positionDestination.position) < 0.3f)
            {
                index = (index + 1) % listPositions.Length;
                positionDestination = listPositions[index];

                if (positionDestination.position.x < gameObject.transform.position.x)
                {
                    sp.flipX = false;

                    // tourne la ligne de vue
                    Quaternion rotation = ligneDeVue.transform.rotation;
                    rotation.y = 0;
                    ligneDeVue.transform.rotation = rotation;
                }
                else
                {
                    sp.flipX = true;

                    // tourne la ligne de vue
                    Quaternion rotation = ligneDeVue.transform.rotation;
                    rotation.y = 180;
                    ligneDeVue.transform.rotation = rotation;
                }
            }
        }      
    }
}

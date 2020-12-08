using System.Collections;
using UnityEngine;

public class SurveillanceEnnemi : MonoBehaviour
{
    public int tempsFlip;
    [HideInInspector]
    public bool isTrue;

    private SpriteRenderer sp;
    private GameObject ligneDeVue;
    private Quaternion rotation;

    private void Start()
    {
        isTrue = true;
        sp = gameObject.GetComponent<SpriteRenderer>();
        ligneDeVue = gameObject.transform.GetChild(0).gameObject;
        rotation = ligneDeVue.transform.rotation;

        StartCoroutine(Survaillance());
    }

    public IEnumerator Survaillance()
    {
        while(isTrue)
        {
            sp.flipX = true;

            rotation.y = 180;
            ligneDeVue.transform.rotation = rotation;

            yield return new WaitForSeconds(tempsFlip);

            sp.flipX = false;

            rotation.y = 0;
            ligneDeVue.transform.rotation = rotation;

            yield return new WaitForSeconds(tempsFlip);
        }
        
    }
}

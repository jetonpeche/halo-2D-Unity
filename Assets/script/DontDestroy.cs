using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] listeObjNePasDetruire;

    public static DontDestroy instance;

    private void Awake()
    {
        NePasDetruire();
    }

    private void Start()
    {
        if (instance != null)
            Debug.Log("Il y a plus d'une instance de DontDestroy");

        instance = this;
    }

    public void NePasDetruire()
    {
        foreach (GameObject element in listeObjNePasDetruire)
        {
            DontDestroyOnLoad(element);
        }
    }

    public void SupprimerDeNePasDetruire()
    {
        foreach(GameObject element in listeObjNePasDetruire)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}

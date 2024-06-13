using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Bowl : MonoBehaviour
{
    public GameObject fullBowl; // Objeto da tigela cheia
    public GameObject emptyBowl; // Objeto da tigela vazia
    public GameObject eKey, cat;
    private CatNeeds catNeeds;
    public bool isFull = false;

    [SerializeField] SceneAsset MinigameScene;

    void Start()
    {
        catNeeds = cat.GetComponent<CatNeeds>();

        // Inicializa a tigela como cheia
        emptyBowl.SetActive(true);
        fullBowl.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            // Debug.Log("Full: " + isFull);
            // Debug.Log("Eating: " + catNeeds.isEating);
            // Debug.Log("Drinking: " + catNeeds.isDrinking);
            if (isFull && !catNeeds.isEating){
                SetBowlEmpty();
            } 
            if (isFull && !catNeeds.isDrinking) {
               SetBowlEmpty(); 
            } 
        }

        else if (other.CompareTag("Player")) 
        {
            if(!isFull && eKey.activeSelf && Input.GetKeyDown(KeyCode.E)) {
                SceneManager.LoadScene(MinigameScene.name);
                SetBowlFull();
            }
        }
    }

    public void SetBowlFull()
    {
        isFull = true;
        emptyBowl.SetActive(false);
        fullBowl.SetActive(true);
    }

    private void SetBowlEmpty()
    {
        isFull = false;
        emptyBowl.SetActive(true);
        fullBowl.SetActive(false);
    }
}

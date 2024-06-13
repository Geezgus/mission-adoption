using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProximity : MonoBehaviour
{

    private Bowl bowl;
    public Image eKey;
    private IndicatorPosition indicadorScript;

    public bool isFood, isWater;

    private const String CAT_TAG = "Cat";
    private const String PLAYER_TAG = "Player";

    void Start() {
        eKey.gameObject.SetActive(false);
        indicadorScript = eKey.gameObject.GetComponent<IndicatorPosition>();

        bowl = GetComponent<Bowl>();
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag) {
            case PLAYER_TAG: {
                if (!bowl.isFull) {
                    eKey.gameObject.SetActive(true);
                    if (isFood) indicadorScript.setOffSet(new Vector3(0.02f, 0.45f, 0));
                    if (isWater) indicadorScript.setOffSet(new Vector3(-0.14f, 0.7f, 0));
                }
                break;
            }
            case CAT_TAG: {

                break;
            }
            default: return;
                
        }
    }

     void OnTriggerStay(Collider other)
    {
        switch (other.tag) {
            case PLAYER_TAG: {
                if (!bowl.isFull)
                    eKey.gameObject.SetActive(true);
                break;
            }
            case CAT_TAG: {

                break;
            }
            default: return;
                
        }
    }

    void OnTriggerExit(Collider other)
    {
       switch (other.tag) {
            case PLAYER_TAG: {
                eKey.gameObject.SetActive(false);
                break;
            }
            case CAT_TAG: {

                break;
            }
            default: return;
                
        }
    }
}

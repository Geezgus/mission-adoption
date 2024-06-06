using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProximity : MonoBehaviour
{
    public Image eKey;

    private const String CAT_TAG = "Cat";
    private const String PLAYER_TAG = "Player";

    void Start() {
        eKey.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag) {
            case PLAYER_TAG: {
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

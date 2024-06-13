using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private bool isPlaying = true;
    [SerializeField] private AudioSource music;

    [SerializeField] private Sprite OnCheckSprite;
    [SerializeField] private Sprite OnUncheckSprite;
    [SerializeField] private Sprite OffCheckSprite;
    [SerializeField] private Sprite OffUncheckSprite;

    [SerializeField] private Image onImage;
    [SerializeField] private Image offImage;
    public void OnOffMusic() {
        isPlaying = !isPlaying;
        music.enabled = isPlaying;

        if (isPlaying) {
            onImage.sprite = OnCheckSprite;
            offImage.sprite = OffUncheckSprite;
        } else {
            onImage.sprite = OnUncheckSprite;
            offImage.sprite = OffCheckSprite;
        }
    }

    public void playSound() {
        if (isPlaying) {
            music.Play();
        }
    }
}

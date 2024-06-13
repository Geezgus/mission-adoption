using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    public GameObject Pt1;
    public GameObject Pt2;
    public GameObject Pt3;
    
    public GameObject Parts;

    public Button NextButton;
    public Button PrevButton;
    public Button PlayButton;

    private int currentPartIndex = 0;

    private GameObject[] parts;

    public Sprite activeIndicator;
    public Sprite inactiveIndicator;

    private Image[] partIndicators;

    void Start()
    {
        parts = new GameObject[] { Pt1, Pt2, Pt3 };
        partIndicators = Parts.GetComponentsInChildren<Image>();

        UpdateStoryPart();

        NextButton.onClick.AddListener(NextPart);
        PrevButton.onClick.AddListener(PrevPart);
        PlayButton.onClick.AddListener(StartGame);

        PauseGame();
    }

    // Atualiza a parte da história exibida
    void UpdateStoryPart()
    {
        foreach (GameObject part in parts)
        {
            part.SetActive(false);
        }

        parts[currentPartIndex].SetActive(true);

        for (int i = 0; i < partIndicators.Length; i++)
        {
            partIndicators[i].sprite = (i == currentPartIndex) ? activeIndicator : inactiveIndicator;
        }

        PrevButton.gameObject.SetActive(currentPartIndex > 0);
        NextButton.gameObject.SetActive(currentPartIndex < parts.Length - 1);
    }

    void NextPart()
    {
        if (currentPartIndex < parts.Length - 1)
        {
            currentPartIndex++;
            UpdateStoryPart();
        }
    }

    void PrevPart()
    {
        if (currentPartIndex > 0)
        {
            currentPartIndex--;
            UpdateStoryPart();
        }
    }

    void StartGame()
    {
        gameObject.SetActive(false);

        Debug.Log("O jogo começou!");
        
        UnpauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f;
    }
}

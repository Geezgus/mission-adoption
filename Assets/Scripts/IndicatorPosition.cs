using UnityEngine;
using UnityEngine.UI;

public class IndicatorPosition : MonoBehaviour
{
    public Transform catTransform; // Referência ao transform do gato
    public Vector3 offset; // Deslocamento para posicionar a imagem acima do gato

    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        UpdateIndicatorPosition();
    }

    void UpdateIndicatorPosition()
    {
        // Converte a posição do gato no mundo para a posição da tela
        Vector3 screenPos = Camera.main.WorldToScreenPoint(catTransform.position + offset);

        // Ajusta a posição do indicador na tela
        rectTransform.position = screenPos;
    }

    public void setOffSet(Vector3 vector3) {
        offset = vector3;
    }
}

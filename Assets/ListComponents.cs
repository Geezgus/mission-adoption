using UnityEngine;
using UnityEngine.UI;  // Necessário para acessar o Button
using TMPro;  // Necessário para acessar o TextMeshPro

public class ListComponents : MonoBehaviour
{
    void Start()
    {
        // Obter o componente Button do GameObject ao qual este script está anexado
        Button button = GetComponent<Button>();

        if (button != null)
        {
            // Listar todos os componentes do botão
            Component[] components = button.GetComponents<Component>();
            
            foreach (Component component in components)
            {
                Debug.Log("Componente encontrado: " + component.GetType());
            }

            // Procurar por TextMeshPro nos filhos do botão
            TextMeshPro buttonText = button.GetComponentInChildren<TextMeshPro>();

            if (buttonText != null)
            {
                Debug.Log("TextMeshPro encontrado: " + buttonText.text);
            }
            else
            {
                Debug.Log("Nenhum TextMeshPro encontrado nos filhos do botão.");
            }
        }
        else
        {
            Debug.Log("Nenhum componente Button encontrado neste GameObject.");
        }
    }
}

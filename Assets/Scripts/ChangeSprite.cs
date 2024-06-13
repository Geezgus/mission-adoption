using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Necessário para acessar o Button e o Text

public class ChangeSprite : StateMachineBehaviour
{
    // Referências para o novo sprite e a nova cor
    public Sprite newSprite;
    public Color newTextColor;

    private Button button;
    private Text buttonText;

    // Este método é chamado quando a transição para o estado acontece
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Encontre o botão associado ao Animator
        button = animator.GetComponent<Button>();

        if (button != null)
        {
            // Altere o sprite do botão
            button.image.sprite = newSprite;

            // Encontre o componente de texto filho do botão
            buttonText = button.GetComponentInChildren<Text>();
            
            if (buttonText != null)
            {
                // Altere a cor do texto
                buttonText.color = newTextColor;
            }
        }
    }

    // Este método é chamado quando a transição para fora do estado acontece
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reverter as alterações se necessário (opcional)
        // button.image.sprite = originalSprite;
        // buttonText.color = originalTextColor;
    }
}

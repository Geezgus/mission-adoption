using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] private GameObject initialPanel;
    [SerializeField] private GameObject configPanel;
    [SerializeField] private GameObject creditsPanel;

    void Start() {
          configPanel.SetActive(false);
          creditsPanel.SetActive(false);
    }

   public void Iniciar() {
    SceneManager.LoadScene(gameScene);
   }

   public void AbrirOpcoes() {
        initialPanel.SetActive(false);
        configPanel.SetActive(true);
   }

   public void FecharOpcoes() {
        configPanel.SetActive(false);
        initialPanel.SetActive(true);
   }

   public void AbrirCreditos() {
        initialPanel.SetActive(false);
        creditsPanel.SetActive(true);
   }

   public void FecharCreditos() {
        creditsPanel.SetActive(false);
        initialPanel.SetActive(true);
   }

   public void Sair() {
        Debug.Log("Sair do jogo");
        Application.Quit();
   }
}

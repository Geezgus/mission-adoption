using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerguntasManager : MonoBehaviour
{
    public GameObject story;
    public GameObject questPanel, visitPanel;
    private StoryController storyController;
    public Text perguntaText;
    public Button botaoSim;
    public Button botaoNao;
    public Text pontuacaoText;

    public TextAsset jsonFile; 
    private List<Pergunta> perguntas;
    private int perguntaAtualIndex = 0;
    private int pontuacao = 0;

    void Start()
    {
        visitPanel.SetActive(false);
        questPanel.SetActive(false);
        gameObject.SetActive(false);
        
        CarregarPerguntasDoJson();

        botaoSim.onClick.AddListener(() => StartQuestions());
        botaoNao.onClick.AddListener(() => EndGame());
        
        MostrarProximaPergunta();
        AtualizarPontuacao();

        storyController = story.GetComponent<StoryController>();
    }

    void StartQuestions() {
        visitPanel.SetActive(false);
        questPanel.SetActive(true);

        botaoSim.onClick.RemoveAllListeners();
        botaoNao.onClick.RemoveAllListeners();
        botaoSim.onClick.AddListener(() => Responder("sim"));
        botaoNao.onClick.AddListener(() => Responder("nao"));
    }
    void CarregarPerguntasDoJson()
    {
        if (jsonFile != null)
        {
            perguntas = JsonUtility.FromJson<PerguntasWrapper>(jsonFile.text).perguntas;
        }
        else
        {
            Debug.LogError("Arquivo JSON não encontrado.");
        }
    }

    void MostrarProximaPergunta()
    {
        if (perguntaAtualIndex < perguntas.Count)
        {
            perguntaText.text = perguntas[perguntaAtualIndex].texto;
        }
        else
        {
            perguntaText.text = "Fim do questionário!";
            botaoSim.gameObject.SetActive(false);
            botaoNao.gameObject.SetActive(false);

            EndGame();
        }
    }

    void Responder(string resposta)
    {
        if (perguntaAtualIndex < perguntas.Count)
        {
            Debug.Log("index: " + perguntaAtualIndex);
            Debug.Log("pergunta: " + perguntas[perguntaAtualIndex].texto);
            Debug.Log("resposta: " + perguntas[perguntaAtualIndex].resposta);

            if (resposta == perguntas[perguntaAtualIndex].resposta)
            {
                pontuacao += perguntas[perguntaAtualIndex].peso;
            }

            perguntaAtualIndex++;
            AtualizarPontuacao();
            MostrarProximaPergunta();
        }
    }

    void AtualizarPontuacao()
    {
        pontuacaoText.text = "Pontuação: " + pontuacao;
    }

    void StartDoctorStage() {
        visitPanel.SetActive(true);
    }

    void EndGame() {
        storyController.CloseAll();
        if(pontuacao >= 20) storyController.GoodEndPanel();
        else                storyController.BadEndPanel();

        this.gameObject.SetActive(false);
    }
}
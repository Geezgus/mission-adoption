using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Clock clock;

    [SerializeField] GameObject vet;
    private PerguntasManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = vet.GetComponent<PerguntasManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clock.Days >= 5)
        {
            print("Game Over");
            manager.StartDoctorStage();
        }
    }
}

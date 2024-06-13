using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CatMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    private CatNeeds catNeeds;

    // Configurações de comportamento
    public float walkSpeed = 1f;
    public float runSpeed = 1.5f;
    public float pauseTimeMin = 5f;
    public float pauseTimeMax = 10f;
    public float minDistance = 2f;
    public float maxDistance = 5f;

    private bool isRunning = false;

    private Vector3 emptyVector = new Vector3(0,0,0);
    private Vector3 goToPosition;

    void Start()
    {
        catNeeds = FindObjectOfType<CatNeeds>();
        StartCoroutine(CatBehavior());
    }

    private IEnumerator CatBehavior()
    {
        while (true)
        {
            goToPosition = catNeeds.GoTo();
            // Decidir andar ou correr
            isRunning = Random.value > 0.5f;

            // Escolher um destino aleatório no NavMesh
            if (VectorDistance(goToPosition, emptyVector)) { 
                Debug.Log("Andando aleatorio");
                Vector3 randomDirection = Random.insideUnitSphere * Random.Range(minDistance, maxDistance);
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, 10, 1);
                Vector3 finalPosition = hit.position;

                // Definir velocidade e destino
                agent.speed = isRunning ? runSpeed : walkSpeed;
                agent.SetDestination(finalPosition);

                // Ajustar animação
                animator.SetBool("isRunning", isRunning);
                animator.SetBool("isWalking", !isRunning);

                // Esperar até chegar ao destino ou mudar de comportamento
                while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
                {
                    yield return null;
                }

                // Pausar por um tempo aleatório
                float pauseTime = Random.Range(pauseTimeMin, pauseTimeMax);
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
                yield return new WaitForSeconds(pauseTime);

            } else {
                Debug.Log("Indo comer");
                NavMeshHit hit;
                NavMesh.SamplePosition(goToPosition, out hit, 10, 1);
                Vector3 finalPosition = hit.position;

                // Definir velocidade e destino
                agent.speed = runSpeed;
                agent.SetDestination(finalPosition);

                // Ajustar animação
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);

                // Esperar até chegar ao destino ou mudar de comportamento
                while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
                {
                    yield return null;
                }

                // Pausar por um tempo aleatório
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);

                while (catNeeds.isEating || catNeeds.isDrinking)
                {
                    yield return null;
                }
            }
        }
    }

    private bool VectorDistance(Vector3 a, Vector3 b, float tolerance = 0.01f)
    {
        return Vector3.Distance(a, b) < tolerance;
    }
}

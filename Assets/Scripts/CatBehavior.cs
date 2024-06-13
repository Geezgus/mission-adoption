using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CatBehavior : MonoBehaviour
{
    public float hunger = 100f;
    public float thirst = 100f;
    public float hungerDecreaseRate = 5f;
    public float thirstDecreaseRate = 3f;
    public float hungerThreshold = 50f;
    public Image hungerIndicator;
    public Image thirstIndicator;
    public Transform foodBowl;

    public Slider hungerSlider;
    public Slider thirstSlider;

    // private NavMeshAgent agent;
    private bool isEating = false;

    void Start()
    {
        // agent = GetComponent<NavMeshAgent>();
        hungerIndicator.gameObject.SetActive(false);
        thirstIndicator.gameObject.SetActive(false);

        hungerSlider.maxValue = 100f;
        hungerSlider.value = hunger;

        thirstSlider.maxValue = 100f;
        thirstSlider.value = thirst;

    }

    void Update()
    {
        if (!isEating)
        {
            hunger -= hungerDecreaseRate * Time.deltaTime;
            hungerSlider.value = hunger;

            thirst -= thirstDecreaseRate * Time.deltaTime;
            thirstSlider.value = thirst;

            if (hunger <= hungerThreshold)
            {
                hungerIndicator.gameObject.SetActive(true);
            }
            if ( thirst <= hungerThreshold) 
            {
                thirstIndicator.gameObject.SetActive(true);
            }
        }
    }

    // public void GoToFoodBowl()
    // {
    //     if (!isEating)
    //     {
    //         isEating = true;
    //         agent.SetDestination(foodBowl.position);
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FoodBowl"))
        {
            Eat();
        }
    }

    void Eat()
    {
        hunger = 100f;
        hungerIndicator.gameObject.SetActive(false);
        isEating = false;
    }
}

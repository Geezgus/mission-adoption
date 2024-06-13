using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CatNeeds : MonoBehaviour
{
    public float hunger = 100f;
    public float thirst = 100f;
    public float hungerDecreaseRate = 5f;
    public float thirstDecreaseRate = 3f;
    public float hungerThreshold, thirstThreshold = 50f;
    public Image hungerIndicator;
    public Image thirstIndicator;
    public Transform foodPos, waterPos;

    public Slider hungerSlider;
    public Slider thirstSlider;
    public GameObject foodObj, waterObj;

    private NavMeshAgent agent;
    private Bowl foodScript, waterScript;
    public bool isEating, isDrinking = false;
    private bool goingEat, goingDrink = false;
    private bool onFoodBowl, onWaterBowl = false;

    [SerializeField] Clock clock;
    float lastHour = -1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if(foodObj != null) foodScript = foodObj.GetComponent<Bowl>();
        if(waterObj != null) waterScript = waterObj.GetComponent<Bowl>();

        hungerIndicator.gameObject.SetActive(false);
        thirstIndicator.gameObject.SetActive(false);

        hungerSlider.maxValue = 100f;
        hungerSlider.value = hunger;

        thirstSlider.maxValue = 100f;
        thirstSlider.value = thirst;

    }

    void Update()
    {
        if (lastHour != clock.Hours % 24)
        {
            print(clock.Hours);
            lastHour = clock.Hours % 24;

            hunger = Mathf.Max(hunger - (hungerSlider.maxValue / 12f), 0);
            hungerSlider.value = hunger;

            thirst = Mathf.Max(thirst - (thirstSlider.maxValue / 18f), 0);
            thirstSlider.value = thirst;
        }

        if (hunger <= hungerThreshold)
        {
            hungerIndicator.gameObject.SetActive(true);
            goingEat = true;
        }
        else if ( thirst <= thirstThreshold) 
        {
            thirstIndicator.gameObject.SetActive(true);
            goingDrink = true;
        }
        
        
        // if (!isEating)
        // {
        //     if(hunger > 0f) hunger -= hungerDecreaseRate * Time.deltaTime;
        //     hungerSlider.value = hunger;

            
        
           
        // }

        // if (!isDrinking)
        // {
        //     if(thirst > 0f ) thirst -= thirstDecreaseRate * Time.deltaTime;
        //     thirstSlider.value = thirst;
        //      

        // }

        if(isEating && hunger <= 100f && onFoodBowl) Eat();
        if(isDrinking && thirst <= 100f && onWaterBowl) Drink();
        
    }

    public Vector3 GoTo()
    {
        if (!isEating && goingEat && foodScript.isFull)
        {
            isEating = true;
            goingEat = false;

            return foodPos.position;
        } 
        
        if (!isDrinking && goingDrink && waterScript.isFull)
        {
            isDrinking = true;
            goingDrink = false;

            return waterPos.position;
        }

        return new Vector3(0, 0, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FoodBowl"))   onFoodBowl = true;
        if (other.CompareTag("WaterBowl"))   onWaterBowl = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FoodBowl"))   onFoodBowl = false;
        if (other.CompareTag("WaterBowl"))   onWaterBowl = false;
    }

    void Eat()
    {
        hunger += 10f * Time.deltaTime;
        hungerSlider.value = hunger;

        if(hunger >= 100f) {
            hungerIndicator.gameObject.SetActive(false);
            isEating = false;
        }
    }

    void Drink()
    {
        thirst += 10f * Time.deltaTime;
        thirstSlider.value = thirst;

        if(thirst >= 100f) {
            thirstIndicator.gameObject.SetActive(false);
            isDrinking = false;
        }
    }
}

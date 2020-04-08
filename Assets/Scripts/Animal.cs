using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Animal : MonoBehaviour
{
    public FoodType[] acceptableFood;

    //State
    private Animator animator;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryFeed(Food food) {
        if (food == null || !food.isFlying)
        {
            return;
        }

        if (DoesAcceptFoodType(food.foodType))
        {
            animator.SetTrigger("Accept");
            print(name + " accepted food");
        }
        else
        {
            animator.SetTrigger("Reject");
            print(name + " rejected food");
        }
    }

    public bool DoesAcceptFoodType(FoodType food)
    {
        return acceptableFood.Contains(food);
    }
}

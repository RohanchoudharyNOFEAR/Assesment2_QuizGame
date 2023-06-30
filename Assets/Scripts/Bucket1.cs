using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket1 : MonoBehaviour
{

    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager =(GameManager)GameObject.Find("GameManager").GetComponent("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        Debug.Log("yes");
        CardsInfo cardInstance = (CardsInfo)collision.gameObject.GetComponent("CardsInfo");
        if (manager.currentQues == QuizType.OnBasisofAbilityToFly)
        {
           if(cardInstance.isFlying)
            {
               
                manager.Score += 1;
            }
           else
            {
                manager.Score -= 1;
            }
        }
        else if (manager.currentQues == QuizType.OnBasisOfFood)
        {
            if (cardInstance.isHerbivorous)
            {
              
                manager.Score += 1;
            }
            else
            {
                manager.Score -= 1;
            }
        }
        else if (manager.currentQues == QuizType.OnBasisofGivingBirth)
        {
            if (cardInstance.isLayEggs)
            {
              
                manager.Score += 1;
            }
            else
            {
                manager.Score -= 1;
            }
        }
        else if (manager.currentQues == QuizType.OnBasisofType)
        {
            if (cardInstance.isInsect)
            {
              
                manager.Score += 1;
            }
            else
            {
                manager.Score -= 1;
            }
        }
        else if (manager.currentQues == QuizType.OnBasisofLiving)
        {
            if (cardInstance.isLivesINGroups)
            {
              
                manager.Score += 1;
            }
            else
            {
                manager.Score -= 1;
            }
        }
        Destroy(collision.gameObject,1f);
        manager.targetsCount--;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum QuizType
{
    OnBasisOfFood,
    OnBasisofAbilityToFly,
    OnBasisofType,
    OnBasisofLiving,
    OnBasisofGivingBirth
}

public class GameManager : MonoBehaviour
{

    public QuizType currentQues;
    public TMP_Text Bucket1Text;
    public TMP_Text Bucket2Text;
    public GameObject GameOverPanel;
    public TMP_Text ScoreText;
    public GameObject InfoPanel;
    private Vector2 clickOffset = Vector2.zero;
    private bool offsetCaluated = false;
    [SerializeField]
    private int _score = 0;
    public int Score { get { return _score; } set { _score = value; } }

    public int targetsCount = 18;
    // Start is called before the first frame update
    void Start()
    {
        GetRandomQuiz();


    }

    // Update is called once per frame
    void Update()
    {
        if (targetsCount == 0)
        {
            GameOverPanel.SetActive(true);
            ScoreText.text = "Score : " + _score;
        }
    }

    void GetRandomQuiz()
    {
        int randomquiznum = Random.Range(0, 5);

        currentQues = (QuizType)randomquiznum;

        if (currentQues == QuizType.OnBasisofAbilityToFly)
        {
            Bucket1Text.text = "Flying";
            Bucket2Text.text = "Non Flyting";
        }
        else if (currentQues == QuizType.OnBasisOfFood)
        {
            Bucket1Text.text = "Herbivores";
            Bucket2Text.text = "Omnivorous";
        }
        else if (currentQues == QuizType.OnBasisofGivingBirth)
        {
            Bucket1Text.text = "Lay Eggs";
            Bucket2Text.text = "Give Birth";
        }
        else if (currentQues == QuizType.OnBasisofType)
        {
            Bucket1Text.text = "Insect";
            Bucket2Text.text = "Non Insect";
        }
        else if (currentQues == QuizType.OnBasisofLiving)
        {
            Bucket1Text.text = "Lives in Group";
            Bucket2Text.text = "Solo";
        }


    }

    public void CloseInfoPanel()
    {
        InfoPanel.SetActive(false);
    }

    void MoveTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitinfo))
            {


                if (hitinfo.collider.gameObject.GetComponent<Targets>() != null)
                {
                    offsetCaluated = false;
                    clickOffset = Vector2.zero;
                }
            }

        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitinfo))
            {

                Debug.Log("raycast");
                if (hitinfo.collider.gameObject.GetComponent<Targets>() != null)
                {

                    var TargetInstance = hitinfo.collider.gameObject;
                    if (!offsetCaluated)
                    {
                        clickOffset = hitinfo.point - TargetInstance.transform.position;
                        offsetCaluated = true;
                    }

                    Debug.Log(TargetInstance.name);

                    TargetInstance.transform.position = new Vector2(hitinfo.point.x - clickOffset.x, hitinfo.point.y - clickOffset.y)/* hitinfo.point*/;
                }
            }
        }
    }

}

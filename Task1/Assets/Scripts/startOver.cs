using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startOver : MonoBehaviour
{
    public Text text;

    // Use this for initialization
    void Start()
    {
        if (GameController.firstPlayerScoreCounter > GameController.secondPlayerScoreCounter)
        {
            text.text = "First Player Won !!!";
        }
        else if (GameController.firstPlayerScoreCounter < GameController.secondPlayerScoreCounter)
        {
            text.text = "Second Player Won !!!";
        }
        else if (GameController.firstPlayerScoreCounter == 0 && GameController.secondPlayerScoreCounter == 0)
        {
            text.text = "Pong";
        }
        else
        {
            text.text = "Draw";
        }
        GameController.firstPlayerScoreCounter = 0;
        GameController.secondPlayerScoreCounter = 0;
        StartCoroutine(BlinkTimer());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            SceneManager.LoadScene("ball");
    }

    IEnumerator BlinkTimer()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ball");

    }
}

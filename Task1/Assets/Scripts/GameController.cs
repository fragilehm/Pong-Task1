using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public GameObject ballTemplate;

    public Text firstPlayerScore;
    public Text secondPlayerScore;

    public static int firstPlayerScoreCounter;
    public static int secondPlayerScoreCounter;
    private new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerExit(Collider other)
    {
        GameObject gameObject =
                other.gameObject;

        if (gameObject.CompareTag("Ball"))
        {
            GameObject ball = gameObject;

            if (ball.transform.position.z < transform.position.z)
            {
                ++firstPlayerScoreCounter;
                firstPlayerScore.text =
                        firstPlayerScoreCounter.ToString();
            }
            else
            {
                ++secondPlayerScoreCounter;
                secondPlayerScore.text =
                        secondPlayerScoreCounter.ToString();
            }
            if (firstPlayerScoreCounter == 11 || secondPlayerScoreCounter == 11)
                SceneManager.LoadScene("end");
            audio.Play();
            Destroy(ball);
            Instantiate(ballTemplate);
        }
    }

}
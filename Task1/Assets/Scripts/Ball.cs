using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float InputForceScale = 20f;
    public float InitialAngle = 45;

    public AudioClip WallSound;
    public AudioClip PaddleSound;
    private AudioSource audioSource;
    private Rigidbody rigidBody;
    private int delayTime = 3;
    static int aFirst = 0;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        if (aFirst != GameController.firstPlayerScoreCounter)
        {
            Vector3 force = Quaternion.Euler(0, Random.Range(20f, 45f), 0) * Vector3.forward;
            force = force * InputForceScale;
            rigidBody.AddForce(force);
        }

        else
        {
            Vector3 force = Quaternion.Euler(0, Random.Range(20f, 45f), 0) * Vector3.back;
            force = force * InputForceScale;
            rigidBody.AddForce(force);
        }



        aFirst = GameController.firstPlayerScoreCounter;
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator BlinkTimer()
    {
        yield return new WaitForSeconds(delayTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.CompareTag("Walls"))
        {
            audioSource.PlayOneShot(WallSound);
        }
        else if (gameObject.CompareTag("Paddle"))
        {
            audioSource.PlayOneShot(PaddleSound);
        }
    }
}
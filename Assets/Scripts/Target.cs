using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float XRange = 4;
    private float YSpawnPos = -6;
    public int pointValue;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);    // Set ascending force
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);  // Set rotating force

        transform.position = RandomPostition();     // Set target's position
    }


    private void Update()
    {
        if(PauseScreen.paused)
            return;
    }

    private void PlayerTouch()
    {
        if (gameManager.isGameActive)
        {
            Destroy(this.gameObject);
            Instantiate(particle, transform.position, particle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(this.gameObject);
            Instantiate(particle, transform.position, particle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomPostition()
    {
        return new Vector3(Random.Range(-XRange, XRange), YSpawnPos, 0);
    }
}

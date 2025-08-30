using UnityEngine;
using System;
using System.Collections;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject beePrefab;

    public static int beesAlive = 0;

    private float concurrency = 0.3f;
    private float timeToNextBee = 0;

    private float timeToNextBurst = 2f;
    private float timeToNextBurstPattern3 = 0.3f;
    private float nextBeeAngle = 180f;

    private float nextPattern = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToNextBee = concurrency;
    }

    // Update is called once per frame
    void Update()
    {
        nextPattern += Time.deltaTime;
        if (nextPattern < 10)
        {
            pattern1();
        }
        else if (nextPattern >= 10 && nextPattern < 20)
        {
            pattern2();
        }
        else if (nextPattern >= 20 && nextPattern < 30)
        {
            pattern3();
        }
    }

    void pattern1()
    {
        timeToNextBee -= Time.deltaTime;
        if (timeToNextBee <= 0f)
        {

            for (int i = 0; i < 5; i++)
            {
                float angle = nextBeeAngle + i * 72;
                Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

                GameObject bee = Instantiate(beePrefab, transform.position, rotation);
                beesAlive++;
                StartCoroutine(DecreaseBeeCount(3f));
                Destroy(bee, 3f);
            }

            timeToNextBee = concurrency;

            nextBeeAngle += 10;
        }
    }
    void pattern2()
    {
        int numberOfBees = 50;

        timeToNextBurst -= Time.deltaTime;
        if (timeToNextBurst <= 0f)
        {
            for (int i = 0; i < numberOfBees; i++)
            {
                float angle = i * 360f / numberOfBees;
                Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

                GameObject bee = Instantiate(beePrefab, transform.position, rotation);
                beesAlive++;
                StartCoroutine(DecreaseBeeCount(3f));
                Destroy(bee, 3f);
            }

            timeToNextBurst = 2f;
        }


    }

void pattern3()
{
    timeToNextBee -= Time.deltaTime;
    if (timeToNextBee <= 0f)
    {
        for (int i = 0; i < 2; i++)
        {
            float angle;
                if (i == 0)
                {
                    angle = nextBeeAngle;
                }
                else
                {
                    angle = nextBeeAngle * -1;
            }
            Quaternion rotation = Quaternion.Euler(0f, angle + 90, 0f);

            GameObject bee = Instantiate(beePrefab, transform.position, rotation);
            beesAlive++;
            StartCoroutine(DecreaseBeeCount(3f));
            Destroy(bee, 3f);
        }
        nextBeeAngle += 15f;

        timeToNextBee = concurrency;
    }
}

    IEnumerator DecreaseBeeCount(float delay)
    {
        yield return new WaitForSeconds(delay);
        beesAlive--;
    }

}

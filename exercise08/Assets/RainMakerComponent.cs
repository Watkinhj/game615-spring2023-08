using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMakerComponent : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    //float createBallTimer;
    [SerializeField] float createBallRate = 1.5f;

    bool canDropGrape = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateRain());

        //createBallTimer = createBallRate;
    }

    // Update is called once per frame
    void Update()
    {
        //createBallTimer = createBallTimer - Time.deltaTime;
        //if (createBallTimer < 0)
        //{
        //    Vector3 somePosition = gameObject.transform.position;
        //    Instantiate(ballPrefab, somePosition, Quaternion.identity);
        //    createBallTimer = createBallRate;
        //}

        if (canDropGrape && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CreateRain());
        }
    }

    IEnumerator CreateRain()
    {
        canDropGrape = false;

        Vector3 somePosition = gameObject.transform.position;
        Instantiate(ballPrefab, somePosition, Quaternion.identity);

        yield return new WaitForSeconds(createBallRate);

        canDropGrape = true;
    }
}

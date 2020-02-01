using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject meteor;
    public int meteorNum;
    public int velocityMultiplier;

    float timer;
    int wholeTimer;
    Rigidbody m_Rigidbody;
    GameObject spawnedMeteor;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= meteorNum; i++)
        {
            float randomTheta = Random.value * Mathf.PI * 2;
            float randomX = Mathf.Cos(randomTheta)*15;
            float randomZ = Mathf.Sin(randomTheta)*15;

            Vector3 randomPosition = new Vector3(randomX, 0, randomZ);
            spawnedMeteor = Instantiate(meteor, randomPosition, Quaternion.identity, transform);

            Vector3 velocity = (-randomPosition).normalized;
            spawnedMeteor.GetComponent<Rigidbody>().velocity = velocity * velocityMultiplier;
        }

        m_Rigidbody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        wholeTimer = (int)timer;

        //if (wholeTimer % 2 == 0) // on even
        //{
        //    float randomX = Random.Range(-15, 15);
        //    float randomZ = Random.Range(-15, 15);

        //    Vector3 randomPosition = new Vector3(randomX, 0, randomZ);
        //    Instantiate(meteor, randomPosition, Quaternion.identity, transform);
        //
    }
}

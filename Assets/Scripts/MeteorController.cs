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
            float randomX = Random.Range(-15, 15);
            float randomZ = Random.Range(-15, 15);

            Vector3 randomPosition = new Vector3(randomX, 0, randomZ);
            spawnedMeteor = Instantiate(meteor, randomPosition, Quaternion.identity, transform);

            Vector3 randomVelocity = new Vector3(randomX / 15, 0, randomZ / 15);
            spawnedMeteor.GetComponent<Rigidbody>().velocity = randomVelocity * velocityMultiplier;
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

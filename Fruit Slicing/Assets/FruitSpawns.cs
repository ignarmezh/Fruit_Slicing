using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawns : MonoBehaviour {

    public GameObject fruitPrefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnFruits());
	}
	
    IEnumerator SpawnFruits ()
    {
        while (true)
        {
            float delay = Random.Range(minDelay,maxDelay);
            yield return new WaitForSeconds(2f);
            //Spawn Fruits

            int spawnIndex = Random.Range(0,spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject fruit = Instantiate(fruitPrefab,spawnPoint.position, spawnPoint.rotation);
            Destroy(fruit,5f);
        }
    }
}

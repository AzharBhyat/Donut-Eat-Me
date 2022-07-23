using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkSpawner : MonoBehaviour
{

    [SerializeField] private GameObject smallForkPrefab;
    [SerializeField] private GameObject regularForkPrefab;
    [SerializeField] private GameObject bigForkPrefab;

    [SerializeField] private GameObject frostingPrefab;

    [SerializeField] private GameObject coffeeCupPrefab;

    [SerializeField] private GameObject sprinklesPrefab;

    [SerializeField] private float smallInterval = 1.5f;
    [SerializeField] private float regularInterval = 1.3f;
    [SerializeField] private float bigInterval = 1.2f;
 
    void Start()
    {

        StartCoroutine(spawnFork(smallInterval, smallForkPrefab));
        StartCoroutine(spawnFork(regularInterval, regularForkPrefab));
        StartCoroutine(spawnFork(bigInterval, bigForkPrefab));
        StartCoroutine(spawnFrosting(Random.Range(9f, 13f), frostingPrefab));
        StartCoroutine(spawnSprinkles(Random.Range(7f, 16f), sprinklesPrefab));
        StartCoroutine(spawnCoffee(Random.Range(17f, 21f), coffeeCupPrefab));

    }

    private IEnumerator spawnFork(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-3.9f, 3.9f), 16, 0), Quaternion.identity);
        StartCoroutine(spawnFork(interval, enemy));
    }
    private IEnumerator spawnFrosting(float interval, GameObject frosting)
    {
        yield return new WaitForSeconds(interval);
        GameObject newFrosting = Instantiate(frosting, new Vector3(Random.Range(-4f, 4f), 16, 0), Quaternion.identity);
        StartCoroutine(spawnFrosting(interval, frosting));
    }
    private IEnumerator spawnCoffee(float interval, GameObject coffee)
    {
        yield return new WaitForSeconds(interval);
        GameObject newCoffee = Instantiate(coffee, new Vector3(Random.Range(-4f, 4f), 16, 0), Quaternion.identity);
        StartCoroutine(spawnCoffee(interval, coffee));
    } 

    private IEnumerator spawnSprinkles(float interval, GameObject sprinkles)
    {
        yield return new WaitForSeconds(interval);
        GameObject newSprinkles = Instantiate(sprinkles, new Vector3(Random.Range(-4f, 4f), 16, 0), Quaternion.identity);
        StartCoroutine(spawnSprinkles(interval, sprinkles));
    }
}

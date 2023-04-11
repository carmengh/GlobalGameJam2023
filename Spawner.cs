using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Bug;
    public int enemyTime = 10;
    int enemyLimit = 5;
    int enemyNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyTime, Bug));
    }
    private IEnumerator spawnEnemy(int interval, GameObject enemy){
        if (enemyNumber <= enemyLimit){
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-9,10), Random.Range(-5,-4),0), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
            enemyNumber++;
        }
    }

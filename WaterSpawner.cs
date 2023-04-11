using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject water;
    public int waterTime = 2;
    void Start()
    {
        StartCoroutine(spawnEnemy(waterTime, water));
    }
    private IEnumerator spawnEnemy(int interval, GameObject water){
        yield return new WaitForSeconds(interval);
        GameObject newWater = Instantiate(water, new Vector3(Random.Range(-9,10), Random.Range(-5,-4),0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, water));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

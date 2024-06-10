using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;

    private void Start(){
        StartCoroutine(Spawners());
    }    

    private IEnumerator Spawners(){
        int rands = Random.Range(0,enemyPrefabs.Length);
        GameObject enemyToSpawns = enemyPrefabs[rands];
        Instantiate(enemyToSpawns,transform.position,Quaternion.identity);
        
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        
        while(canSpawn){
            yield return wait;
            int rand = Random.Range(0,enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            Instantiate(enemyToSpawn,transform.position,Quaternion.identity);            
        }

    }
}

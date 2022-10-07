using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] FruitsPrefabs;
    [SerializeField] float SecondSpawn = 0.5f;
    [SerializeField] float MinTras;
    [SerializeField] float MaxTras;
    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn()
    {
        while (true)
        {
            var Wanted = Random.Range(MinTras, MaxTras);
            var Position = new Vector3(Wanted, transform.position.y);   
            GameObject GameObj = Instantiate(FruitsPrefabs[Random.Range(0,FruitsPrefabs.Length)],Position,Quaternion.identity);
            yield return new WaitForSeconds(SecondSpawn);
            Destroy(GameObj, 5f);
        }
    }

   
}

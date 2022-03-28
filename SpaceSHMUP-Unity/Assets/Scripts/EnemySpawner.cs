/**** 
 * Created by: Josh Sutton
 * Date Created: March 28, 2022
 * 
 * Last Edited by: N/A
 * Last Edited: March 28, 2022
 * 
 * Description: Spawns enemies
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Variables
    [Header("Enemy Settings")]
    public GameObject[] prefabEnemies; //array of enemy prefabs
    public float enemySpawnPerSecond; //enemy count to spawn per second
    public float enemyDefaultPadding; //padding for enemy position;

    private BoundsCheck boundCheck; //reference to the bounds check component
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        boundCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }//end Start()

    void SpawnEnemy()
    {
        //picks a random enemy prefab and instantiates
        int ndx = Random.RandomRange(0, prefabEnemies.Length); 
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        //position the enemy above the screen
        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //set the initial position for the enemy
        Vector3 pos = Vector3.zero;
        float xMin = -boundCheck.camWidth + enemyPadding;
        float xMax = boundCheck.camWidth - enemyPadding;
        pos.x = Random.RandomRange(xMin, xMax);
        pos.y = boundCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }//end SpawnEnemy()
}

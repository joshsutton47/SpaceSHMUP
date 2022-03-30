/**** 
 * Created by: Josh Sutton
 * Date Created: March 30, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 30, 2022
 * 
 * Description: Projectile controller
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    void Update()
    {
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }        
    }
}

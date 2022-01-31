using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Ada");
    }

}

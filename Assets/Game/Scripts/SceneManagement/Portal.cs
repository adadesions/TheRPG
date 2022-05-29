using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheRPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] int targetSceneIndex = 0;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(targetSceneIndex);
            }
        }
    }
}

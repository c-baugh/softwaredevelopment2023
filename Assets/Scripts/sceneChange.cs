using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public int sceneBuildIndex;
    //Random r = new Random();

    private void OnTriggerEnter2D(Collider2D other) {

        sceneBuildIndex = Random.Range(1,5);

        if (other.tag == "Player"){
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public int sceneBuildIndex;
    public int numRooms;

    private void OnTriggerEnter2D(Collider2D other) {

        sceneBuildIndex = Random.Range(1,4);

        if (other.tag == "Player"){
            if (numRooms == 6){
                sceneBuildIndex = 5;
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
            else{
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                numRooms++;
            }
        }
        
    }
}

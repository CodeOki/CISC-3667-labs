using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistractorDestroy : MonoBehaviour
{
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            GameObject.Find("Explosion").GetComponent<ExplosionSound>().playAudio();
            Destroy(gameObject);
            Destroy(collider.gameObject);
            nextScene();
        }
    }

    public void nextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
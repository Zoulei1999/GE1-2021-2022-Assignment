using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Player"){
            FindObjectOfType<GameManager>().AddScore(score);// code to add score to score which is managed by game manager
            
            Destroy(gameObject); //deletes the object based on collison.
        }
    }
}

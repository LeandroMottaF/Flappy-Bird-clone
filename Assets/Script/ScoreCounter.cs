using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    ScoreManager score_manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score_manager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {


        score_manager.score_ += 1; 


    }
}

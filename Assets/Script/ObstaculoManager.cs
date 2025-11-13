using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaculoManager : MonoBehaviour
{

    public GameObject obstaculo;
    float cooldown_;
    bool podeSpawnar = true;
    ScoreManager score_velocidade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        score_velocidade = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (podeSpawnar == true)
        {
            Cooldown();
        }

    }

    void SpawnObstacle()
    {

        Instantiate(obstaculo, new Vector3(10, Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);


    }
    void Cooldown()
    {

        if(cooldown_ <= 0)
        {

            SpawnObstacle();
            cooldown_ += (3 - (score_velocidade.score_ / 10));

        }
        else
        {
            cooldown_ -= Time.deltaTime;
        }

    }

    public void PararSpawn()
    {
        podeSpawnar = false;
    }

}

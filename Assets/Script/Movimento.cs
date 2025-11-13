using Unity.VisualScripting;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float impulso_;
    public GameObject game_over;
    Rigidbody2D rb;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()

    {
        SpaceMove();
   

    }
    void SpaceMove()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

        gameObject.GetComponent <Rigidbody2D>().AddForce(Vector2.up*impulso_, ForceMode2D.Impulse);
            

        
        }

        if(rb.linearVelocity.y > 10f)
        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f);

        }

    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Wall")
        {

            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.linearVelocity = Vector2.zero;

            rb.gravityScale = 0;

            this.enabled = false;

            game_over.SetActive(true);
            PararTodosOsObstaculos();

        }

        else if (collision.gameObject.tag =="Ceiling")
        {
            

            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.gravityScale = 5;

            rb.linearVelocity = Vector2.down * 3;

            this.enabled = false;

            PararTodosOsObstaculos();


        }
        else if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.gravityScale = 5;

            rb.linearVelocity = Vector2.down * 3;

            this.enabled = false;

            game_over.SetActive(true);
            PararTodosOsObstaculos();
        }

    }

 


    void PararTodosOsObstaculos()
    {
        NewMonoBehaviourScript[] obstaculos = FindObjectsByType<NewMonoBehaviourScript>(FindObjectsSortMode.None);

        foreach (NewMonoBehaviourScript o in obstaculos)
        {
            o.Parar();

        }

        ObstaculoManager spawner = FindAnyObjectByType<ObstaculoManager>();
        if (spawner != null)
        {
            spawner.PararSpawn();
        }

    }


}


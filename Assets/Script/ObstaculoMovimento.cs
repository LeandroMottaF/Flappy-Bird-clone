using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float velocidade;
    bool parar = false;
    bool destruirAtivado = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Invoke(nameof(Autodestruir), 10);

    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    void Autodestruir()
    {
        if (destruirAtivado)
            Destroy(this.gameObject);
    }

    void Movimento()
    {
        if(parar == false) 
        { 

            transform.position += new Vector3(-velocidade * Time.deltaTime, 0, 0);


        }

    }

    public void Parar()
    {
        parar = true;
        destruirAtivado = false;

    }


}
        
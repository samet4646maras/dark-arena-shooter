using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed = 40f;
    Vector3 direction;



    private void Start()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);


    }
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyMovement enmyScript = other.GetComponent<EnemyMovement>();
        if(!other.gameObject.CompareTag("Player"))
        {
             Destroy(gameObject);
        }
       
        if (enmyScript != null)
        {
            enmyScript.HpSense();

        }
        
    }
}

using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform Player;
    public float speed = 4f;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        
        EnemyRotation();
        EnemyPosition();

    }

    void EnemyRotation()
    {
        Vector3 direction = Player.position - transform.position;
        direction.y = 180f;
        transform.rotation = Quaternion.LookRotation(direction);

    }

    void EnemyPosition()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}

using TMPro;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform Player;
    public float speed = 4f;

    public int Hp = 2;
    public GameObject MagmaPartical, NormalPartical;

    public static int Score = 0;
    private TextMeshProUGUI ScoreText;
    public enum HeadKind { 
        MagmaHead,
        NormalHead,
    
    }
    

    public HeadKind _HeadKind;

    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("UI").gameObject.GetComponent<TextMeshProUGUI>();
        Player = GameObject.FindWithTag("Player").transform;
        ScoreTexting();
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

    public void HpSense()
    {
        switch(_HeadKind)
        {
            case HeadKind.MagmaHead:

                Hp -= 1;

                if (Hp == 0)
                {
                    Instantiate(MagmaPartical,transform.position, Quaternion.identity);
                    Score += 2;
                    ScoreTexting();
                    Destroy(gameObject);
                }

                break;

            case HeadKind.NormalHead:

                Hp -= 2;

                if (Hp == 0)
                {
                    Instantiate(NormalPartical,transform.position, Quaternion.identity);
                    Score += 1;
                    ScoreTexting();
                    Destroy(gameObject);
                }

                break;
        }

       

    }


    void ScoreTexting()
    {
        ScoreText.text = "Score: " + Score;

    }
}

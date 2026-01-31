using UnityEngine;

public class ShurikenThrower : MonoBehaviour
{
    public GameObject shurikenPrefab;
    public Transform firePoint;
    public Camera cam;

    float cooldown = 0.5f;
    float lastShotTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastShotTime + cooldown)
        {
            ThrowShuriken();
            lastShotTime = Time.time;
        }
    }

    void ThrowShuriken()
    {
        GameObject shuriken = Instantiate(
            shurikenPrefab,
            firePoint.position,
            Quaternion.identity
        );

        // EKRAN ORTASI
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction;

        direction = ray.direction;

        shuriken.GetComponent<Shuriken>().SetDirection(direction);
    }
}

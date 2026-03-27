using System.Collections;
using UnityEngine;

public class ShurikenThrower : MonoBehaviour
{
    public GameObject shurikenPrefab;
    public Transform firePoint;
    public Camera cam;

    public float cooldown = 2f;
    bool canShoot = true;

    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(ShurikenSpawner());
        }
    }

    IEnumerator ShurikenSpawner()
    {
        canShoot = false;

        ThrowShuriken();

        yield return new WaitForSeconds(cooldown);

        canShoot = true;
    }

    void ThrowShuriken()
    {
        GameObject shuriken = Instantiate(
            shurikenPrefab,
            firePoint.position,
            Quaternion.identity
        );

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction = ray.direction;

        shuriken.GetComponent<Shuriken>().SetDirection(direction);
    }
}

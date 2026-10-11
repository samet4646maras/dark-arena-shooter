using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake icerik;
    public float shakeDuration = 0.2f;
    public float shakeAmount = 0.1f;

    private Vector3 originalPosition;
    private float currentShakeTime;

    void Start()
    {
        icerik = this;
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (currentShakeTime > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;

            currentShakeTime -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }

    public void Shake()
    {
        currentShakeTime = shakeDuration;
    }
}
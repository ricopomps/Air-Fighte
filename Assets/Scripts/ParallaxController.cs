using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] Transform[] Backgrounds;
    [SerializeField] float Smoothing = 10f;
    [SerializeField] float Multiplier = 15f;

    Transform Cam;
    Vector3 PreviousCamPos;

    void Awake() => Cam = Camera.main.transform;

    void Start() => PreviousCamPos = Cam.position;

    void Update()
    {
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            var background = Backgrounds[i];
            var parallax = (PreviousCamPos.y - Cam.position.y) * (i * Multiplier);
            var targetY = background.position.y + parallax;

            var targetPosition = new Vector3(background.position.x, targetY, background.position.z);

            background.position = Vector3.Lerp(background.position, targetPosition, Smoothing * Time.deltaTime);
        }

        PreviousCamPos = Cam.position;
    }
}
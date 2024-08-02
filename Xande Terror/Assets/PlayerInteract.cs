using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    public UnityEvent OnInteractionEffected;
    public static PlayerInteract Instance;
    Transform cam;
    public float handDistance = 7;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.position, cam.forward * handDistance, Color.yellow);

        if (Physics.Raycast(cam.position, cam.forward, out hit, handDistance))
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
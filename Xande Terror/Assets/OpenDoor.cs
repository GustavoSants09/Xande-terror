using UnityEngine;

public class OpenDoor : InterectableObj
{
    [SerializeField] bool doorOpened;
    [SerializeField]float openAngle, closeAngle;
    Transform doorRotation;
    [Space(5)]
    public AudioSource[] audioDoor = new AudioSource[0];

    private void Start()
    {
        doorRotation = GetComponent<Transform>();
    }
    protected override void Interact()
    {
        PlayerInteract.Instance.OnInteractionEffected.Invoke();
        if (doorOpened)
        {
            doorRotation.rotation = Quaternion.Euler(-90, closeAngle, 0);
            doorOpened = false;
            return;
        }
        doorOpened = true;
        doorRotation.rotation = Quaternion.Euler(-90, openAngle, 0);
    }
}

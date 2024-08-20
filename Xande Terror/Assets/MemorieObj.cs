public class MemorieObj : InterectableObj
{
    protected override void Interact()
    {
        MemoriesCounter.memoriesCount++;
        PlayerInteract.Instance.OnInteractionEffected.Invoke();
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("Balloon");

    }
}

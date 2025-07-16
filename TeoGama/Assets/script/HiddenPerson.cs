using UnityEngine;
public class HiddenPerson : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]private float visibleTime = 0f;
    [SerializeField] private float maxVisibleTime = 0.5f;
    [SerializeField] private bool isVisible = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        InvokeRepeating("ShowTemporarily", Random.Range(1f, 3f), Random.Range(3f, 5f));

        
    }

    void ShowTemporarily()
    {
        spriteRenderer.enabled = true;
        isVisible = true;
        visibleTime = maxVisibleTime;
    }
    void Update()
    {
        ShowTemporarily();

        if (isVisible)
        {
            visibleTime -= Time.deltaTime;
            if (visibleTime <= 0)
            {
                spriteRenderer.enabled = false;
                isVisible = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lanterna") && isVisible)
        {
            Debug.Log("Personagem Salvo!");
            Destroy(gameObject);
        }
    }
}
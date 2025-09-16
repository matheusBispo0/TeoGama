using UnityEngine;
public class ApareceSome : MonoBehaviour
{
    private bool found = false; 
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    void OnMouseOver()
    {
        if (!found)
        {
            spriteRenderer.enabled = true; 
            found = true;
            GameManager.instance.AddPoint();
        }
    }
}
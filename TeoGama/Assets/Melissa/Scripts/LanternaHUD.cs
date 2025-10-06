using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class LanternaHUD : MonoBehaviour
{
    public Image lanternaImage;
    public Sprite spriteNormal;
    public Sprite[] animacaoClick; 
    public Light2D luzLanterna;
    private bool ligada = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleLanterna();
        }
    }
    void ToggleLanterna()
    {
        ligada = !ligada;
        luzLanterna.enabled = ligada;
        StopAllCoroutines();
        StartCoroutine(AnimarClick());
    }
    System.Collections.IEnumerator AnimarClick()
    {
        
        for (int i = 0; i < animacaoClick.Length; i++)
        {
            lanternaImage.sprite = animacaoClick[i];
            yield return new WaitForSeconds(0.1f);
        }
        
        lanternaImage.sprite = spriteNormal;
    }
}
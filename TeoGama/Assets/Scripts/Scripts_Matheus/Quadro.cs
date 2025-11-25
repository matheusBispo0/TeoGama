using UnityEngine;

public class Quadro : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D hinge;

    public bool Caiu { get; private set; } = false;

    [Header("Chave")]
    public GameObject chavePrefab;   // prefab da chave
    public Transform spawnChave;     // posição onde a chave aparece

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;

        hinge = gameObject.AddComponent<HingeJoint2D>();
        hinge.enabled = false;
    }

    void OnMouseDown()
    {
        if (!Caiu)
        {
            Caiu = true;

            rb.bodyType = RigidbodyType2D.Dynamic;
            hinge.enabled = true;
            hinge.anchor = new Vector2(-0.5f, 0.5f);
            hinge.connectedAnchor = hinge.anchor;
            hinge.connectedBody = null;

            hinge.useLimits = true;
            hinge.limits = new JointAngleLimits2D { min = -180f, max = 180f };

            Debug.Log("O quadro caiu!");

            SpawnChave();
        }
    }

    void SpawnChave()
    {
        if (chavePrefab != null)
        {
            GameObject chave = Instantiate(chavePrefab, spawnChave.position, Quaternion.identity);

            // Mantém escala original do prefab
            chave.transform.localScale = Vector3.one;

            // Não fica filho do quadro
            chave.transform.SetParent(null);

            Debug.Log("Chave criada.");
        }
    }
}

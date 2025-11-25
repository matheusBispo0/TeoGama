using UnityEngine;
public class Quadro : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D hinge;
    public bool Caiu { get; private set; } = false; // pública apenas para leitura

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

            // ativa física e hinge
            rb.bodyType = RigidbodyType2D.Dynamic;
            hinge.enabled = true;
            hinge.anchor = new Vector2(-0.5f, 0.5f);
            hinge.connectedAnchor = hinge.anchor;
            hinge.connectedBody = null;

            hinge.useLimits = true;
            JointAngleLimits2D limits = new JointAngleLimits2D();
            limits.min = -180f;
            limits.max = 180f;
            hinge.limits = limits;

            Debug.Log("O quadro caiu!");
        }
    }
}
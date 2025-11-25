using UnityEngine;
public class Quadro : MonoBehaviour
{
   public Rigidbody2D pivotRB;
   private Rigidbody2D rb;
   private HingeJoint2D hinge;
   public bool Caiu { get; private set; } = false;
   void Start()
   {
       rb = GetComponent<Rigidbody2D>();
       hinge = GetComponent<HingeJoint2D>();
       rb.bodyType = RigidbodyType2D.Static;
       hinge.enabled = false;
   }
   void OnMouseDown()
   {
       if (Caiu) return;
       Caiu = true;
       rb.bodyType = RigidbodyType2D.Dynamic;
       hinge.enabled = true;
   }
}
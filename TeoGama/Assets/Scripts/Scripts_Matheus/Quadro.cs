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
       Debug.Log("CLICOU NO QUADRO");
       if (Caiu) return;
       Caiu = true;
       rb.bodyType = RigidbodyType2D.Dynamic;
       hinge.enabled = true;
       hinge.useLimits = true;
       hinge.limits = new JointAngleLimits2D { min = -90f, max = 0f };
   }
   void Update()
   {
       if (Caiu)
       {
           float ang = hinge.jointAngle;
           if (ang <= hinge.limits.min + 0.5f)
           {
               rb.angularVelocity = 0f;
               rb.freezeRotation = true;
           }
       }
   }
}
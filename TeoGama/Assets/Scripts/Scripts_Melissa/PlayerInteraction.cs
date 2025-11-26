using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInteraction : MonoBehaviour
{
   [Header("Referências (arraste no Inspector)")]
   public Transform quadroTransform;   // transform do quadro (obj com collider isTrigger)
   public GameObject chave;            // obj da chave (deve começar desativado)
   public GameObject porta;            // obj da porta (apenas referência)
   public string nomeDaCena;           // nome da cena a carregar
   [Header("Queda do quadro (rotacionar)")]
   public float anguloAlvo = -80f;     // ângulo final em graus (Z). negativo cai para a direita, positivo cai para a esquerda
   public float tempoQueda = 0.6f;     // tempo aproximado da animação de queda
   public AnimationCurve curva = AnimationCurve.EaseInOut(0, 0, 1, 1); // ease padrão, você pode ajustar no Inspector
   [Header("Pegar chave")]
   public float distanciaPegar = 0.8f;
   // estados
   bool podeInteragirQuadro = false;
   bool podeInteragirPorta = false;
   bool quadroSolto = false;      // garante que o quadro só caia 1 vez
   bool animandoQueda = false;
   bool chaveVisivel = false;
   bool pegouChave = false;
   // animação de rotação
   float tempoAnim = 0f;
   float anguloInicial;
   float anguloDestino;
   void Start()
   {
       if (quadroTransform != null)
           anguloInicial = quadroTransform.eulerAngles.z; // cuidado: 0..360
       if (chave != null)
           chave.SetActive(false);
   }
   void Update()
   {
       // Interagir com o quadro: só se estiver perto, não animando e ainda não solto
       if (podeInteragirQuadro && Input.GetKeyDown(KeyCode.E) && !animandoQueda && !quadroSolto)
       {
           IniciarQueda();
       }
       // animação de rotação (queda)
       if (animandoQueda && quadroTransform != null)
       {
           tempoAnim += Time.deltaTime / Mathf.Max(0.0001f, tempoQueda);
           float t = Mathf.Clamp01(tempoAnim);
           t = curva.Evaluate(t);
           // usar Smooth interpolation via Mathf.LerpAngle para ângulos
           float z = Mathf.LerpAngle(anguloInicial, anguloDestino, t);
           Vector3 e = quadroTransform.eulerAngles;
           e.z = z;
           quadroTransform.eulerAngles = e;
           if (tempoAnim >= 1f)
           {
               animandoQueda = false;
               quadroSolto = true; // não permite nova interação
               // mostra a chave
               if (chave != null)
               {
                   chave.SetActive(true);
                   chaveVisivel = true;
               }
           }
       }
       // pegar chave por distância (fallback)
       if (chaveVisivel && !pegouChave && chave != null)
       {
           float d = Vector2.Distance(transform.position, chave.transform.position);
           if (d <= distanciaPegar)
           {
               PegouChave();
           }
       }
       // abrir porta / trocar cena
       if (podeInteragirPorta && Input.GetKeyDown(KeyCode.E))
       {
           if (pegouChave)
           {
               if (!string.IsNullOrEmpty(nomeDaCena))
                   SceneManager.LoadScene(nomeDaCena);
               else
                   Debug.LogWarning("PlayerInteraction: nomeDaCena está vazio.");
           }
           else
           {
               Debug.Log("Você precisa da chave para abrir a porta.");
           }
       }
   }
   void IniciarQueda()
   {
       if (quadroTransform == null) return;
       // Definir ângulo destino considerando wrap 0..360
       anguloInicial = quadroTransform.eulerAngles.z;
       // converter anguloAlvo que é relativo (ex: -80) para valor absoluto próximo do inicial
       anguloDestino = anguloInicial + anguloAlvo;
       tempoAnim = 0f;
       animandoQueda = true;
   }
   void PegouChave()
   {
       pegouChave = true;
       chaveVisivel = false;
       if (chave != null) chave.SetActive(false);
       Debug.Log("Chave coletada.");
   }
   // ---------- DETECÇÃO DE TRIGGERS ----------
   private void OnTriggerEnter2D(Collider2D other)
   {
       // o trigger do quadro deve ter tag "Quadro"
       if (other.CompareTag("Quadro"))
       {
           // permitir interação apenas se o quadro ainda não foi solto
           if (!quadroSolto)
               podeInteragirQuadro = true;
       }
       else if (other.CompareTag("Key"))
       {
           // se a chave tem trigger e o player entra nela, pega instantaneamente
           if (chave != null && other.gameObject == chave)
           {
               PegouChave();
           }
       }
       else if (other.CompareTag("Door"))
       {
           podeInteragirPorta = true;
       }
   }
   private void OnTriggerExit2D(Collider2D other)
   {
       if (other.CompareTag("Quadro"))
       {
           podeInteragirQuadro = false;
       }
       else if (other.CompareTag("Door"))
       {
           podeInteragirPorta = false;
       }
   }
   // método público caso você queira checar de outro script
   public bool TemChave()
   {
       return pegouChave;
   }
}
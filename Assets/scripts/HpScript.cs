using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    float HP = 0;
    float FullHP = 0;

    [SerializeField]
    private Gradient gradient;

    private SpriteRenderer thisSprite;

    [SerializeField]
    public bool HasStarted = false;

    private Vector3 StartTrans;

    [SerializeField]
    private Effects effectoritos = null;

    [SerializeField]
    private Scores scores;

    [SerializeField]
    private AudioSource DeathSE;

    [SerializeField]
    private GameManager GameM;
    private void Start()
    {
        StartTrans = this.transform.position;
        thisSprite = GetComponent<SpriteRenderer>();
        FullHP = transform.localScale.x;
        HP = FullHP;
        thisSprite.color = gradient.Evaluate(HP / 8);
    }
    public void FillHP()
    {
        this.transform.position = StartTrans;
        HP = FullHP;
    }


    private bool IsDeath = false;
    bool isSounded = false;
    float op = 1;
    void FixedUpdate()
    {
        if (HasStarted)
        {
            if (HP > 0)
            {
                HP -= 0.032f;
                transform.localScale = new Vector2(HP, transform.localScale.y);
                transform.Translate(new Vector3(-0.016f, 0, 0));
                thisSprite.color = gradient.Evaluate(HP / 8);
            }
            else
            {
                effectoritos.OnGameOver = true;
                scores.SaveScore();
                IsDeath = true;
                if (!isSounded)
                {
                    playsound();
                    isSounded = true;
                }
            }
        }
        if(IsDeath)
        {
            op -= 0.02f;
            DeathSE.pitch = op;
        }
    }
    private void playsound()
    {
        DeathSE.Play();
        GameM.isDeath = true;
    }
}

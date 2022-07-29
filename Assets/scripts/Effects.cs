using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Effects : MonoBehaviour
{
    [SerializeField]
    private Camera EffectCamera;

    [SerializeField]
    private ChromaticAberration CA;

    [SerializeField]
    private ColorGrading CG;

    [SerializeField]
    private PostProcessVolume Manager;

    [SerializeField]
    private Color Red;

    bool OnCA = false;

    bool OnGoodbool = false;

    [SerializeField]
    private GameObject gameover;

    [SerializeField]
    private GameObject gamestart;

    [SerializeField]
    private Transform ui;
    public bool OnGameOver = false;
    void Start()
    {
        Instantiate(gamestart, transform.position, transform.rotation, ui);
        Manager =GetComponent<PostProcessVolume>();
        Manager.profile.TryGetSettings(out CA);
        Manager.profile.TryGetSettings(out CG);
        EffectCamera = Camera.main;

    }

    float Power = 0;

    float GoodPower = 0;

    float darkness = 0;
    // Update is called once per frame
    void FixedUpdate()
    {

        Debug.Log(OnGoodbool);

        if (OnGoodbool)
        {
            GoodThing(GoodPower);
            GoodPower -= 0.04f;
            if (GoodPower <= 0)
            {
                OnGoodbool = false;
            }
            if(OnCA)
            {
                OnCA = false; Power = 0;
            }
        }

        if (OnCA && Power > 0f && !OnGoodbool)
        {
            Damage(Power);
            Power -= 0.02f;
            if(Power <=0)
            {
                OnCA = false;
            }
        }

        

        if(OnGameOver && darkness < 1.5f)
        {
            darkness += 0.02f;
            GameOver(darkness);
            if(darkness >= 1.5f)
            {
                Instantiate(gameover, transform.position, transform.rotation,ui);
            }
        }
    }

    public void ActivateCA()
    {
        OnCA = true;
        Power = 1.2f;
    }
    public void Activategood()
    {
        OnGoodbool = true;
        GoodPower = 1.2f;
    }
    public void Damage(float power =1)
    {
        CG.colorFilter.value = new Color(1,1-power/3,1-power/3,0);
        CA.intensity.value = power;
    }

    public void GoodThing(float power =1)
    {
        CG.colorFilter.value = new Color(1-power/3,1,1-power/3,0);
        //CA.intensity.value = power;
    }

    public void GameOver(float power =1)
    {
        CG.colorFilter.value = new Color(1-power,1- power, 1- power, 0);
    }

}

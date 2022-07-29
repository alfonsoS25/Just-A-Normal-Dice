using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sonidosGood;
    [SerializeField]
    private AudioSource sonidosHalfGood;
    [SerializeField]
    private AudioSource sonidosBad;
    public enum DiceState
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Alphabet,
        Special,
    }

    //[SerializeField]
    //private DiceState _DiceState;

    [SerializeField]
    private Sprite[] DiceSpriteRepertory;

    [SerializeField]
    private GameObject DiceObject = null;

    [SerializeField]
    private GameObject SpecialObject = null;

    [SerializeField]
    private GameObject DiceInside = null;

    private int ActualStringPoint = 0;

    [SerializeField]
    private int Difficulty = 0;

    private int Level = 0;

    private float damagedelay = 0;

    private string LastNum = "";
    [SerializeField]
    private Sprite[] SpecialKeysRepertory;

    public List<string> listadodecompras = new List<string>();

    [SerializeField]
    private Effects Efectorpro = null;

    [SerializeField]
    private HpScript Healthbar = null;

    [SerializeField]
    private Scores score;
    void Start()
    {
        DiceInside.SetActive(false);
        for(int i = 0; i < 6; i++)
        {
            GenerateRandomNumber();
        }
    }

    void Update()
    {
        damagedelay += Time.deltaTime;
    }

    public string CreateChar()
    {
        int j = 0;
        string hola = "Char";

        int harder = 1;
        if(Difficulty >=4 )
        {
            harder = Difficulty-3;
        }

        for (int i = 0; i < harder; i++)
        {
            if (j == 4)
            {
                j = 0;
                hola += "\n";
            }
            j++;
            hola += (char)('A' + Random.Range(0, 26));
            
        }
        return hola;
    }


    public void GenerateRandomNumber()
    {
        int GeneratedNum = 0;
        switch (Difficulty)
        {
            case 0:
                GeneratedNum = Random.Range(0, 6);//6);
                break;
            case 1:
                GeneratedNum = Random.Range(0, 9);
                break;
            case 2:
                GeneratedNum = Random.Range(9, 35);
                break;
            case 3:
                GeneratedNum = Random.Range(36, 47);
                break;
            default:
                GeneratedNum = Random.Range(0, 47);
                break;
        }
        Chainer(GeneratedNum);
        UpdateDice();
        CheckCharLeghtToSize();
    }

    private void Chainer(int numero)
    {
        string definer = "";
        switch (numero)
        {
            case 0:
                definer += ("Alpha1");
                //listadodecompras.Add("Alpha1");
                break;
            case 1:
                definer += ("Alpha2");
                // listadodecompras.Add("Alpha2");
                break;
            case 2:
                definer += ("Alpha3");
                //listadodecompras.Add("Alpha3");
                break;
            case 3:
                definer += ("Alpha4");
                // listadodecompras.Add("Alpha4");
                break;
            case 4:
                definer += ("Alpha5");
                // listadodecompras.Add("Alpha5");
                break;
            case 5:
                definer += ("Alpha6");
                // listadodecompras.Add("Alpha6");
                break;
            case 6:
                definer += ("Alpha7");
                // listadodecompras.Add("Alpha7");
                break;
            case 7:
                definer += ("Alpha8");
                // listadodecompras.Add("Alpha8");
                break;
            case 8:
                definer += ("Alpha9");
                //listadodecompras.Add("Alpha9");
                break;
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 28:
            case 29:
            case 30:
            case 31:
            case 32:
            case 33:
            case 34:
            case 35:
                listadodecompras.Add(CreateChar());
                break;

            case 36:
            case 37:
            case 38:
            case 39:
            case 40:
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
                GenerateSpecial(numero);
                break;
            default:
                //listadodecompras.Add("F"+(RandomNum-3).ToString());
                break;
        }
        if(numero <= 8)
        {
            if(definer != LastNum)
            {
                listadodecompras.Add(definer);
                LastNum = definer;
            }
            else
            {
                GenerateRandomNumber();
            }
        }
    }

    private void GenerateSpecial(int Which)
    {
        //SpecialObject.GetComponent<SpriteRenderer>().sprite = SpecialKeysRepertory[Which - 36];

        string definer = "";
        switch (Which)
        {
            case 36:
                definer = "F1";
                //listadodecompras.Add("F1");
                break;
            case 37:
                definer = "F2";
                //listadodecompras.Add("F2");
                break;
            case 38:
                definer = "F3";
                // listadodecompras.Add("F3");
                break;
            case 39:
                definer = "F4";
                // listadodecompras.Add("F4");
                break;
            case 40:
                definer = "F5";
                //  listadodecompras.Add("F5");
                break;
            case 41:
                definer = "F6";
                //   listadodecompras.Add("F6");
                break;
            case 42:
                definer = "F7";
                // listadodecompras.Add("F7");
                break;
            case 43:
                definer = "F8";
                // listadodecompras.Add("F8");
                break;
            case 44:
                definer = "Alt";
                // listadodecompras.Add("Alt");
                break;
            case 45:
                definer = "Control";
                //listadodecompras.Add("Control");
                break;
            case 46:
                // lista
                definer = "Shift";// dodecompras.Add("Shift");
                break;
            case 47:
                definer = "Tab";
                // listadodecompras.Add("Tab");
                break;
        }
        
        if (definer != LastNum)
        {
            listadodecompras.Add(definer);
            LastNum = definer;
        }
        else
        {
            GenerateRandomNumber();
        }
    }

    private void UpdateDice()
    {
        string state = listadodecompras[0];
        if (state.Contains("Char"))
        {
            state = listadodecompras[0];
            string NoChar = "";

            for (int f = 4; f < state.Length; f++)
            {
                NoChar += state[f];
            }
            DiceInside.GetComponent<TextMesh>().text = NoChar;
        }

        int Elegido = 0;

        switch(state)
        {
            case "Alpha1": Elegido = 1;
                break;
            case "Alpha2": Elegido = 2;
                break;
            case "Alpha3": Elegido = 3;
                break;
            case "Alpha4": Elegido = 4;
                break;
            case "Alpha5": Elegido = 5;
                break;
            case "Alpha6": Elegido = 6;
                break;
            case "Alpha7": Elegido = 7;
                break;
            case "Alpha8": Elegido = 8;
                break;
            case "Alpha9": Elegido = 9;
                break;

            case "F1": Elegido = 24;
                break;
            case "F2": Elegido = 25;
                break;
            case "F3": Elegido = 26;
                break;
            case "F4": Elegido = 27;
                break;
            case "F5": Elegido = 28;
                break;
            case "F6": Elegido = 29;
                break;
            case "F7": Elegido = 30;
                break;
            case "F8": Elegido = 31;
                break;
            case "Control": Elegido = 20;
                break;
            case "Tab": Elegido = 21;
                break;
            case "Alt": Elegido = 22;
                break;
            case "Shift": Elegido = 23;
                break;
            default:
                Elegido = 100;
                break;
        }    

        if (Elegido <= 9)
        {
            DiceInside.SetActive(false);
            SpecialObject.SetActive(false);
            DiceObject.GetComponent<SpriteRenderer>().sprite = DiceSpriteRepertory[Elegido-1];
        }

        else if(Elegido < 50)
        {
            SpecialObject.GetComponent<SpriteRenderer>().sprite = SpecialKeysRepertory[Elegido - 20];
            SpecialObject.SetActive(true);
            DiceInside.SetActive(false);
        }
        else
        {
            DiceObject.GetComponent<SpriteRenderer>().sprite = DiceSpriteRepertory[9];
            SpecialObject.SetActive(false);
            DiceInside.SetActive(true);
        }

    }




    Event e;
    string lastKeyPressed = "";
    bool keydown = false;

    void OnGUI()
    {
        e = Event.current;
        if (e.type.Equals(EventType.KeyDown) && !keydown)
        {
            //keydown = true;
            lastKeyPressed = e.keyCode.ToString();
            CheckKey(lastKeyPressed);
        }

        //if (e.type.Equals(EventType.KeyUp))
        //    keydown = false;

        //GUILayout.Label("Last Key Pressed - " + lastKeyPressed);
    }

    public bool isDeath = false;
    private void CheckCharLeghtToSize()
    {
        if (listadodecompras[0].Length <= 6)
        {
            DiceInside.GetComponent<TextMesh>().characterSize = 8;
        }
        else if (listadodecompras[0].Length == 7)
        {
            DiceInside.GetComponent<TextMesh>().characterSize = 5;
        }
        else if (listadodecompras[0].Length >= 8)
        {
            DiceInside.GetComponent<TextMesh>().characterSize = 3.5f;
        }
    }

    private void CheckNextItem()
    {
        if (listadodecompras[0].Contains("Char"))
        {
            string reemplazo = listadodecompras[0];
            string NoChar = "";

            for (int f = 4; f < reemplazo.Length; f++)
            {
                NoChar += reemplazo[f];
            }
            CheckCharLeghtToSize();
            DiceInside.GetComponent<TextMesh>().text = NoChar;
        }
        else
        {
            DiceInside.GetComponent<TextMesh>().text = listadodecompras[0];
        }
    }
    private void CheckKey(string InptKey)
    {
        CheckCharLeghtToSize();
        string reemplazo = listadodecompras[0].Replace("\r", "").Replace("\n", "");
        //reemplazo
        //Debug.Log(reemplazo);
        //Debug.Log(listadodecompras[0]);

        if (listadodecompras.Count >1)
        {
            if (InptKey == reemplazo)
            {
                listadodecompras.RemoveAt(0); 
                CheckNextItem();
                CheckCharLeghtToSize();
                ClearLevel();
            }
            else if (listadodecompras[0].Contains("Char"))
            {
                if(ActualStringPoint < reemplazo.Length-5)
                {
                    if (InptKey[0] == reemplazo[ActualStringPoint+4])
                    {
                        Efectorpro.Activategood();
                        ActualStringPoint++;
                        damagedelay = 0;
                        sonidosHalfGood.Play();
                    }
                    else
                    {
                      TakeDamage();
                    }
                }
                else
                {
                    if (InptKey[0] == reemplazo[ActualStringPoint + 4])
                    {
                        ActualStringPoint = 0;
                        listadodecompras.RemoveAt(0);
                        ClearLevel();

                        if (listadodecompras[0].Contains("Char"))
                        {
                            reemplazo = listadodecompras[0];
                            string NoChar = "";

                            for (int f = 4; f < reemplazo.Length; f++)
                            {
                                NoChar += reemplazo[f];
                            }
                            DiceInside.GetComponent<TextMesh>().text = NoChar;
                            CheckCharLeghtToSize();
                            ActualStringPoint = 0;
                        }
                        else
                        {
                            DiceInside.GetComponent<TextMesh>().text = listadodecompras[0];
                            CheckCharLeghtToSize();
                            ActualStringPoint = 0;
                        }
                        ActualStringPoint = 0;
                    }
                    else
                    {
                        //TakeDamage();
                    }
                }
            }

            else if (listadodecompras[0] == "Alt")
            {
                if (InptKey == "LeftAlt" || InptKey == "RightAlt")
                {
                    if (listadodecompras.Count > 1)
                    {
                        listadodecompras.RemoveAt(0);
                        CheckNextItem();
                        ClearLevel();
                    }
                }
                else
                {
                    TakeDamage();
                }
            }

            else if (listadodecompras[0] == "Shift")
            {
                if (InptKey == "LeftShift" || InptKey == "RightShift")
                {
                    if (listadodecompras.Count > 1)
                    {
                        listadodecompras.RemoveAt(0);
                        CheckNextItem();
                        ClearLevel();
                    }
                }
                else
                {
                    TakeDamage();
                }
            }

            else if (listadodecompras[0] == "Control")
            {
                if (InptKey == "LeftControl" || InptKey == "RightControl")
                {
                    if (listadodecompras.Count > 1)
                    {
                        listadodecompras.RemoveAt(0); 
                        CheckNextItem();
                        ClearLevel();
                    }
                }
                else
                {
                    TakeDamage();
                }
            }
            else
            {
                TakeDamage();
            }
        }
        UpdateDice();
    }

    private void TakeDamage()
    {
        if (damagedelay > 0.3f && !isDeath)
        {
            sonidosBad.Play();
            Efectorpro.ActivateCA();
            damagedelay = 0;
        }

    }
    private void ClearLevel()
    {
        sonidosGood.Play();
        Efectorpro.Activategood();
        Healthbar.FillHP();
        damagedelay = 0;
        Level++;
        score.AddScore();
        if(Level>=5)
        {
            Difficulty++;
            Debug.Log("difficulty now: "+ Difficulty);
            Level = 0;
            for(int i = 0; i < 5; i++)
            {
                GenerateRandomNumber();
            }
        }
    }
}

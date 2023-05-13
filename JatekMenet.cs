using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class JatekMenet : MonoBehaviour
{

    public GameObject[] rejtett;
    public bool enterI = false;
    public bool roszEgySzabad = true;
    public bool roszKettoSzabad = true;
    public bool roszHaromSzabad = true;
    public bool roszNegySzabad = true;
    public GameObject gyoztel;
    public GameObject vesztettel;
    public GameObject fal;
    public Material alapszin;
    public Material[] szinek;
    public GameObject[] AdhatoHely;
    public GameObject[] visszajelzes;
    public int elem = 0;
    public List<int> adottkod = new List<int>();
    public List<int> roszHely = new List<int>();
    public List<int> roszSzam = new List<int>();
    public int feher = 0;
    public int fekete = 0;
    public List<int> RejtettSzamok = new List<int>();
    public bool elso = true;
    public Material feketeSzin;
    public Material feherSzin;
    public void ujra()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void vege()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {

        for (int i = 0; i < 4; i++)
        {
            RejtettSzamok.Add(UnityEngine.Random.Range(0, 6));
        }
        for (int i = 0; i < 4; i++)
        {
            rejtett[i].GetComponent<MeshRenderer>().material = szinek[RejtettSzamok[i]];
        }

    }


    void Update()
    {

        if ((elem - 2) % 4 == 0 && adottkod.Count > 2)
        {
            elso = true;
        }

        if (Input.GetKeyDown("p"))
        {

            AdhatoHely[elem].GetComponent<MeshRenderer>().material = szinek[0];
            adottkod.Add(0);
            elem++;
        }
        if (Input.GetKeyDown("z"))
        {

            AdhatoHely[elem].GetComponent<MeshRenderer>().material = szinek[1];
            adottkod.Add(1);
            elem++;
        }
        if (Input.GetKeyDown("k"))
        {

            AdhatoHely[elem].GetComponent<MeshRenderer>().material = szinek[2];
            adottkod.Add(2);
            elem++;
        }
        if (Input.GetKeyDown("s"))
        {

            AdhatoHely[elem].GetComponent<MeshRenderer>().material = szinek[3];
            adottkod.Add(3);
            elem++;
        }
        if (Input.GetKeyDown("l"))
        {

            AdhatoHely[elem].GetComponent<MeshRenderer>().material = szinek[4];
            adottkod.Add(4);
            elem++;
        }
        if (Input.GetKeyDown("n"))
        {

            AdhatoHely[elem].GetComponent<MeshRenderer>().material = szinek[5];
            adottkod.Add(5);
            elem++;
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && elso==true && elem != 0)
        {
            elem--;
            adottkod.Remove(elem);
            AdhatoHely[elem].GetComponent<MeshRenderer>().material = alapszin;
        }
        if (Input.GetKeyDown(KeyCode.Return) && elem % 4 == 0)
        {
            enterI = true;
        }
        if (elem % 4 == 0 && adottkod.Count > 1 && elso == true && enterI == true)
        {

            for (int i = 0; i < 4; i++)
            {
                if (adottkod[elem - (4 - i)] == RejtettSzamok[i])
                {
                    fekete++;
                }
                else
                {
                    roszHely.Add(RejtettSzamok[i]);
                    roszSzam.Add(adottkod[elem - (4 - i)]);
                }
            }

            foreach (int elem in roszSzam)
            {
                if (roszHely.Count == 2)
                {
                    if (elem == roszHely[0] && roszEgySzabad == true)
                    {
                        feher++;
                        roszEgySzabad = false;
                    }
                    else if (elem == roszHely[1] && roszKettoSzabad == true)
                    {
                        feher++;
                        roszKettoSzabad = false;
                    }
                }
                if (roszHely.Count == 3)
                {

                    if (elem == roszHely[0] && roszEgySzabad == true)
                    {
                        feher++;
                        roszEgySzabad = false;
                    }
                    else if (elem == roszHely[1] && roszKettoSzabad == true)
                    {
                        feher++;
                        roszKettoSzabad = false;
                    }
                    else if (elem == roszHely[2] && roszHaromSzabad == true)
                    {
                        feher++;
                        roszHaromSzabad = false;
                    }
                }
                if (roszHely.Count == 4)
                {

                    if (elem == roszHely[0] && roszEgySzabad == true)
                    {
                        feher++;
                        roszEgySzabad = false;
                    }
                    else if (elem == roszHely[1] && roszKettoSzabad == true)
                    {
                        feher++;
                        roszKettoSzabad = false;
                    }
                    else if (elem == roszHely[2] && roszHaromSzabad == true)
                    {
                        feher++;
                        roszHaromSzabad = false;
                    }
                    else if (elem == roszHely[3] && roszNegySzabad == true)
                    {
                        feher++;
                        roszNegySzabad = false;
                    }


                }
            }
            for (int i = 0; i < fekete; i++)
            {
                visszajelzes[(elem - 4) + i].GetComponent<MeshRenderer>().material = feketeSzin;
            }

            for (int i = 0; i < feher; i++)
            {
                visszajelzes[(elem - 4) + i + fekete].GetComponent<MeshRenderer>().material = feherSzin;

            }
            roszHely.Clear();
            roszSzam.Clear();
            roszEgySzabad = true;
            roszKettoSzabad = true;
            roszHaromSzabad = true;
            roszNegySzabad = true;
            enterI = false;
            Debug.Log(fekete);
            Debug.Log(feher);
            if (elem == 32 && fekete != 4)
            {
                vesztettel.SetActive(true);
                fal.SetActive(false);

                Invoke("ujra", 5);
            }
            if (fekete == 4)
            {
                Debug.Log("Kitaláltad ezért nyertél.");
                gyoztel.SetActive(true);
                fal.SetActive(false);
                Invoke("vege", 5);
            }


            fekete = 0;
            feher = 0;
            elso = false;

        }

    }
}

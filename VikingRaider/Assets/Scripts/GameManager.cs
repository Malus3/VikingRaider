﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {

    public string gameName;
    public List<Villes> TownList;
    public bool king;
    private GameObject Villages;

    [HideInInspector]
    public Drakkar drakkar;

    //Urgal : liaison avec UIMainSceneManager
    public UIMainSceneManager UImanager;

    // Use this for initialization
    void Start()
    {
        Debug.Log("caca1");
        //Urgal : liaison avec UIMainSceneManager
        UImanager = GameObject.Find("Canvas").GetComponent<UIMainSceneManager>();
        Villages = GameObject.Find("Villages");
        //init du roi
        king = false;

        // init gameName ici avec les input du joueur

        // init du drakkar
        Soldat viking = new Soldat(3, 3, 3, 3, 30, "Vikings");
        Soldat merc = new Soldat(1, 1, 1, 1, 0, "Mercenaires");
        drakkar = new Drakkar(gameName, 0, viking, merc, 8);

        // init des villes

        Soldat knights = new Soldat(3, 3, 4, 2, 20, "Chevaliers Errants");
        Soldat trebuchet = new Soldat(20, 1, 20, 15, 1, "Trébuchet");
        Soldat no_one = new Soldat(0, 0, 0, 0, 0, "personne");
        TownList = new List<Villes>();

        // listes des noms
        List<string> nameList = new List<string>
        {
            "city 1", "city 2", "city 3",
            "city 4", "city 5", "city 6",
            "city 7", "city 8", "city 9",
            "city 10","city 11", "city 12"
        };

        // liste des nombres de garnisons à répartir
        List<int> nbrList = new List<int>
        {
            80, 100, 120,
            150, 180, 200,
            220, 250, 280,
            350, 400, 480
        };

        List<int> posList = new List<int>
        {
            0, 1, 2,
            3, 4, 5,
            6, 7, 8,
            9, 10, 11
        };

        List<int> spotList = new List<int>
            {
            0, 1, 2,
            3, 4, 5,
            6, 7, 8,
            9, 10, 11,
            12, 13, 14,
            15, 16, 17,
            18, 19
            };

        for (int i = 0; i < nameList.Count; i++)
        {
            // rand garnisons
            int randGarn = UnityEngine.Random.Range(0, nbrList.Count);
            int garnNum = nbrList[randGarn];
            nbrList.RemoveAt(randGarn);

            Soldat garnison = new Soldat(1, 1, 1, 1, garnNum, "Garnisons");

            // rand fortification
            int Fortif = 0;
            int randFortif = UnityEngine.Random.Range(0, 3);
            switch (randFortif)
            {
                case 0:
                    Fortif = 0;
                    break;
                case 1:
                    Fortif = 1;
                    break;
                case 2:
                    Fortif = 3;
                    break;
            }

            // rand productivity
            int randProd = UnityEngine.Random.Range(0, 3);
            float Prod = 0.0f;
            switch (randProd)
            {
                case 0:
                    Prod = 0.98f;
                    break;
                case 1:
                    Prod = 1.00f;
                    break;
                case 2:
                    Prod = 1.02f;
                    break;
            }

            // rand capture
            int randCapt = UnityEngine.Random.Range(0, 4);
            int Capt = randCapt + 1;

            // rand perception
            int randPerc = UnityEngine.Random.Range(0, 4);
            int Perc = randPerc;

            // rand gold
            int randGold = UnityEngine.Random.Range(40, 76);
            int Gold = randGold * 1000;

            // rand pos   
            int randPos = UnityEngine.Random.Range(0, posList.Count);
            int Pos = posList[randPos];
            posList.RemoveAt(randPos);

            int rand = UnityEngine.Random.Range(0, spotList.Count);
            int childNum = spotList[rand];
            spotList.RemoveAt(rand);

            Villes city = Villages.transform.GetChild(childNum).gameObject.AddComponent<Villes>() as Villes;
            city.set(nameList[i], Fortif, Gold, garnison, Capt, Perc, Prod, no_one, no_one, Pos);


            // ajout de la ville créée à la liste
            TownList.Add(city);
            UImanager.InstantiateCity(city);


        }

        // METTRE UN TIME ICI

        // Generateur de logs pour test
        /*
        string lines = "";
        Time tps = new Time();

        for (int t = 0; t < 9; t++)
        {
            lines = lines + "Tour " + tps.currentTurn + ", Raid = " + tps.raidcount.ToString() + "\r\n \r\n";
            for (int k = 0; k < TownList.Count; k++)
            {
                Villes city = TownList[k];
                lines = lines + city.nameVilles + ": fortif = " + city.fortification.ToString() + ", gold = " + city.gold.ToString() + ", garnisons = " + city.garnison.number.ToString() + ", capture = " + city.capture.ToString() + ", perception = " + city.perception.ToString() + ", productivity = " + city.productivity.ToString() + ", pos = " + city.pos.ToString() + "\r\n";
            }
            lines = lines + "\r\n \r\n \r\n";
            tps.raidcount += 1;
            tps.updateTurn(this);
        }
        

        // Write the string to a file.
        System.IO.StreamWriter file = new System.IO.StreamWriter("f:\\test.txt");
        file.WriteLine(lines);

        file.Close();
        */
    }
    public void defeat (Drakkar joueur)
    {
        //TODO Urgal
    }
    public int victory (Drakkar joueur)
    {
        //TODO Urgal
        int score = (int)Math.Floor ((double) joueur.gold / (joueur.viking.number + 1));
        return score;
    }
    public int partir (Drakkar joueur)
    {
        if (joueur.min_members < joueur.viking.number)
        {
            //TODO Urgal
            //END GAME pop-up victoire
            int score = (int)Math.Floor((double)joueur.gold / (joueur.viking.number + 1));
            return score;
        }
        else
        {
            //TODO Urgal
            //popup de "nope, pas assez de gens pour rentrer, trouve de quoi recruter"
            return 0;
        }

    }
}

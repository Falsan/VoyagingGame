using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapGenerationScript : MonoBehaviour {

    string path;

    GameObject placeholder;

    float positionOffset = 0;

    void Start()
    {
        placeholder = (GameObject)Resources.Load("Tile");
        path = Application.dataPath + "/Resources/Map.txt";
        GenerateMap();    
    }

    void GenerateMap()
    {
        List<string> settings = new List<string>();

        int mapSizeX = 100;
        int mapSizeY = 100;

        List<bool> flagsList = new List<bool>();
        flagsList.Add(false); //startposplaced
        flagsList.Add(false); //finishPosplaced
        flagsList.Add(false); //odd hex, for the offset on hexes

        List<string> allTileProperties = new List<string>();

        for (int YIter = 0; YIter <= mapSizeY; YIter++)
        { 
            for(int XIter = 0; XIter <= mapSizeX; XIter++)
            {
                int baseBlankChance = 70;
                int baseStationChance = 1;
                int baseAsteriodChance = 4;
                int baseNebulaChance = 4;
                int baseStartPosChance = 10;
                int baseFinishPosChance = 10;
                int baseEventChance = 10;
                int baseSystemChance = 1;

                List<int> listOfWeights = DecideWeights(baseBlankChance, baseStationChance, baseAsteriodChance, baseNebulaChance, baseStartPosChance, 
                    baseFinishPosChance, baseEventChance, baseSystemChance, flagsList[0], flagsList[1], YIter, XIter);

                string rollResult = MakeRoll(listOfWeights, flagsList);

                allTileProperties.Add(rollResult);

                if(rollResult == "startPos")
                {
                    flagsList[0] = true;
                }
                else if(rollResult == "finishPos")
                {
                    flagsList[1] = true;
                }
            }
        }

        //Clean up map

        for(int iter = 0; iter < allTileProperties.Count; iter++)
        {
            if(allTileProperties[iter] == "station")
            {
                if (iter - mapSizeY < allTileProperties.Count && iter - mapSizeY > 0)
                {
                    if (allTileProperties[iter - mapSizeY] == "system")
                    {

                    }
                    else
                    {
                        allTileProperties[iter - mapSizeY] = "blank";
                    }
                }
                if (iter - 1 < allTileProperties.Count && iter - 1 > 0)
                {
                    if (allTileProperties[iter - 1] == "system")
                    {

                    }
                    else
                    {
                        allTileProperties[iter - 1] = "blank";
                    }
                }
                if (iter + 1 < allTileProperties.Count && iter + 1 > 0)
                {
                    if (allTileProperties[iter + 1] == "system")
                    {

                    }
                    else
                    {
                        allTileProperties[iter + 1] = "blank";
                    }
                }
                if (iter + mapSizeY < allTileProperties.Count && iter + mapSizeY > 0)
                {
                    if (allTileProperties[iter + mapSizeY] == "system")
                    {

                    }
                    else
                    {
                        allTileProperties[iter + mapSizeY] = "blank";
                    }
                }
                if (iter - mapSizeY - 1 < allTileProperties.Count && iter - mapSizeY - 1 > 0)
                {
                    if (allTileProperties[iter - mapSizeY - 1] == "system")
                    {

                    }
                    else
                    {
                        allTileProperties[iter - mapSizeY - 1] = "blank";
                    }
                }
                if (iter - mapSizeY + 1 < allTileProperties.Count && iter - mapSizeY + 1 > 0)
                {
                    if (allTileProperties[iter - mapSizeY + 1] == "system")
                    {

                    }
                    else
                    {
                        allTileProperties[iter - mapSizeY + 1] = "blank";
                    }
                }
                if (iter + mapSizeY + 1 < allTileProperties.Count && iter + mapSizeY + 1 > 0)
                {
                    if (allTileProperties[iter + mapSizeY + 1] == "system")
                    {

                    }
                    else
                    {
                        allTileProperties[iter + mapSizeY + 1] = "blank";
                    }
                }
                if (iter + mapSizeY - 1 < allTileProperties.Count && iter + mapSizeY - 1 > 0)
                {
                    if (allTileProperties[iter + mapSizeY - 1] == "system")
                    {

                    }
                    else
                    {
                        allTileProperties[iter + mapSizeY - 1] = "blank";
                    }
                }
            }
            if (allTileProperties[iter] == "system")
            {
                if (iter - mapSizeY < allTileProperties.Count && iter - mapSizeY > 0)
                {
                    if (allTileProperties[iter - mapSizeY] == "station")
                    {

                    }
                    else
                    {
                        allTileProperties[iter - mapSizeY] = "blank";
                    }
                }
                if (iter - 1 < allTileProperties.Count && iter - 1 > 0)
                {
                    if (allTileProperties[iter - 1] == "station")
                    {

                    }
                    else
                    {
                        allTileProperties[iter - 1] = "blank";
                    }
                }
                if (iter + 1 < allTileProperties.Count && iter + 1 > 0)
                {
                    if (allTileProperties[iter + 1] == "station")
                    {

                    }
                    else
                    {
                        allTileProperties[iter + 1] = "blank";
                    }
                }
                if (iter + mapSizeY < allTileProperties.Count && iter + mapSizeY > 0)
                {
                    if (allTileProperties[iter + mapSizeY] == "station")
                    {

                    }
                    else
                    {
                        allTileProperties[iter + mapSizeY] = "blank";
                    }
                }
                if (iter - mapSizeY - 1 < allTileProperties.Count && iter - mapSizeY - 1 > 0)
                {
                    if (allTileProperties[iter - mapSizeY - 1] == "station")
                    {

                    }
                    else
                    {
                        allTileProperties[iter - mapSizeY - 1] = "blank";
                    }
                }
                if (iter - mapSizeY + 1 < allTileProperties.Count && iter - mapSizeY + 1 > 0)
                {
                    if (allTileProperties[iter - mapSizeY + 1] == "station")
                    {

                    }
                    else
                    {
                        allTileProperties[iter - mapSizeY + 1] = "blank";
                    }
                }
                if (iter + mapSizeY + 1 < allTileProperties.Count && iter + mapSizeY + 1 > 0)
                {
                    if (allTileProperties[iter + mapSizeY + 1] == "station")
                    {

                    }
                    else
                    {
                        allTileProperties[iter + mapSizeY + 1] = "blank";
                    }
                }
                if (iter + mapSizeY - 1 < allTileProperties.Count && iter + mapSizeY - 1 > 0)
                {
                    if (allTileProperties[iter + mapSizeY - 1] == "station")
                    {

                    }
                    else
                    {
                        allTileProperties[iter + mapSizeY - 1] = "blank";
                    }
                }
            }
        }

        //Generate the actual map tiles

        int tileIter = 0;

        for (int YIter = 0; YIter <= mapSizeY; YIter++)
        {
            if (flagsList[2] == true)
            {
                flagsList[2] = false;
                positionOffset = 0;
            }
            else if (flagsList[2] == false)
            {
                flagsList[2] = true;
                positionOffset = 2.5f;
            }

            for (int XIter = 0; XIter <= mapSizeX; XIter++)
            {
                GenerateTile(allTileProperties[tileIter], XIter, YIter);
                tileIter++;
            }
        }

    }

    void GenerateTile(string rollResult, int XIter, int yIter)
    {
        float XPosition = (XIter * 5) + positionOffset;
        float YPosition = yIter * 5;

        GameObject temp = Instantiate(placeholder);

        temp.transform.position = new Vector3(XPosition, 0, YPosition);

        if(rollResult == "station")
        {
            temp.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (rollResult == "asteroid")
        {
            temp.GetComponent<MeshRenderer>().material.color = Color.black;
        }
        else if (rollResult == "system")
        {
            temp.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (rollResult == "nebula")
        {
            temp.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else if (rollResult == "event")
        {
            temp.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (rollResult == "startPos")
        {
            temp.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
        else if (rollResult == "finishPos")
        {
            temp.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
    }

    List<int> DecideWeights(int baseBlankChance, int baseStationChance, int baseAsteriodChance, int baseNebulaChance, int baseStartPosChance,
                            int baseFinishPosChance, int baseEventChance, int baseSystemChance, bool startPosPlaced, bool finishPosPlaced,
                            int YIter, int XIter)
    {

        List<int> weightsList = new List<int>();

        if (startPosPlaced == false)
        {
            if (YIter < 5)
            {
                baseStartPosChance = 0;
            }
            else if ((YIter > 8) && (XIter > 300 && XIter < 700))
            {
                baseStartPosChance = 80;
            }

        }
        else
        {
            baseStartPosChance = 0;
        }

        if (finishPosPlaced == false)
        {
            if (YIter < 985)
            {
                baseFinishPosChance = 0;
            }
            else if ((YIter > 985) && (XIter > 300 && XIter < 700))
            {
                baseFinishPosChance = 80;
            }
        }
        else
        {
            baseFinishPosChance = 0;
        }

        weightsList.Add(baseStartPosChance);
        weightsList.Add(baseFinishPosChance);
        weightsList.Add(baseBlankChance);
        weightsList.Add(baseStationChance);
        weightsList.Add(baseAsteriodChance);
        weightsList.Add(baseNebulaChance);
        weightsList.Add(baseEventChance);
        weightsList.Add(baseSystemChance);
        
        return weightsList; 
    }

    string MakeRoll(List<int> weightsList, List<bool> flagsList)
    {
        string result = "blank";

        int total = 0;

        for(int iter = 0; iter < weightsList.Count; iter++)
        {
            total = total + weightsList[iter];
        }

        int randomResult = Random.Range(0, total);
        
        if (randomResult < weightsList[0])
        {
            result = "startPos";
        }
        else if (randomResult < weightsList[0] + weightsList[1])
        {
            result = "finishPos";
        }
        else if(randomResult < weightsList[0] + weightsList[1] + weightsList[2])
        {
            result = "blank";
        }
        else if (randomResult < weightsList[0] + weightsList[1] + weightsList[2] + weightsList[3])
        {
            result = "station";
        }
        else if (randomResult < weightsList[0] + weightsList[1] + weightsList[2] + weightsList[3] + weightsList[4])
        {
            result = "asteroid";
        }
        else if (randomResult < weightsList[0] + weightsList[1] + weightsList[2] + weightsList[3] + weightsList[4] + weightsList[5])
        {
            result = "nebula";
        }
        else if (randomResult < weightsList[0] + weightsList[1] + weightsList[2] + weightsList[3] + weightsList[4] + weightsList[5] + weightsList[6])
        {
            result = "event";
        }
        else if (randomResult < weightsList[0] + weightsList[1] + weightsList[2] + weightsList[3] + weightsList[4] + weightsList[5] + weightsList[6] + weightsList[7])
        {
            result = "system";
        }

        return result;
    }
}

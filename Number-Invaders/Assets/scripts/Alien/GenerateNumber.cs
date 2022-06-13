using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNumber : MonoBehaviour
{

    public TextMesh alienText;                                        // The alien text that contains its number
    private int maxFactorsInAlienNumber;                              // Number of power of 2,3 or 5 we can have in maximum
    private List<int> factorsList;                                    // The list of factors available
    private int numberOfFactors;                                      // The maximum number of factors available
    private int maxOfAliensNumber;                                    // The maximum the alien's number can be
    

///////////////////////// START FUNCTIONS /////////////////////////////////// 

    void Start()
    {
        // We get parameters from MainParameters
        maxFactorsInAlienNumber = MainParameters.current.SumFactor;
        maxOfAliensNumber = MainParameters.current.MaxOfAliensNumber;

        // We duplicate the list of gun availbale from MainParameters
        factorsList = new List<int>();
        foreach( int n in MainParameters.current.ListGunAvailable){
            factorsList.Add(n);
        }
        
        numberOfFactors = factorsList.Count;                                        // Number of factors (as 2,3,4,5, ...) we have
        GenerateANumber();                                                          // We generate the number
    }



////////////////////////////////////////////////////////////

    private void GenerateANumber(){

        
        int alienNumber = 1;                                                            // We initialise the alien's number
        int numberOfFactorsInAlienNumber = Random.Range(1,maxFactorsInAlienNumber+1);   // We randomly choose how many factors there will be in alien's number


        for (int i=0; i<numberOfFactorsInAlienNumber; i++){                             // For each factor we have to put in alien's number

            RemoveTooHighNumber(alienNumber);                                           // We remove number that would create a too much high number
            numberOfFactors = factorsList.Count;                                        // We update the number of factors available

            if (numberOfFactors>0){
                int nextFactorIndex = Random.Range(0,numberOfFactors);                  // We randomly get an index of the list of factors
                int nextFactor = factorsList[nextFactorIndex];                          // We take the adequate number
                alienNumber = alienNumber*nextFactor;                                   // We update the alien's number
            }
            
        }

        alienText.text = alienNumber.ToString();                                        // Update of the alien's text
    }

////////////////////////////////////////////////////////////

    /*
        Remove factors that would lead to a too much high number
    */
    private void RemoveTooHighNumber(int alienNumber){

        List<int> factorToRemoveList = new List<int>();

        foreach(int n in factorsList){
            if (alienNumber * n > maxOfAliensNumber){
                factorToRemoveList.Add(n);
            }
        }

        foreach(int n in factorToRemoveList){
            factorsList.Remove(n);
        }
    }


}

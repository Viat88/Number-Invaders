using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBoxController : MonoBehaviour
{
    public TextMesh numberText;
    private int number;
    private List<int> availableGunList;

    private float timeToChooseButton;
    private bool isChecked = false;
    private bool onButton = false;
    private float time;
    private bool alreadyDone = false;


    public GameObject button;
    private MeshRenderer model;
    public Color initialColor;
    public Color hoverColor;

    // Start is called before the first frame update
    void Start()
    {
        number = int.Parse(numberText.text);

        model = button.GetComponent<MeshRenderer>();
        model.material.color = initialColor;

        timeToChooseButton = MainParameters.current.timeToChooseButton;
        time = timeToChooseButton;

        MainParameters.current.OnGunAvailableChanged += UpdateAvailableGunList;
        UpdateAvailableGunList(MainParameters.current.ListGunAvailable);

        if (availableGunList.Contains(number)){
            SelectBox();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <=0 && onButton && !alreadyDone) {
            if (isChecked){
                DeSelectNumber();
            }
            else{
                SelectNumber();
            }
            
        }
    }

///////////////////////// TRIGGER FUNCTIONS /////////////////////////////////

    private void OnTriggerEnter( Collider other){

        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = true;
            time = timeToChooseButton;
            
        }
    }

/////////////////////

    private void OnTriggerExit( Collider other){
        if (other.CompareTag("Player1") || other.CompareTag("Player2")){
            onButton = false;
        }
        alreadyDone = false;
    }

////////////////////////////////////////////////////////////

    private void UpdateAvailableGunList( List<int> newList){
        availableGunList = newList;
        if (!availableGunList.Contains(number)){
            DeselectBox();
        }
    }

////////////////////////////////////////////////////////////
    private void SelectNumber(){

        alreadyDone = true;
        SelectBox();
        SoundManager.current.PlayClickSound();
        isChecked = true;

        if (availableGunList.Count < 3){
            availableGunList.Add(number);
        } 
        else{
            availableGunList.RemoveAt(0);
            availableGunList.Add(number);
        }
        MainParameters.current.ListGunAvailable = availableGunList;
    }

    private void DeSelectNumber(){
        
        alreadyDone = true;
        DeselectBox();
        SoundManager.current.PlayClickSound();

        availableGunList.Remove(number);
        MainParameters.current.ListGunAvailable = availableGunList;
    }

////////////////////////////////////////////////////////////

    private void SelectBox(){
        model.material.color = hoverColor;
    }

    private void DeselectBox(){
        model.material.color = initialColor;
    }
}

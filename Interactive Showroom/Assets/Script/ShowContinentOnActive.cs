﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowContinentOnActive : MonoBehaviour
{

    // Public variables
    public GameObject obj;
    public GameObject exitButton;

    // Private variables
    private GameObject continent;
    private MeshRenderer parent;
    private MeshRenderer child;
    private float alpha;
    private string[] conti;

    // Rotation variables
    private bool rotation = true;
    private float rotationSpeed = 100.0f;  
    private Vector3[] continentRotation;
    

    void Start(){
        conti = new string[] {"Africa", "Asia", "Australia", "Europa", "NorthAmerica", "SouthAmerica"};   

        continentRotation = new[] {
            new Vector3(-90.0f, 0.0f, -70.0f),
            new Vector3(-125.0f, 1.5f, -13.5f),
            new Vector3(-120.0f, 167.0f, -122.5f),
            new Vector3(-133.5f, -1.5f, -70.0f),
            new Vector3(-127.0f, 5.0f, -195.0f),
            new Vector3(-65.769f, -30.017f, -121.765f)
        };

        // Get parent and child MeshRenderer for the belonging continent, if selected
        foreach(string contiName in conti){
            string co = "Canvas" + contiName;
            if(obj.name == co){
                continent = GameObject.Find(contiName);
                parent = continent.GetComponent<MeshRenderer>();
                child = parent.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(obj.activeSelf == true){
            //Debug.Log(obj.name);
            alpha = 1.0f;
            parent.material.SetFloat("_Alpha", alpha);
            child.material.SetFloat("_Alpha", alpha);
            if(rotation == true){
                rotation = false;
                RotateContinentToFront();
            }
        }else{
            alpha = 0.0f;
            parent.material.SetFloat("_Alpha", alpha);
            child.material.SetFloat("_Alpha", alpha);
            
        }
        if(exitButton.activeSelf == false){
            obj.SetActive(false);
        }
        
    }


    // rotate continent to front if selected
    /* @Todo: fix rotations */
    void RotateContinentToFront(){

        rotation = true;

        GameObject earth = GameObject.Find("Earth");

        // can't close Ui, infinity loop?
        /*for(int i = 0; i <= conti.Length; i++){
            if(obj.name == "Canvas" + conti[i]){
                Quaternion targetRotation = Quaternion.Euler(continentRotation[i]);
                earth.transform.rotation = Quaternion.RotateTowards(earth.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }*/

        if(obj.name == "Canvas" + conti[0]){
            Quaternion targetRotation = Quaternion.Euler(-90.0f, 0.0f, -70.0f);
            earth.transform.rotation = Quaternion.RotateTowards(earth.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }else if(obj.name == "Canvas" + conti[1]){
            Quaternion targetRotation = Quaternion.Euler(-125.0f, 1.5f, -13.5f);
            earth.transform.rotation = Quaternion.RotateTowards(earth.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }else if(obj.name == "Canvas" + conti[2]){
            Quaternion targetRotation = Quaternion.Euler(-120.0f, 167.0f, -122.5f);
            earth.transform.rotation = Quaternion.RotateTowards(earth.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }else if(obj.name == "Canvas" + conti[3]){
            Quaternion targetRotation = Quaternion.Euler(-133.5f, -1.5f, -70.0f);
            earth.transform.rotation = Quaternion.RotateTowards(earth.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }else if(obj.name == "Canvas" + conti[4]){
            Quaternion targetRotation = Quaternion.Euler(-127.0f, 5.0f, -195.0f);
            earth.transform.rotation = Quaternion.RotateTowards(earth.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }else if(obj.name == "Canvas" + conti[5]){
            Quaternion targetRotation = Quaternion.Euler(-65.769f, -30.017f, -121.765f);
            earth.transform.rotation = Quaternion.RotateTowards(earth.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }       
    }

}

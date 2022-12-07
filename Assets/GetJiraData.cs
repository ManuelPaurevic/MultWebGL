using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Text;
using TMPro;

public class GetJiraData : MonoBehaviour{

    public TMP_Text textbox;
    public TMP_InputField inputField;


    //https://oasisintern.atlassian.net/rest/api/latest/project/
    string baseURL = "https://oasisintern.atlassian.net/rest/";
    //string getURL = "api/latest/project";
    string getAccountInfo = "api/latest/myself";
    string target_URL;
    string email = "manuel.paurevic@oasisdigital.com";
    //string token = "DoGYckulN4VE3W7PLm5D329F";
    string authCache;


    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getJira(){

        string token = inputField.text;

        authCache = System.Convert.ToBase64String(Encoding.GetEncoding("UTF-8").GetBytes(email + ":" + token));
        target_URL = baseURL + getAccountInfo;

        WebRequest request = WebRequest.Create(target_URL);
            //adds authorization header for basic authentication
        request.Headers.Add("Authorization", "Basic " + authCache);

        request.Method = "GET";
        WebResponse webResponse = request.GetResponse();
        System.IO.Stream responseStream = webResponse.GetResponseStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(responseStream);
        string response = reader.ReadToEnd();

        Debug.Log(response);
        textbox.text = response;
    }




}

//using PlayFab;
//using PlayFab.ClientModels;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Shop : MonoBehaviour
//{
//    public static Shop instance;
    
//    private void Awake()
//    {
//        if (!instance)
//        {
//            instance = this;
//        }

//        LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest();
//        request.Email = "tnxah.j@gmail.com";
//        request.Password = "123123123";
        
//        PlayFabClientAPI.LoginWithEmailAddress(request, result => {
//            UpdateCatalogItems(); 
//        }, error => {
//            print(error.ErrorMessage);        
//        });
//    }

//    private void UpdateCatalogItems()
//    {
//        ItemManager.instance.InitObjects();
//    }
//}

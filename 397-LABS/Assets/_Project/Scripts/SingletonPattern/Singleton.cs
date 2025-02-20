using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//Platformer397 Namespace
namespace Platformer397 {

    //Singleton Class
    public abstract class Singleton<T> : MonoBehaviour where T : Component {

        public bool AutoUnparentOnAwake = true;
        protected static T instance;
        public static bool HasInstance => instance != null;
        public static T TryGetInstance() => HasInstance ? instance : null;

        //Instance Method
        public static T Instance {

            //Get 
            get {

                //If-Satement
                if (instance == null) {

                    instance = FindAnyObjectByType<T>();

                    //Nested If-Statement
                    if (instance == null) {

                        var gameObject = new GameObject(typeof(T).Name + " Generated");
                        instance = gameObject.AddComponent<T>();

                    } //End of Nested If-Statement

                } //End of If-Statement
                
                return instance;
            
            } //End of Get

        } //End of Instance Method

        //Awake Method
        protected virtual void Awake() {

            //If-Else Statement
            if (AutoUnparentOnAwake) {
                transform.SetParent(null);
            } //End of If-Statement

            //If-Statement
            if (instance == null) {

                instance = this as T;
                DontDestroyOnLoad(gameObject);

            } else {

                //Nested If-Statement
                if (instance != this) {
                    Destroy(gameObject);
                } //End of Nested If-Statement

            } //End of If-Else Statement
             
        } //End of Awake Method

    } //End of Singleton Class

} //End of Platformer397 Namespace

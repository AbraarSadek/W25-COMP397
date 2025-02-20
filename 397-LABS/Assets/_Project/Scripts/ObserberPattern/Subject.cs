using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Platformer397 Namespace
namespace Platformer397 {

    //Subject MonoBehaviour Class
    public abstract class Subject : MonoBehaviour {

        //List of Obervers
        //Add and/or remove obervers from the list
        //Notification method to notify obervers

        [SerializeField] private List<iObserber> obserbers = new List<iObserber>();

        //AddObserber Method
        public void AddObserber(iObserber obserber) => obserbers.Add(obserber);

        //RemoveObserber Method
        public void RemoveObserber(iObserber obserber) => obserbers.Remove(obserber);

        //NotifyObserbers Method
        public void NotifyObserbers() {
            //Foreach Look
            foreach (iObserber obserber in obserbers) {
                obserber.OnNotify();
            } //End of Foreach Look
        } //End of NotifyObserbers Method


    } //End of Subject MonoBehaviour Class

} //End of Platformer397 Namespace
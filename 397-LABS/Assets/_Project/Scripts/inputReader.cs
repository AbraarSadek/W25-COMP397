using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

//Namespace Platformer397
namespace Platformer397 {

    [CreateAssetMenu(fileName = "inputReader1", menuName = "Scriptable Objects/inputReader")]

    //Class inputReader
    public class InputReader : ScriptableObject, IPlayerActions {

        public event UnityAction<Vector2> Move = delegate { };

        InputSystem_Actions input;

        //OnEnable Method
        private void OnEnable() {

            if (input == null) {

                input = new InputSystem_Actions();
                input.Player.SetCallbacks(this);

            } //End of If Statement 

        } //End of OnEnable Method

        //EnablePlayerActions Method
        public void EnablePlayerActions() {

            input.Enable();

        } //End of EnablePlayerActions Method

        //OnMove Method
        public void OnMove(InputAction.CallbackContext context){ 
        
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                case InputActionPhase.Canceled:
                    Move?.Invoke(context.ReadValue<Vector2>());
                    break;
                default:
                    //Debug.Log("No Input Handled");
                    break;
            }

            //Move?.Invoke(context.ReadValue<Vector2>());

        } //End of OnMove Method
        public void OnLook(InputAction.CallbackContext context) { }
        public void OnAttack(InputAction.CallbackContext context) { }
        public void OnInteract(InputAction.CallbackContext context) { }
        public void OnCrouch(InputAction.CallbackContext context) { }
        public void OnJump(InputAction.CallbackContext context) { }
        public void OnPrevious(InputAction.CallbackContext context) { }
        public void OnNext(InputAction.CallbackContext context) { }
        public void OnSprint(InputAction.CallbackContext context) { }

    } //End of Class inputReader

} //End of Namespace Platformer397

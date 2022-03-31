using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerData
{
    public enum Joystick
    {
        Joystick1,
        Joystick2,
        Joystick3,
        Joystick4,
        Joystick5,
        Joystick6
    }

    //[CreateAssetMenu(fileName = "InputPlayer", menuName = "New InputPlayer")]
    public class InputJoystick : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        public int Joystick => ((int)joystick + 1);
        
        private string LHorizontal => "Joy" + Joystick + "LHorizontal";
        private string LVertical => "Joy" + Joystick + "LVertical";
        private string RHorizontal => "Joy" + Joystick + "RHorizontal";
        private string RVertical => "Joy" + Joystick + "RVertical";
        private string dashInput => "joystick " + Joystick + " button 4";
        private string shootInput => "joystick " + Joystick + " button 5";
        private string startInput => "joystick " + Joystick + " button 9";

        //TODO: Clamp to include
        public float LHorizontalAxis => Input.GetAxis(LHorizontal);
        public float LVerticalAxis => Input.GetAxis(LVertical);
        public float RHorizontalAxis => Input.GetAxis(RHorizontal);
        public float RVerticalAxis => Input.GetAxis(RVertical);
        public bool dashInputDown => Input.GetKeyDown(dashInput);
        public bool ShootInputDown => Input.GetKeyDown(shootInput);
        public bool StartInputDown => Input.GetKeyDown(startInput);

        public Vector2 LAxis => Vector2.ClampMagnitude(new Vector2( Input.GetAxis(LHorizontal), Input.GetAxis(LVertical)), 1);
        public Vector2 RAxis => Vector2.ClampMagnitude(new Vector2( Input.GetAxis(RHorizontal), Input.GetAxis(RVertical)), 1);

        public enum DPadButton
        {
             leftButtonState,
             rigthButtonState,
             upButtonState,
             downButtonState
        }

        bool leftButtonState = false;
        bool rigthButtonState = false;
        bool upButtonState = false; 
        bool downButtonState = false;

        public bool IsLeftButtonDown
        {
            get
            {
                bool inputValue = LHorizontalAxis < -0.5f;
                if (inputValue && leftButtonState) 
                    return false;
                leftButtonState = inputValue;
                return inputValue;
            }
        }
        public bool IsRigthButtonDown
        {
            get
            {
                bool inputValue = LHorizontalAxis > 0.5f;
                if (inputValue && rigthButtonState)
                    return false;
                rigthButtonState = inputValue;
                return inputValue;
            }
        }
        public bool IsRAxisDown => RAxis != Vector2.zero;
        public bool IsLAxisDown => LAxis != Vector2.zero;

    }
}


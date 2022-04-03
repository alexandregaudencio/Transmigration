using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerDataNamespace
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

    public class InputJoystick : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;

        public int GetJoystick => ((int)joystick + 1);

        //public Joystick intToJoystick(int value) => Joystick[value];
        private string LHorizontal => "Joy" + GetJoystick + "LHorizontal";
        private string LVertical => "Joy" + GetJoystick + "LVertical";
        private string RHorizontal => "Joy" + GetJoystick + "RHorizontal";
        private string RVertical => "Joy" + GetJoystick + "RVertical";
        private string dashInput => "joystick " + GetJoystick + " button 4";
        private string shootInput => "joystick " + GetJoystick + " button 5";
        private string startInput => "joystick " + GetJoystick + " button 9";
        public string TriangleInput => "joystick " + GetJoystick + " button 0";

        public Joystick Joystick { set => joystick = value; get => joystick; }

        //TODO: Clamp to include
        public float LHorizontalAxis => Input.GetAxis(LHorizontal);
        public float LVerticalAxis => Input.GetAxis(LVertical);
        public float RHorizontalAxis => Input.GetAxis(RHorizontal);
        public float RVerticalAxis => Input.GetAxis(RVertical);
        public bool dashInputDown => Input.GetKeyDown(dashInput);
        public bool getShootInput => Input.GetKey(shootInput);
        public bool StartInputDown => Input.GetKeyDown(startInput);
        public Vector2 LAxis => Vector2.ClampMagnitude(new Vector2( Input.GetAxis(LHorizontal), Input.GetAxis(LVertical)), 1);
        public Vector2 RAxis => Vector2.ClampMagnitude(new Vector2( Input.GetAxis(RHorizontal), Input.GetAxis(RVertical)), 1);


        //public enum DPadButton
        //{
        //     leftButtonState,
        //     rigthButtonState,
        //     upButtonState,
        //     downButtonState
        //}

        bool leftButtonState = false;
        bool rigthButtonState = false;
        bool upButtonState = false; 
        bool downButtonState = false;

        //CRIADO PARA DETECTAR O TOQUE PARA ESQUERDA E DIRETA (SEM PRESSIONAR)
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
        public bool GetRAxisKey => RAxis != Vector2.zero;
        public bool GetLAxisKey => LAxis != Vector2.zero;

        //private void Update()
        //{
        //    if (StartInputDown) joystickActiveHadler.UpdateDictionaryValue(GetJoystick, true);
        //}


    }
}


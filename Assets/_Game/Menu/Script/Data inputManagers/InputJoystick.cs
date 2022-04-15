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
        private Dictionary<Joystick, int> joystickTeamIndex = new Dictionary<Joystick, int>();

        public int GetJoystick => ((int)joystick + 1);

        //public Joystick intToJoystick(int value) => Joystick[value];
        private string LHorizontal => "Joy" + GetJoystick + "LHorizontal";
        private string LVertical => "Joy" + GetJoystick + "LVertical";
        private string RHorizontal => "Joy" + GetJoystick + "RHorizontal";
        private string RVertical => "Joy" + GetJoystick + "RVertical";
        public string dashInput => "joystick " + GetJoystick + " button 4";
        public string shootInput => "joystick " + GetJoystick + " button 5";
        public string startInput => "joystick " + GetJoystick + " button 9";
        public string TriangleInput => "joystick " + GetJoystick + " button 0";

        public Joystick Joystick { set => joystick = value; get => joystick; }

        public float LHorizontalAxis => Input.GetAxis(LHorizontal);
        public float LVerticalAxis => Input.GetAxis(LVertical);
        public float RHorizontalAxis => Input.GetAxis(RHorizontal);
        public float RVerticalAxis => Input.GetAxis(RVertical);
        public bool dashInputDown => Input.GetKeyDown(dashInput);
        public bool getShootInput => Input.GetKey(shootInput);
        public bool StartInputDown => Input.GetKeyDown(startInput);
        public Vector2 LAxis => Vector2.ClampMagnitude(new Vector2( Input.GetAxis(LHorizontal), Input.GetAxis(LVertical)), 0.7f);
        public Vector2 RAxis => Vector2.ClampMagnitude(new Vector2( Input.GetAxis(RHorizontal), Input.GetAxis(RVertical)), 0.7f);
        public Vector2 LAxisRaw => Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw(LHorizontal), Input.GetAxisRaw(LVertical)), 0.7f);
        public Vector2 RAxisRaw => Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw(RHorizontal), Input.GetAxisRaw(RVertical)), 0.7f);


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

        public Dictionary<Joystick, int> JoystickTeamIndex { get => joystickTeamIndex; set => joystickTeamIndex = value; }

        //private void Update()
        //{
        //    if (StartInputDown) joystickActiveHadler.UpdateDictionaryValue(GetJoystick, true);
        //}

        private void Start()
        {
            SetAllJoystickTeamIndex();
        }

        private void SetAllJoystickTeamIndex()
        {
            joystickTeamIndex.Add(Joystick.Joystick1, 0);
            joystickTeamIndex.Add(Joystick.Joystick2, 0);
            joystickTeamIndex.Add(Joystick.Joystick3, 1);
            joystickTeamIndex.Add(Joystick.Joystick4, 1);
            joystickTeamIndex.Add(Joystick.Joystick5, 2);
            joystickTeamIndex.Add(Joystick.Joystick6, 2);
        }

        private void OnGUI()
        {
            if(joystick == Joystick.Joystick1)
            {
                GUI.Label(new Rect(10, 100, 500, 100), "LAxis: " + LAxis.magnitude);

            }


        }


    }
}


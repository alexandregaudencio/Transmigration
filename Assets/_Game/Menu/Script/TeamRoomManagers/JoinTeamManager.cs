using Photon.Pun;
using TMPro;

public class JoinTeamManager : MonoBehaviourPunCallbacks
{
    private TMP_InputField inputFieldJoinTeam;
    private TMP_Dropdown dropdownJoinTeam;

    string dropdownTeamName
    {
        get
        {
           return  dropdownJoinTeam.options[dropdownJoinTeam.value].text;
        }
    }
    string inputTeamName
    {
        get
        {
            return inputFieldJoinTeam.text;
        }
    }
    public enum  TeamNameTarget
    {
        INPUTFIELD,
        DROPDOWN
    }
    
    private TeamNameTarget teamNameTarget;

    private void Awake()
    {
        inputFieldJoinTeam = GetComponentInChildren<TMP_InputField>();
        dropdownJoinTeam = GetComponentInChildren<TMP_Dropdown>();
    }

    private void Start()
    {
        teamNameTarget = TeamNameTarget.DROPDOWN;

        inputFieldJoinTeam.onValueChanged.AddListener(delegate
        {
            OnInputFieldValueChanged();
        });

    }

    private void OnInputFieldValueChanged()
    {
        //Debug.Log("Value: " + inputFieldJoinTeam.text);

    }

    public void OnClick_JoinRoom()
    {
        if (teamNameTarget == TeamNameTarget.INPUTFIELD)
        {
            PhotonNetwork.JoinRoom(inputTeamName);
        }
        if (teamNameTarget == TeamNameTarget.DROPDOWN)
        {
            if (dropdownJoinTeam.value == 0)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.JoinRoom(dropdownTeamName);
            }
        }
    }


}




////[System.Serializable]
//public interface ITargetRoom
//{
//    public void IntializeRoom();
//}

//public class DropdowRoom : ITargetRoom
//{
//    string teamRoomName;
//    TMP_Dropdown dropdown;
//    public void IntializeRoom()
//    {
//        if (dropdown.value == 0)
//        {
//            PhotonNetwork.JoinRandomRoom();
//        }
//        else
//        {
//            PhotonNetwork.JoinRoom(teamRoomName);
//        }
//    }
//}


//public class InputfielRoom : ITargetRoom
//{
//    string teamRoomName;
//    TMP_InputField inputfield;

//    public void IntializeRoom()
//    {
//        if (inputfield.text != ""  /*&& inputFieldJoinTeam.text.Length == 3*/ )
//        {
//            PhotonNetwork.JoinRandomRoom();
//        }
//        else
//        {
//            PhotonNetwork.JoinRoom(teamRoomName);
//        }
//    }

//}


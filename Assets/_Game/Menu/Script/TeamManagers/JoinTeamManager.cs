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
        if(inputFieldJoinTeam.text != ""  /*&& inputFieldJoinTeam.text.Length == 3*/ )
        {
            teamNameTarget = TeamNameTarget.INPUTFIELD;
        } else
        {
            teamNameTarget = TeamNameTarget.DROPDOWN;

        }
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

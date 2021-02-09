using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    #region UI Elements that we need to fill/control
    public Text npcNameField;
    public Text dialogTextField;
    public GameObject acceptQuestBtn;
    public GameObject completeQuestBtn;
    public GameObject dialogPanel;


    public LookMouse mouseRot;
    #endregion

    #region Dialog-Variables
    private Dialog currentDialog;
    private List<string> conversation;
    private int dialogPos;
    #endregion

    void Start()
    {
        dialogPanel.SetActive(false);
        acceptQuestBtn.SetActive(false);
        completeQuestBtn.SetActive(false);
    }

    public void Update()
    {
        if (currentDialog != null && currentDialog.quest.completed)
        {
            completeQuestBtn.SetActive(false);

            if (currentDialog.quest.childQuests != null && currentDialog.quest.childQuests.Count > 0)
            {
                //The Dialog needs to change as well
                currentDialog.quest = currentDialog.quest.childQuests[0];
            }
        }
    }

    public void StartDialog(Dialog diag)
    {
        Cursor.lockState = CursorLockMode.None;        
        npcNameField.text = diag.npcName;
        conversation = diag.dialogLines;
        dialogPos = 0;
        currentDialog = diag;        
        dialogPanel.SetActive(true);//Activate Panel
      
        ShowDialog();
        
    }

    public void AcceptQuest()
    {
        if (currentDialog.quest != null && !currentDialog.quest.isQuestAccepted)
        {
            var temp = GameObject.Find("Questlog").GetComponent<Questlog>();
            //Add Quest to Questlog
            temp.AddQuest(currentDialog.quest);
            currentDialog.quest.isQuestAccepted = true;
            acceptQuestBtn.SetActive(false);
           
            StopDialog();
        }
    }


    public void ShowDialog()
    {
        dialogTextField.text = conversation[dialogPos];
        
    }

    public void ShowDialog(string text)
    {
        dialogTextField.text = text;
        
    }

    //Special Case
    public void ShowAwaitingQuestDialog()
    {
        dialogTextField.text = currentDialog.awaitingQuestCompletion;
    }

    public void StopDialog()
    {
        dialogPanel.SetActive(false);
       
        Cursor.lockState = CursorLockMode.Locked;
      
    }

    public void Next()
    {
        if ( dialogPos < conversation.Count - 1)
        {
            dialogPos++;
            ShowDialog();
            acceptQuestBtn.SetActive(false);
        }
        //Show the Accept Quest button if the Dialog has reached its final line of text && the dialog has a quest && the quest hasn't been accepted
        if (dialogPos == conversation.Count - 1 && currentDialog.quest != null && !currentDialog.quest.isQuestAccepted)
        {
            acceptQuestBtn.SetActive(true);

        }
        //If the quest exists and it has been accepted: Show the "awaiting Quest completion text"
        if (currentDialog.quest != null && currentDialog.quest.isQuestAccepted)
        {
            ShowAwaitingQuestDialog();
        }

        if (currentDialog.quest.finished)
        {
            acceptQuestBtn.SetActive(false);
            ShowDialog("Thanks!\nYou've earned your reward!");
            completeQuestBtn.SetActive(true);
        }        

        if(currentDialog.quest.completed == true)
        {
            acceptQuestBtn.SetActive(false);
            completeQuestBtn.SetActive(false);
        }

        if (currentDialog.quest.completed == true)
        {
            ShowDialog(currentDialog.questDone);
        }
    }

    public void CompleteQuest()
    {
        currentDialog.quest.CompleteQuest();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Dialogue : MonoBehaviour
{
    [SerializeField] int lettersecond;
    [SerializeField] Text dialogText;
    [SerializeField] Color highlightedColor;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;
    [SerializeField] Text ppText;
    [SerializeField] Text typeText;

   
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersecond);
        }
        yield return new WaitForSeconds(1f);
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }
    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection ( int selectedAction)
    {
        for (int i=0; i<actionTexts.Count; ++i)
        {
            if (i == selectedAction)
                actionTexts[i].color = highlightedColor;
            else
                actionTexts[i].color = Color.black;
        }
    }
    public void UpdateMoveSelection(int selectedMove, MoveManager move)
    {
        for(int i=0; i<moveTexts.Count; i++)
        {
            if (i == selectedMove)
                moveTexts[i].color = highlightedColor;
            else
                moveTexts[i].color = Color.black;
        }
        ppText.text = $"Power {move.Powerpoint}/{move.Base.Powerpoint}";
        typeText.text = move.Base.Pstyles.ToString();
    }
    public void SetMoveNames(List<MoveManager>moves)
    {
        for (int i=0; i<moveTexts.Count; ++i)
        {
            if (i < moves.Count)
                moveTexts[i].text = moves[i].Base.Name;
            else
                moveTexts[i].text = "x";
        }
    }
    

    
}

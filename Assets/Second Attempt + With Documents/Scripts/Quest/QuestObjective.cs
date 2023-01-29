public abstract class QuestObjective
{
    //the id of the objective
    private int questObjectiveID;
    //The name of the current objective starts  with defeat 10 enemies, then becomes return to NAME to turn in quest
    protected string questObjectiveName;
    //Is this objecctive the current objective, or is it a later objective? 
    protected bool isObjectiveEnabled;
    //is this objective the final objective in the quest line?
    protected bool isFinalObjectiveInQuest;

    protected bool isObjectiveFinished;
    //if there is another objective to unlock in the quest line, then is the id to enable it
    protected int questObjectiveToUnlock;
    //an event for the quest, usually a cutscene or enabling an npc to talk to.
    //private QuestEvent event;

    public void StartObjective()
    {
        isObjectiveEnabled = true;
    }

    protected void CompleteObjective()
    {
        isObjectiveEnabled = false;

        if (!isFinalObjectiveInQuest)
        {
            //enable the next quest objective
        }
        //the quest is ready to be turned in
    }

    public int QuestObjectiveId => questObjectiveID;
    public int QuestObjectiveToUnlock => questObjectiveToUnlock;

    public string QuestObjectiveName => questObjectiveName;

    public bool IsObjectiveEnabled => isObjectiveEnabled;
    public bool IsFinalObjectiveInQuest => isFinalObjectiveInQuest;
    public bool IsObjectiveFinished => isObjectiveFinished;
}
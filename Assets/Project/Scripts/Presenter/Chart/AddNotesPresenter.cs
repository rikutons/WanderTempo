using ThreeD_Sound_Game.Notes;
using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.Utility;
namespace ThreeD_Sound_Game.Presenter
{
    public class AddNotesPresenter : SingletonMonoBehaviour<AddNotesPresenter>
    {
        public void AddNote(Note note)
        {
            ChartData.Notes.Add(note);
        }
    }
}

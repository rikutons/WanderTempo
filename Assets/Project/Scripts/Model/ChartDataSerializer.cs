using ThreeD_Sound_Game.DTO;
using ThreeD_Sound_Game.Notes;
using ThreeD_Sound_Game.Presenter;
using System.Linq;

namespace ThreeD_Sound_Game.Model
{
    public class ChartDataSerializer
    {
        public static void Deserialize(string json)
        {
            var chartData = UnityEngine.JsonUtility.FromJson<MusicDTO.ChartData>(json);
            var notePresenter = AddNotesPresenter.Instance;

            ChartData.Name.Value = chartData.name;
            ChartData.BPM.Value = chartData.BPM;
            ChartData.MaxBlock.Value = chartData.maxBlock;
            ChartData.OffsetSamples.Value = chartData.offset;

            foreach (var note in chartData.notes)
            {
                if (note.type == 1)
                {
                    notePresenter.AddNote(ToNoteObject(note));
                    continue;
                }

                var longNoteObjects = note.notes
                    .Select(note_ => ToNoteObject(note_))
                    .ToList();
                var longNoteParent = longNoteObjects[0];
                longNoteParent.endPosition = longNoteObjects.Last().startPosition;
                notePresenter.AddNote(longNoteParent);
            }
        }

        public static Note ToNoteObject(MusicDTO.ParentNote musicNote)
        {
            return new Note(
                new NotePosition(musicNote.LPB, musicNote.num, musicNote.block),
                musicNote.type == 1 ? NoteTypes.Single : NoteTypes.Long);
        }

        public static Note ToNoteObject(MusicDTO.Note musicNote)
        {
            return new Note(
                new NotePosition(musicNote.LPB, musicNote.num, musicNote.block),
                musicNote.type == 1 ? NoteTypes.Single : NoteTypes.Long);
        }
    }
}

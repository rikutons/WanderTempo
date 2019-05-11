namespace ThreeD_Sound_Game.Notes
{
    public class Note
    {
        public NotePosition startPosition = NotePosition.None;
        public NotePosition endPosition = NotePosition.None; //LongNote—p
        public NoteTypes type = NoteTypes.Single;

        public Note(NotePosition position, NoteTypes type)
        {
            this.startPosition = position;
            this.type = type;
        }

        public Note(NotePosition position)
        {
            this.startPosition = position;
        }

        public Note(Note note)
        {
            this.startPosition = note.startPosition;
            this.type = note.type;
        }

        public Note() { }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var c = (Note)obj;

            return startPosition.Equals(c.startPosition) &&
                type == c.type;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

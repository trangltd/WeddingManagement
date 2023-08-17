namespace WeddingManagement
{
    internal class Lobby
    {
        public string LobbyNo;
        public string LobbyTypeNo;
        public string LobbyName;
        public int MaxTable;
        public string Note;

        public Lobby() { }

        public Lobby(string LobbyNo, string LobbyTypeNo, 
            string LobbyName, int MaxTable, string Note)
        {
            this.LobbyNo = LobbyNo;
            this.LobbyTypeNo = LobbyTypeNo;
            this.LobbyName = LobbyName;
            this.MaxTable = MaxTable;
            this.Note = Note;
        }
    }
}

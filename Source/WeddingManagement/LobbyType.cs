namespace WeddingManagement
{
    internal class LobbyType
    {
        public string LobbyTypeNo { get; set; }
        public string LobbyTypeName { get; set; }
        public long MinTablePrice { get; set; }

        public LobbyType(string LobbyTypeNo, string LobbyTypeName, long MinTablePrice)
        {
            this.LobbyTypeNo = LobbyTypeNo;
            this.LobbyTypeName = LobbyTypeName;
            this.MinTablePrice = MinTablePrice;
        }

        public LobbyType() { }
    }
}

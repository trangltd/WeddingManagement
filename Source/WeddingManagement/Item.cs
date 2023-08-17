namespace WeddingManagement
{
    internal class Item
    {
        public string ItemNo;
        public string ItemName;
        public long ItemPrice;
        public string Note;

        public Item(string ItemNo, string ItemName, long ItemPrice, string Note = "")
        {
            this.ItemNo = ItemNo;
            this.ItemName = ItemName;
            this.ItemPrice = ItemPrice;
            this.Note = Note;
        }

        public Item() { }
    }
}

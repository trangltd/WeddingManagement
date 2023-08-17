namespace WeddingManagement
{
    internal class Service
    {
        public string ServiceNo;
        public string ServiceName;
        public long ServicePrice;
        public string Note;

        public Service(string ServiceNo, string ServiceName, long ServicePrice, 
            string Note = "")
        {
            this.ServiceNo = ServiceNo;
            this.ServiceName = ServiceName;
            this.ServicePrice = ServicePrice;
            this.Note = Note;
        }

        public Service() { }
    }
}

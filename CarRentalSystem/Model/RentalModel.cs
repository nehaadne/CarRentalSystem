namespace CarRentalSystem.Model
{
    public class RentalModel
    {
        public int id { get; set; }
        public int carid { get; set; }
        public int custid { get; set; }
        public int carno { get; set; }
        public int fee { get; set; }
        public DateTime sdate { get; set; }
        public DateTime edate { get; set; }
        public string available { get; set; }

    }
}

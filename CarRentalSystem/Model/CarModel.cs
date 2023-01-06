namespace CarRentalSystem.Model
{
    public class CarModel
    {
        public int id { get; set; }
        public int carno { get; set; }
        public string company { get; set; }
        public string model { get; set; }
        public string available { get; set; }

        public static implicit operator int(CarModel v)
        {
            throw new NotImplementedException();
        }
    }
}

namespace FakeStoreApp.EMR
{
    public class BMICalculator
    {
        public double CalculateBmi(double heightInMeters,  double weightInKilos)
        {
            return weightInKilos/(heightInMeters * heightInMeters);
        }
    }
}

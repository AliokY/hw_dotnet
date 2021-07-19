namespace AssemblyOne
{
    public class Motorcycle
    {
        public const int EngineVolume = 803;

        internal const int EnginePower = 73;

        private string registrationNumber = "GR.ASC-9527";

        private protected const string Model = "Ducati Scrambler Icon Dark";

        private protected int age = 4;

        private int price = 0;

        public int Price
        {
            set
            {
                price = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
            set
            {
                registrationNumber = value;
            }
        }

        protected void PreparingForRide()
        { }

        protected internal void DriveAroundCity()
        { }

        private protected void DriveOnHighway()
        { }
    }
}

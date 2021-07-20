namespace HW08.Task2
{
    class JuniorDeveloper : Engineer
    {
        public override Position CurrentPositioin { get; set; } = Position.JuniorDeveloper;
        public override int SalaryCoeff { get; set; } = 1;

        public override int CurrentPremium { get; set; } = 0;

        public override int CurrentSalary { get; set; }

        private EnglishLevel _englishLevel;
        public override EnglishLevel englishLevel
        {
            get
            {
                return _englishLevel;
            }
            set
            {
                if (Task2.EnglishLevel.A2 <= value)
                {
                    _englishLevel = value;
                }
            }
        }

        public JuniorDeveloper(string name, string surname, int experience, string[] responsibilities,
            string[] technologies, EnglishLevel englishLevel, string gitHubLink) :
            base(name, surname, experience, responsibilities, technologies, englishLevel, gitHubLink)
        {
            CurrentSalary = BaseSalary * SalaryCoeff + CurrentPremium;
        }

        public override int GetSalary()
        {
            return CurrentSalary;
        }
    }
}

namespace HW08.Task1
{
    class JuniorDeveloper : Engineer
    {
        public override Position CurrentPositioin { get; set; } = Position.JuniorDeveloper;

        public override int CurrentSalary { get; set; }

        public JuniorDeveloper(string name, string surname, int experience, string[] responsibilities,
            string[] technologies, EnglishLevel englishLevel, string gitHubLink) :
            base(name, surname, experience, responsibilities, technologies, englishLevel, gitHubLink)
        {
            CurrentSalary = BaseSalary;
        }

        public override int GetSalary()
        {
            return CurrentSalary;
        }
    }
}

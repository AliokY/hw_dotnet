namespace PizzaDelivery.Console.Controls.RegexConstants
{
   public static class RegexConst
    {
        public const string RegName = @"^[А-ЯЁ][а-яё]*$";
        public const string RegLogin = @"^[A-Z][A-Za-zА-Яа-я0-9]{1,10}$";
        public const string RegPassword = @"^[A-Za-zА-Яа-я0-9]{0,8}$";
        public const string RegEmail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)"
        +@"|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    }
}


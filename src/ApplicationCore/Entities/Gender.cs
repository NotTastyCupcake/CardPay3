namespace Metcom.CardPay3.ApplicationCore.Entities
{
    public class Gender : BaseEntity
    {
        public string GenderName { get; private set; }
        public string ShortGenderName { get; private set; }

        public Gender(string name, string shortName)
        {
            GenderName = name;
            ShortGenderName = shortName;
        }
        public Gender()
        {
            // required by EF
        }
    }
}

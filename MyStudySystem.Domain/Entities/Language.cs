
namespace MyStudySystem.Domain.Entities
{
    public class Language
    {
        public string Code { get; private set; }

        private Language(string code)
        {
            Code = code;
        }

        public static Language English => new Language("en-US");
        public static Language Russian => new Language("ru-RU");

        public override bool Equals(object obj)
        {
            if (obj is Language other)
                return Code == other.Code;

            return false;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }

}

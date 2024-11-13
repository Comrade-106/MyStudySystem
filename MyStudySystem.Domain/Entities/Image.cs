
namespace MyStudySystem.Domain.Entities
{
    public class Image
    {
        public string Url { get; private set; }
        public string Description { get; private set; }

        public Image(string url, string description = null)
        {
            Url = url;
            Description = description;
        }
    }

}

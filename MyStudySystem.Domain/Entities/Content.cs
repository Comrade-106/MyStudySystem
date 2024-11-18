
using MyStudySystem.Domain.Common;

namespace MyStudySystem.Domain.Entities
{
    public class Content : AuditableEntity
    {
        public Guid ContentId { get; private set; }
        public string Text { get; private set; }

        public Guid SectionId { get; private set; }

        public IReadOnlyCollection<Image> Images => _images.AsReadOnly();
        private readonly List<Image> _images = new List<Image>();

        public Content(string text)
        {
            Text = text;
        }

        public void AddImage(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            _images.Add(image);
        }

        public void RemoveImage(Image image)
        {
            _images.Remove(image);
        }
    }

}

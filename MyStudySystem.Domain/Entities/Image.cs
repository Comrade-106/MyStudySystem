
using MyStudySystem.Domain.Common;

namespace MyStudySystem.Domain.Entities
{
    public class Image : AuditableEntity
    {
        public Guid ImageId { get; private set; }
        public byte[] Data { get; private set; }
        public string Description { get; private set; }

        public Guid ContentId { get; private set; }

        public Image(byte[] data, string description = null)
        {
            ImageId = Guid.NewGuid();
            Data = data;
            Description = description;
        }
    }
}

using System.Collections.Generic;

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    public class MedidaTemplateAttachment : Attachment<MediaTemplatePayload>
    {
        public MedidaTemplateAttachment() : base("template")
        {

        }

        public MedidaTemplateAttachment(List<MediaElement> elements) : this()
        {
            Payload = new MediaTemplatePayload(elements);
        }
    }
}


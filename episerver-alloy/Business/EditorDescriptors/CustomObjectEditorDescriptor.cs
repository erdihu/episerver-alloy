using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using episerver_alloy.Models;

namespace episerver_alloy.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(MyCustomObject),
        UIHint = "MyCustomObject")]
    public class CustomObjectEditorDescriptor : EditorDescriptor
    {
        public CustomObjectEditorDescriptor()
        {
            ClientEditingClass = "alloy/editors/MyCustomObjectProperty";
        }
    }
}

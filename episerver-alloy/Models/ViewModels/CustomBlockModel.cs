using episerver_alloy.Models.Blocks;

namespace episerver_alloy.Models.ViewModels
{
    public class CustomBlockModel
    {
        public CustomBlockModel(CustomBlock currentBlock)
        {
            CustomObject = currentBlock.ChartSettings;
            SomeText = currentBlock.SomeText;
        }

        public string SomeText { get; }

        public MyCustomObject CustomObject { get; }
    }
}

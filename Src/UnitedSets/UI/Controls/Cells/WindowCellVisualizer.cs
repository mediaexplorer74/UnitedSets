//using Get.UI.Data;
using Get.UI.Controls.Panels;
using Microsoft.UI.Xaml.Controls;
using UnitedSets.Cells;
using WindowHoster;

namespace UnitedSets.UI.Controls.Cells;
public partial class WindowCellVisualizer(WindowCell cell) : TemplateControl<WindowHost>
{
    protected override void Initialize(WindowHost rootElement)
    {
        rootElement.Margin = new(10);
        rootElement.AssociatedWindow = cell.Window;
    }

    protected override void Initialize(Grid rootElement) => throw new System.NotImplementedException();
    protected override void Initialize(OrientedStack rootElement) => throw new System.NotImplementedException();
}

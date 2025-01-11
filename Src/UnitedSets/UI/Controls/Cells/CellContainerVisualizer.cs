//using Get.UI.Data;
using Microsoft.UI.Xaml.Controls;
using Get.Data.XACL;
using Get.Data.Properties;
using Get.Data.DataTemplates;
using Microsoft.UI.Xaml;
using UnitedSets.Cells;
using Get.UI.Controls.Panels;
using WindowHoster;
namespace UnitedSets.UI.Controls.Cells;
public partial class CellContainerVisualizer(ContainerCell cellContainer) : TemplateControl<Grid>
{
    protected override void Initialize(Grid rootElement)
    {
        rootElement.Children.Add(new OrientedStack
        {
            Tag = "Cell Container",
            //OrientationBinding = OneWay(cellContainer.OrientationProperty),
            Children =
            {
                CollectionItemsBinding.Create(
                    cellContainer.SubCells,
                    new DataTemplate<Cell, UIElement>(
                          x => default
                        //x => new GenericCellVisualizer(x.CurrentValue)
                        //{
                        //    CellBinding = OneWay(x)
                        //}
                    )
                )
            }
        });
    }

    protected override void Initialize(OrientedStack rootElement) => throw new System.NotImplementedException();
    protected override void Initialize(WindowHost rootElement) => throw new System.NotImplementedException();
}

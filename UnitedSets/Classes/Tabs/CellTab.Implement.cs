using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Window = WinWrapper.Window;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using UnitedSets.UI.FlyoutModules;

namespace UnitedSets.Classes.Tabs;

partial class CellTab
{
    protected override Bitmap? BitmapIcon => null;
    public override BitmapImage? Icon => null;
    public override string DefaultTitle => "Cell Tab";
    public override IEnumerable<Window> Windows => Enumerable.Repeat(default(Window), 0);

    // API
    public override void Focus() { }

    public async override Task TryCloseAsync()
    {
        await Task.Run(async delegate
        {
            var allcells = MainCell.AllSubCells.ToArray();
            await Task.WhenAll(
                from cell in allcells
                where cell.HasWindow
                select cell.CurrentCell!.Close()
            );
            while (MainCell.AllSubCells.Any(x => x.HasWindow && x.CurrentCell!.IsWindowStillValid()))
            {
                await Task.Delay(500);
            }
            _IsDisposed = true;
        });
		DoRemoveTab();
    }

    public override void DetachAndDispose(bool JumpToCursor = false)
    {
        //var window = new MainWindow();
        //window.Tabs.Add(new CellTab(window, MainCell.DeepClone(window)));
        foreach (var cell in MainCell.AllSubCells.ToArray())
        {
			cell.CurrentCell?.DetachAndDispose();
        }
        _IsDisposed = true;
        //window.Activate();
    }

    // UI
    protected override void OnDoubleClick(UIElement sender, DoubleTappedRoutedEventArgs args)
    {
		DoShowFlyout(
                new MultiWindowModifyFlyoutModule(
				    (
					    from x in MainCell.AllSubCells
					    where x.HasWindow
					    select x.CurrentCell
				    ).ToArray()
                ),
                args.GetPosition(sender),
                sender,
                args.PointerDeviceType
        );
    }
}
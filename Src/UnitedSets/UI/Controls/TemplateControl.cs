using Get.UI.Controls.Panels;
using Microsoft.UI.Xaml.Controls;
using WindowHoster;

namespace UnitedSets.UI.Controls;

public abstract class TemplateControl<T>
{
    protected abstract void Initialize(Grid rootElement);

    protected abstract void Initialize(OrientedStack rootElement);

    protected abstract void Initialize(WindowHost rootElement);

}
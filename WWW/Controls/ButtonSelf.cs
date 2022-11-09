using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using System.ComponentModel;

namespace WWW.Controls
{
    [ControlMarkupOptions(AllowContent = true)]
    public class ButtonSelf : CompositeControl
    {
        public DotvvmControl GetContents([DefaultValue(null)] ValueOrBinding<string> Text, ICommandBinding Click = null)
        {
            return new Button().AddCssClass("btn btn-primary").SetProperty(c => c.ButtonTagName, ButtonTagName.button).SetProperty(c => c.Text, Text).SetProperty(c=>c.Click, Click).SetProperty(PostBack.HandlersProperty, this.GetValue(PostBack.HandlersProperty));
        }
    }
}

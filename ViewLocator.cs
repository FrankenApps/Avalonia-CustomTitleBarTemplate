using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CustomTitleBarTemplate.ViewModels;

namespace CustomTitleBarTemplate
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        Control ITemplate<object, Control>.Build(object param)
        {
            var name = param.GetType().FullName.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
using System.Windows;
using System.Windows.Controls;

namespace BindingTypesDemo
{
    /// <summary>
    /// 为按钮提供附加属性，用于展示 TemplatedParent 绑定
    /// </summary>
    public static class ButtonExtensions
    {
        // 定义 Description 附加属性
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached(
                "Description",
                typeof(string),
                typeof(ButtonExtensions),
                new PropertyMetadata(""));

        // Getter
        public static string GetDescription(Button button)
        {
            return (string)button.GetValue(DescriptionProperty);
        }

        // Setter
        public static void SetDescription(Button button, string value)
        {
            button.SetValue(DescriptionProperty, value);
        }
    }
} 
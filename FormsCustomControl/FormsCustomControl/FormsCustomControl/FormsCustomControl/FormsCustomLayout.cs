using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FormsCustomControl
{

    [DesignTimeVisible(true)]
    [ContentProperty("InputView")]
    class FormsCustomLayout : TemplatedView
    {
        /// <summary>
        /// Gets or sets the value for input view to place behind the hint label.  
        /// </summary>
        public static readonly BindableProperty InputViewProperty =
            BindableProperty.Create(nameof(InputView), typeof(View), typeof(FormsCustomLayout), null, BindingMode.Default, null, OnInputViewChanged);

        /// <summary>
        /// Raised when the input view changed.
        /// </summary>
        /// <param name="bindable">Object.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        private static void OnInputViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as FormsCustomLayout).OnInputViewChanged(oldValue, newValue);
        }

        private void OnInputViewChanged(object oldValue, object newValue)
        {
            var oldView = (View)oldValue;
            if (oldView != null)
            {
                if (this.contentGrid.Children.Contains(oldView))
                {
                    oldView.SizeChanged -= OnInputViewSizeChanged;
                    oldView.BindingContext = null;
                    this.contentGrid.Children.Remove(oldView);
                }
            }

            var newView = (View)newValue;
            if (newView != null)
            {
                newView.SizeChanged += OnInputViewSizeChanged;
                newView.VerticalOptions = LayoutOptions.CenterAndExpand;
                newView.HeightRequest = 60;
                 this.contentGrid.Children.Add(newView);
            }
        }

        private void OnInputViewSizeChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gets or sets a value indicating whether the input view enable changed.
        /// </summary>
        public  View InputView
        {
            get { return (View)GetValue(InputViewProperty); }
            set { SetValue(InputViewProperty, value); }
        }

        internal void UpdateText(object text)
        {
            this.Text = (string)text;
        }


        /// <summary>
        /// Contains the position definition of the control.
        /// </summary>
        private readonly Grid contentGrid = new Grid();

        public FormsCustomLayout()
        {
            this.ControlTemplate = new ControlTemplate(typeof(StackLayout));
            ((StackLayout)Children[0]).Children.Add(this.contentGrid);
            if (InputView != null)
            {
                this.contentGrid.Children.Add(InputView);
            }
        }

        /// <summary>
        /// Gets the text from input view of <see cref="SfTextInputLayout"/>.
        /// </summary>
        /// <value>The text.</value>
        internal string Text { get; private set; }
    }
}

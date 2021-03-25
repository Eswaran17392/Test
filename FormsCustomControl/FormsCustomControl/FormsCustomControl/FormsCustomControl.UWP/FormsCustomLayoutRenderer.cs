using FormsCustomControl;
using FormsCustomControl.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml.Automation.Peers;

[assembly: ExportRenderer(typeof(FormsCustomLayout), typeof(FormsCustomLayoutRenderer))]
namespace FormsCustomControl.UWP
{
    class FormsCustomLayoutRenderer : ViewRenderer<FormsCustomLayout, FrameworkElement>
    {
        /// <summary>
        /// Method that is called when the automation id is set.
        /// </summary>
        /// <param name="id">The automation id.</param>
        protected override void SetAutomationId(string id)
        {
            if (this.Control == null)
            {
                base.SetAutomationId(id);
            }
            else
            {
                this.SetAutomationPropertiesAutomationId(id);
                this.Control.SetAutomationPropertiesAutomationId(id);
            }
        }

        /// <summary>
        /// Provide automation peer for the control
        /// </summary>
        /// <returns>The TextInputLayout view automation peer.</returns>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            if (this.Control == null)
            {
                return new FormsCustomLayoutAutomationPeer(this);
            }

            return new FormsCustomLayoutAutomationPeer(this.Control);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FormsCustomLayout> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement;           
        }           
    }

    internal class FormsCustomLayoutAutomationPeer : FrameworkElementAutomationPeer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormsCustomLayoutRenderer"/> class.
        /// </summary>
        /// <param name="owner">FormsCustomLayout View control</param>
        public FormsCustomLayoutAutomationPeer(FrameworkElement owner) : base(owner)
        {
        }

        /// <summary>
        /// Describe the control type
        /// </summary>
        /// <returns>The control type.</returns>
        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Custom;
        }

        /// <summary>
        /// Describe the class name.
        /// </summary>
        /// <returns>The Class Name.</returns>
        protected override string GetClassNameCore()
        {
            return "FormsCustomLayout";
        }
    }
}

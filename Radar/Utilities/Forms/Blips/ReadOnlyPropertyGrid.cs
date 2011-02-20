using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Radar.Utilities.Forms.Blips
{
    public partial class ReadOnlyPropertyGrid : PropertyGrid
    {
        public ReadOnlyPropertyGrid()
        {
            InitializeComponent();
        }

        private bool _isReadOnly;

        public bool ReadOnly
        {
            get { return _isReadOnly; }

            set
            {
                _isReadOnly = value;
                SetBrowsablePropertiesAsReadOnly(SelectedObject, value);
            }
        }

        protected override void OnSelectedObjectsChanged(EventArgs e)
        {
            SetBrowsablePropertiesAsReadOnly(SelectedObject, _isReadOnly);
//            SetObjectAsReadOnly(_isReadOnly);
            base.OnSelectedObjectsChanged(e);
        }

        /// <summary>
        /// Chnages the state of the ReadOnly attribute regarding the isReadOnly flag value.
        /// </summary>
        /// <param name="selectedObject">The current object exposed by the PropertyGrid.</param>
        /// <param name="isReadOnly">The current read-only state of the PropertyGrid.</param>
        private static void SetBrowsablePropertiesAsReadOnly(object selectedObject, bool isReadOnly)
        {
            if (selectedObject == null) return;

            // Get all the properties of the selected object...
            var props = TypeDescriptor.GetProperties(selectedObject.GetType());

            foreach (PropertyDescriptor propDescript in props)
            {
                // Consider only the properties which are browsable and are not collections...
                if (!propDescript.IsBrowsable || propDescript.PropertyType.GetInterface("ICollection", true) != null)
                    continue;

                var attr =
                    propDescript.Attributes[typeof (ReadOnlyAttribute)] as ReadOnlyAttribute;

                // If the current property has a ReadOnly attribute,
                // update its state regarding the current ReadOnly state of the PropertyGrid.
                if (attr == null) continue;

                var field = attr.GetType().GetField("isReadOnly",
                                                    BindingFlags.NonPublic | BindingFlags.Instance);
                if (field != null)
// ReSharper disable AssignNullToNotNullAttribute
                    field.SetValue(attr, isReadOnly, BindingFlags.NonPublic | BindingFlags.Instance, null, CultureInfo.CurrentCulture);
// ReSharper restore AssignNullToNotNullAttribute
            }
        }
    }
}
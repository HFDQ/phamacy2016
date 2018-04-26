using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class ucBusinessScopeEditor : BaseFunctionUserControl
    {

        private List<GMSPLicenseBusinessScope> GMSPLicenseBusinessScopes { get; set; }
        
        public ucBusinessScopeEditor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                BindAllBusinessScopes();
            }
        }

        protected List<BusinessScope> BusinessScopes { get; set; }

        private void BindAllBusinessScopes()
        {
            try
            {
                string message;
                BusinessScopes = PharmacyDatabaseService.AllBusinessScopes(out message)
                   .ToList();
                if (BusinessScopes != null && string.IsNullOrWhiteSpace(message))
                {
                    foreach (BusinessScope businessScope in BusinessScopes)
                    {
                        if (businessScope.BusinessScopeCategory != null)
                        {
                            businessScope.Name = string.Format("{0}>{1}"
                                , businessScope.BusinessScopeCategory.Name
                                , businessScope.Name
                                );
                        }
                    }
                }
                if (BusinessScopes != null)
                {
                    this.checkedListBoxBusinessScopes.Items.Clear();
                    this.checkedListBoxBusinessScopes.DisplayMember = "Name";
                    this.checkedListBoxBusinessScopes.ValueMember = "Id";
                    this.checkedListBoxBusinessScopes
                        .Items.AddRange(BusinessScopes.Cast<object>().ToArray());

                }
                this.checkedListBoxBusinessScopes.Enabled = true;
            }
            catch (Exception ex)
            {
                this.checkedListBoxBusinessScopes.Enabled = false;
            }
        }

        private string selectedBusinessScopes = string.Empty;

        [Browsable(false)]
        public string SelectedBusinessScopes
        {
            set
            {
                selectedBusinessScopes = value;
                BindSelectedBusinessScopes();
            }
            get
            {
                CollectCheckedBusinessScopes();
                return selectedBusinessScopes;
            }
        }

        private void BindSelectedBusinessScopes()
        {
            if (DesignMode) return;
            checkedListBoxBusinessScopes.ClearSelected();
            if (!string.IsNullOrWhiteSpace(selectedBusinessScopes))
            {
                selectedBusinessScopes = selectedBusinessScopes.Trim();
                var businessScopes = selectedBusinessScopes.Split(',');
                //MessageBox.Show(selectedBusinessScopes.ToString());
                var items = checkedListBoxBusinessScopes.Items;
                businessScopes.ForEach(bs =>
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        var businessScope = items[i] as BusinessScope;
                        if (businessScope != null && businessScope.Name == bs )
                        {
                            //MessageBox.Show(bs.ToString() + "---" + (businessScope.Name == bs).ToString());
                            checkedListBoxBusinessScopes.SetItemChecked(i, true);
                            break;
                        }
                    }
                });
            } 
        }

        private void CollectCheckedBusinessScopes()
        {
            if (DesignMode) return;
            var items = checkedListBoxBusinessScopes.Items;
            List<string> businessScopes = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                var businessScope = items[i] as BusinessScope;
                if (businessScope == null)
                    continue;
                if (!checkedListBoxBusinessScopes.GetItemChecked(i))
                {
                    continue;
                }
                businessScopes.Add(businessScope.Name);
            }
            if (businessScopes.Count > 0)
            {
                selectedBusinessScopes = string.Join(",", businessScopes);
            }
            else
            {
                selectedBusinessScopes = string.Empty;
            }


        }
    }
}

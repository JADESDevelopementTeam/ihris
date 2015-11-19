using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace BahteraAdhiguna
{
    public partial class FormInventory : Form
    {
        string dataPassing;
        public FormInventory(string data)
        {
            InitializeComponent();
            this.dataPassing = data;

            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.KeyPreview = true;
        }

        public void RefreshDG()
        {

            Admin Auto = new Admin();
            tbItemNumber.Text = Auto.InventoryAutoGenerateID();

            Admin Show = new Admin();
            dgAllItem.DataSource = Show.InventoryDGV();
            dgAllItem.DataMember = "Inventory";

            dgSearchItem.DataSource = Show.InventoryDGV();
            dgSearchItem.DataMember = "Inventory"; 
            
            dgEditItem.DataSource = Show.InventoryDGV();
            dgEditItem.DataMember = "Inventory";

            tbEditAddStock.Enabled = false;
        }

        private void FormInventory_Load(object sender, EventArgs e)
        {
            lblUser.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            RefreshDG();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FormMainMenuMaster MM = new FormMainMenuMaster(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            MM.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("SAVE DATA? \nMAKE SURE ALL THE FORM FIELDS FILLED CORRECTLY", "DATA ENTRY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbItemNumber.Text == "" || tbItemName.Text == "" || tbItemDescription.Text == "" || tbItemCategory.Text == "" || tbItemStock.Text == "")
                    {
                        MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO SAVE DATA", "DATA ENTRY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbItemName.Focus();
                    }
                    else
                    {
                        string ItemNumber = tbItemNumber.Text;
                        string ItemName = tbItemName.Text;
                        string ItemDescription = tbItemDescription.Text;
                        string ItemCategory = tbItemCategory.Text;
                        string ItemStock = tbItemStock.Text;

                        Admin Save = new Admin();
                        Save.AddInventory(ItemNumber, ItemName, ItemDescription, ItemCategory, ItemStock);

                        MessageBox.Show("DATA SAVED", "ENTRY DATA SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tbItemName.Clear();
                        tbItemDescription.Clear();
                        tbItemCategory.Clear();
                        tbItemStock.Value = 0;

                        RefreshDG();

                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("MICROSOFT SQL SERVER DATABASE ERROR!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("INVALID OPERATION!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO QUIT?", "QUIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void dgSearchItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgSearchItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_contract = Bind.BindAllItemDetails(str);

                if (data_contract.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_contract.Count; i = i + 5)
                    {
                        string ItemNumber = (string)data_contract[i];
                        string ItemName = (string)data_contract[i + 1];
                        string ItemDescription = (string)data_contract[i + 2];
                        string ItemCategory = (string)data_contract[i + 3];
                        Int64 ItemStock = (Int64)data_contract[i + 4];

                        tbSearchItemNumber.Text = ItemNumber;
                        tbSearchItemName.Text = ItemName;
                        tbSearchItemDescription.Text = ItemDescription;
                        tbSearchItemCategory.Text = ItemCategory;
                        tbSearchItemStock.Text = ItemStock.ToString();
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("MICROSOFT SQL SERVER DATABASE ERROR!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("INVALID OPERATION!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgEditItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgEditItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_contract = Bind.BindAllItemDetails(str);

                if (data_contract.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_contract.Count; i = i + 5)
                    {
                        string ItemNumber = (string)data_contract[i];
                        string ItemName = (string)data_contract[i + 1];
                        string ItemDescription = (string)data_contract[i + 2];
                        string ItemCategory = (string)data_contract[i + 3];
                        Int64 ItemStock = (Int64)data_contract[i + 4];

                        tbEditItemNumber.Text = ItemNumber;
                        tbEditItemName.Text = ItemName;
                        tbEditItemDescription.Text = ItemDescription;
                        tbEditItemCategory.Text = ItemCategory;
                        tbEditItemStock.Text = ItemStock.ToString();

                        tbEditAddStock.Enabled = true;
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("MICROSOFT SQL SERVER DATABASE ERROR!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("INVALID OPERATION!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO RESET THIS FORM? \nRESETTING THIS FORM WILL LEAVE FORM BLANK", "ERASE ALL FIELDS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    tbItemName.Clear();
                    tbItemDescription.Clear();
                    tbItemCategory.Clear();
                    tbItemStock.Value = 0;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("MICROSOFT SQL SERVER DATABASE ERROR!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("INVALID OPERATION!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbItemStock_MouseClick(object sender, MouseEventArgs e)
        {
            tbItemStock.Select();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("DO YOU WANT UPDATE STOCK?", "STOCK UPDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbEditAddStock.Value == 0 || tbEditFinalStock.Text == "" || tbEditItemName.Text == "" || tbEditItemCategory.Text == "" || tbEditItemStock.Text == "" || tbEditItemDescription.Text == "" || tbEditItemNumber.Text == "")
                    {
                        MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO EDIT DATA", "DATA UPDATE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbEditAddStock.Focus();
                    }
                    else
                    {
                        string InventoryNumber = tbEditItemNumber.Text;
                        string InventoryName = tbEditItemName.Text;
                        string InventoryDescription = tbEditItemDescription.Text;
                        string InventoryCategory = tbEditItemCategory.Text;
                        string ItemStock = tbEditFinalStock.Text;

                        Admin Update = new Admin();
                        Update.UpdateStock(InventoryNumber, InventoryName, InventoryDescription, InventoryCategory, ItemStock);

                        MessageBox.Show("STOCK UPDATED", "ITEM STOCK UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tbEditAddStock.Value = 0;

                        tbEditItemNumber.Clear();
                        tbEditItemName.Clear();
                        tbEditItemDescription.Clear();
                        tbEditItemCategory.Clear();
                        tbEditFinalStock.Clear();
                        tbEditItemStock.Clear();

                        RefreshDG();
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("MICROSOFT SQL SERVER DATABASE ERROR!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("INVALID OPERATION!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbEditAddStock_ValueChanged(object sender, EventArgs e)
        {
            Int64 stocknow = Convert.ToInt64(tbEditItemStock.Text);
            Int64 addstock = Convert.ToInt64(tbEditAddStock.Value);
            Int64 finalstock = stocknow + addstock;

            tbEditFinalStock.Text = finalstock.ToString();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            MessageBox.Show("PRESS EXIT(ESC) BUTTON TO EXIT FULLSCREEN", "GOING FULLSCREEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("MINIMIZE THE FORM?", "MINIMIZE APPLICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                WindowState = FormWindowState.Minimized;

                niMinimized.BalloonTipText = "IHRIS RUNNING IN BACKGROUND";
                niMinimized.ShowBalloonTip(1000);
            }
        }
        
        private void FormInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExcel
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            if (Data.isRowDeleting == true)      //Якщо видаляємо рядки
            {
                deleteOne.Text = "Видалити один рядок:";
                deleteFew.Text = "Видалити рядки:";

                textBoxSingleElement.MaxLength = int.MaxValue;
                textBoxFirstElement.MaxLength = int.MaxValue;
                textBoxLastElement.MaxLength = int.MaxValue;

                if (Data.firstElementToDelete != -1 && Data.lastElementToDelete != -1)
                {
                    string firstRowToDelete = (Data.firstElementToDelete + 1).ToString();
                    string lastRowToDelete = (Data.lastElementToDelete + 1).ToString();

                    EnterDataToTextBoxes(firstRowToDelete, lastRowToDelete);
                }
                else
                {
                    ClearForm();
                }
            }
            else       //Якщо видаляємо стовпчики
            {
                deleteOne.Text = "Видалити один стовпчик:";
                deleteFew.Text = "Видалити стовпчики:";

                textBoxSingleElement.MaxLength = 1;
                textBoxFirstElement.MaxLength = 1;
                textBoxLastElement.MaxLength = 1;

                if (Data.firstElementToDelete != -1 && Data.lastElementToDelete != -1)
                {
                    string firstColumnToDelete = ConverterColumnIndex.ConvertIndexToStringSymbol(Data.firstElementToDelete);
                    string lastColumnToDelete = ConverterColumnIndex.ConvertIndexToStringSymbol(Data.lastElementToDelete);

                    EnterDataToTextBoxes(firstColumnToDelete, lastColumnToDelete);
                }
                else
                {
                    ClearForm();
                }
            }
        }

        private void EnterDataToTextBoxes(string firstToDelete, string lastToDelete)
        {
            if (Data.firstElementToDelete == Data.lastElementToDelete)     //Якщо обрали один елемент
            {
                CheckSingle();
                textBoxSingleElement.Text = firstToDelete;
            }
            else      //Якщо обрали діапазон елементів
            {
                CheckRange();
                textBoxFirstElement.Text = firstToDelete;
                textBoxLastElement.Text = lastToDelete;
            }
        }

        private void ClearForm()
        {
            textBoxSingleElement.Text = string.Empty;
            textBoxFirstElement.Text = string.Empty;    
            textBoxLastElement.Text = string.Empty;

            UnHideSingleChoice();
            UnHideRangeChoice();
        }

        private void HideSingleChoice()
        {
            textBoxSingleElement.BackColor = Color.FromKnownColor(KnownColor.ControlLight);

            deleteOne.ForeColor = Color.FromKnownColor(KnownColor.WindowFrame);

            textBoxSingleElement.Enabled = false;
        }

        private void UnHideSingleChoice()
        {
            textBoxSingleElement.BackColor = Color.FromKnownColor(KnownColor.White);

            deleteOne.ForeColor = Color.FromKnownColor(KnownColor.ControlText);

            textBoxSingleElement.Enabled = true;
        }

        private void HideRangeChoice()
        {
            textBoxFirstElement.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            textBoxLastElement.BackColor = Color.FromKnownColor(KnownColor.ControlLight);

            labelDash.ForeColor = Color.FromKnownColor(KnownColor.WindowFrame);
            deleteFew.ForeColor = Color.FromKnownColor(KnownColor.WindowFrame);


            textBoxFirstElement.Enabled = false;
            textBoxLastElement.Enabled = false;
        }

        private void UnHideRangeChoice()
        {
            textBoxFirstElement.BackColor = Color.FromKnownColor(KnownColor.White);
            textBoxLastElement.BackColor = Color.FromKnownColor(KnownColor.White);

            labelDash.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            deleteFew.ForeColor = Color.FromKnownColor(KnownColor.ControlText);

            textBoxFirstElement.Enabled = true;
            textBoxLastElement.Enabled = true;
        }

        private void CheckSingle()
        {
            deleteOne.Checked = true;
            deleteFew.Checked = false;
            HideRangeChoice();
            UnHideSingleChoice();
        }

        private void CheckRange()
        {
            deleteFew.Checked = true;
            deleteOne.Checked = false;
            HideSingleChoice();
            UnHideRangeChoice();
        }

        private void DeleteOne_CheckedChanged(object sender, EventArgs e)
        {
            if (deleteOne.Checked == true)
            {
                CheckSingle();
            }
            else
            {
                UnHideSingleChoice();
            }
        }

        private void DeleteFew_CheckedChanged(object sender, EventArgs e)
        {
            if (deleteFew.Checked == true)
            {
                CheckRange();
            }
            else
            {
                UnHideRangeChoice();
            }
        }

        private static bool CheckRowExisting(int index)   //Перевіряємо, чи вказаний індекс рядка існує
        {
            try
            {
                if (index >= 0 && index < Data.cellsList.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private static bool CheckColumnExisting(int index)    //Якщо вказаний індекс стовпчика існує
        {
            try
            {
                if (index >= 0 && index < Data.cellsList[0].Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void AcceptDelete_Click(object sender, EventArgs e)
        {
            AcceptDelete();
        }

        private void AcceptDelete()
        {
            string first, last;

            if (deleteOne.Checked == true)
            {
                first = last = textBoxSingleElement.Text;
            }
            else if (deleteFew.Checked == true)
            {
                first = textBoxFirstElement.Text;
                last = textBoxLastElement.Text;
            }
            else
            {
                MessageBox.Show("Поставте прапорець та вкажіть, що хочете видалити.");
                return;
            }

            if (Data.isRowDeleting == true)
            {
                AcceptRowDelete(first, last);
            }
            else
            {
                AcceptColumnDelete(first, last);
            }
        }

        private void AcceptRowDelete(string first, string last)
        {
            try
            {
                //Зсуваємо індекси на одиницю, бо індекси на одиницю менші від номера рядка.
                int firstIndex = Int32.Parse(first) - 1;   
                int lastIndex = Int32.Parse(last) - 1;

                if (CheckRowExisting(firstIndex) == true && CheckRowExisting(lastIndex) == true)
                {
                    AcceptNewDataForDelete(firstIndex, lastIndex);
                }
                else
                {
                    MessageBox.Show("Таких значень не існує.");
                }
            }
            catch
            {
                MessageBox.Show("Недійсні значення.");
            }
        }

        private void AcceptColumnDelete(string first, string last)
        {
            try
            {

                // перетворюємо символи char в індекси стовпчиків
                int firstIndex = ConverterColumnIndex.ConvertStringSymbolToIndex(first);
                int lastIndex = ConverterColumnIndex.ConvertStringSymbolToIndex(last);

                if (CheckColumnExisting(firstIndex) == true && CheckColumnExisting(lastIndex) == true)
                {
                    AcceptNewDataForDelete(firstIndex, lastIndex);
                }
                else
                {
                    MessageBox.Show("Таких значень не існує.");
                }
            }
            catch
            {
                MessageBox.Show("Недійсні значення.");
            }
        }

        private void AcceptNewDataForDelete(int firstIndex, int lastIndex)
        {
            try
            {
                Data.firstElementToDelete = Math.Min(firstIndex, lastIndex);
                Data.lastElementToDelete = Math.Max(firstIndex, lastIndex);
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("Не вдалось видалити. Спробуйте ще раз.");
            }
        }

        private void DeleteForm_Closed(object sender, EventArgs e)
        {
            UnHideSingleChoice();
            UnHideRangeChoice();            
        }
    }
}

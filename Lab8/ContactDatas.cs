using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class ContactDatas : Form, IOneOfMany<Form>
    {
        public ContactDatas(StudentData student)
        {
            this.student = student;
            InitializeComponent();
            error.BlinkRate = 2;
        }
        ErrorProvider error = new ErrorProvider();
        private void ContactDatas_Load(object sender, EventArgs e)
        {
            string[] cities = StudentData.AllCities.Split('\n');
            foreach(var city in cities)
            {
                comboBox1.Items.Add(city);
            }
        }
        public void SetUID(uint uid)
        {
            labelID.Text = uid.ToString();
        }
        public event Action<Form> ShowNext;
        public event Action<Form> ShowPrevious;
        private void buttonNextClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                AddToStudent();
                ShowNext(this);
            }
        }

        private void AddToStudent()
        {
            student.Phone = maskedTextBox1.Text;
            student.City = comboBox1.SelectedItem.ToString();
            student.Address = address.Text;
            student.Email = textBox1.Text;
        }
        private void buttonPrevClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                AddToStudent();
                ShowPrevious(this);
            }
        }
        private StudentData student;

        private void address_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(address.Text))
            {
                e.Cancel = true;
                error.SetError(address, "Поле должно юыть заполнено!");
            }
            else
            {
                e.Cancel = false;
                error.SetError(address, "");
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if(comboBox1.SelectedIndex==-1)
            {
                e.Cancel = true;
                error.SetError(comboBox1, "Город должен быть выбран!");
            }
            else
            {
                e.Cancel = false;
                error.SetError(comboBox1, "");
            }
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(StudentData.PhoneFormat);
            if (!regex.IsMatch(maskedTextBox1.Text))
            {
                e.Cancel = true;
                error.SetError(maskedTextBox1, $"Должен быть в формате {StudentData.PhoneFormat}");
            }
            else
            {
                e.Cancel = false;
                error.SetError(maskedTextBox1, "");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"\S+[@]\S+\.\S");
            if (!regex.IsMatch(textBox1.Text))
            {
                e.Cancel = true;
                error.SetError(textBox1, "Должен быть в формате ab@abc.ab!");
            }
            else
            {
                e.Cancel = false;
                error.SetError(textBox1, "");
            }
        }
    }
}

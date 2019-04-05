using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class PersonalDatas : Form, IOneOfMany<Form>
    {
        public PersonalDatas(StudentData student)
        {
            this.student = student;
            InitializeComponent();
            error.BlinkRate = 2;
            buttonPrev.Enabled = false;
        }
        private StudentData student;
        private ErrorProvider error = new ErrorProvider();
        
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
                AddToStud();
                ShowNext(this);
            }
        }

        private void AddToStud()
        {
            student.Name = Name.Text;
            DateTime bdayy = DateTime.Parse(bday.Text);
            student.BirthDay = DateTime.Parse(bday.Text);
            student.Passport = Passport.Text;
            if (MaleBox.Checked)
                student.Gender = Gender.Male;
            else
                student.Gender = Gender.Female;
        }

        private void buttonPrevClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                AddToStud();
                ShowPrevious(this);
            }
        }

        private void Name_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name.Text))
            {
                e.Cancel = true;
                error.SetError(Name, "Поле должно быть заполнено!");
            }
            else
            {
                e.Cancel = false;
                error.SetError(Name, "");
            }
        }

        private void bday_Validating(object sender, CancelEventArgs e)
        {
            DateTime dtime;
            try
            {

                dtime = DateTime.Parse(bday.Text);
            }
            catch
            {
                e.Cancel = true;
                error.SetError(bday, "Неверная дата");
                return;
            }
            string text = bday.Text;
            if (dtime.Year<1900 || dtime.Year>DateTime.Now.Year)
            {
                e.Cancel = true;
                error.SetError(bday, "Неверная дата");
            }
            else
            {
                e.Cancel = false;
                error.SetError(bday, "");
            }
        }

        private void Passport_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"\d{4} \d{6}");
            if (!regex.IsMatch(Passport.Text))
            {
                e.Cancel = true;
                error.SetError(Passport, "Неверный формат серии и номера");
            }
            else
            {
                e.Cancel = false;
                error.SetError(Passport, "");
            }
        }
        private Gender gender = new Gender();
        private void panel1_Validating(object sender, CancelEventArgs e)
        {
            if ((MaleBox.Checked && FemaleBox.Checked) || (!MaleBox.Checked && !FemaleBox.Checked))
            {
                error.SetError(panel1, "Должен быть выбрал один из вариантов!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                error.SetError(panel1, "");
            }
        }
    }
}

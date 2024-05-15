using DogsHouse11d.Controller;
using DogsHouse11d.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogsHouse11d
{
    public partial class Form1 : Form
    {
        DogsController dogsController = new DogsController();
        BreedsControler breedsControler = new BreedsControler();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Breed> allBreeds = breedsControler.GetAllBreeds();
            cmbBreed.DataSource = allBreeds;
            cmbBreed.DisplayMember = "Name";
            cmbBreed.ValueMember = "Id";

        }

        private void LoadRecord(Dog dog)
        {
            txtId.BackColor = Color.White;
            txtId.Text = dog.Id.ToString();
            txtName.Text = dog.Name;
            txtAge.Text = dog.Age.ToString();
            cmbBreed.Text = dog.Breeds.ToString();
        }
        private void ClearScreen()
        {
            txtId.BackColor = Color.White;
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            cmbBreed.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAge.Name) || txtName.Text == "")
            {
                MessageBox.Show("Въведи данни:");
                txtName.Focus();
                return;
            }
            Dog newDog = new Dog();
            newDog.Age = int.Parse(txtAge.Text);
            newDog.Name = txtName.Text;

            newDog.BreedsId = (int)cmbBreed.SelectedValue;

            dogsController.Create(newDog);
            MessageBox.Show("Записът е успешно добавен");
            ClearScreen();
            btnSelectAll_Click(sender, e);

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Dog> allDogs = dogsController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allDogs)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name} -Age: {item.Age}  Breed: {item.Breeds.Name}");
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtAge.Name) || txtName.Text == "")
            {
                MessageBox.Show("Въведи Id за търсене:");
                txtId.BackColor = Color.Red;
                txtName.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Dog finded = dogsController.Get(findId);
            if (finded == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД!\n Въведете Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(finded);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtAge.Name) || txtName.Text == "")
            {
                MessageBox.Show("Въведи Id за търсене:");
                txtId.BackColor = Color.Red;
                txtName.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Dog finded = dogsController.Get(findId);
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Dog findedDog = dogsController.Get(findId);
                if (findedDog == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД!\n Въведете Id за търсене!");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(finded);
            }
            else
            {
                Dog updatedDog = new Dog();
                updatedDog.Name = txtName.Text;
                updatedDog.Age = int.Parse(txtAge.Text);
                updatedDog.BreedsId = (int)cmbBreed.SelectedValue;

                dogsController.Update(findId, updatedDog);
            }
            btnSelectAll_Click(sender, e);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int findId = 0;
            if (string.IsNullOrEmpty(txtAge.Name) || txtName.Text == "")
            {
                MessageBox.Show("Въведи Id за търсене:");
                txtId.BackColor = Color.Red;
                txtName.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Dog finded = dogsController.Get(findId);
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Dog findedDog = dogsController.Get(findId);
                if (findedDog == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД!\n Въведете Id за търсене!");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(finded);
            }
            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете записа №", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes) 
            {
                dogsController.Delete(findId);  
            }
            btnSelectAll_Click(sender, e);  
        }
    }
}

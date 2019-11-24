using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintanance.Entities;

namespace UserMaintanance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblFullName.Text = Resource1.FullName; // label1
            buttonAdd.Text = Resource1.Add; // button1
            buttonWriteIntoFile.Text = Resource1.WriteIntoFile; // button1
            buttonDelete.Text = Resource1.DeleteSelected; // button1

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtFullName.Text,
            };
            users.Add(u);
        }

        private void buttonWriteIntoFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt|txt)";
                sfd.DefaultExt = "txt";
                sfd.AddExtension = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName,true,Encoding.UTF8))
                    {
                        sw.WriteLine("ID\tFullName");
                        foreach (var u in users)
                        {
                            sw.WriteLine(u.ID + "\t" + u.FullName);
                        }
                    }
                }
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem == null)
            {
                return;
            }
            User u = (User)listUsers.SelectedItem;
            users.Remove(u);
        }
    }
}
